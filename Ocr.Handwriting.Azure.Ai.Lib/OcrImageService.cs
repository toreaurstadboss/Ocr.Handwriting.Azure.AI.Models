using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using ReadResult = Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models.ReadResult;

namespace Ocr.Handwriting.Azure.AI.Lib
{

    public class OcrImageService : IOcrImageService
    {
        private readonly IComputerVisionClientFactory _computerVisionClientFactory;

        public OcrImageService(IComputerVisionClientFactory computerVisionClientFactory)
        {
            _computerVisionClientFactory = computerVisionClientFactory;
        }

        private ComputerVisionClient CreateClient() => _computerVisionClientFactory.CreateClient();

        public async Task<string> GetReadResultsText(string imageFilePath)
        {
            var readResults = await GetReadResults(imageFilePath);
            var ocrText = ExtractText(readResults?.FirstOrDefault());
            return ocrText;
        }


        public async Task<IList<ReadResult?>?> GetReadResults(string imageFilePath)
        {
            if (string.IsNullOrWhiteSpace(imageFilePath))
            {
                return null;
            }

            try
            {
                var client = CreateClient();

                //Retrieve OCR results 

                using (FileStream stream = File.OpenRead(imageFilePath))
                {
                    var textHeaders = await client.ReadInStreamAsync(stream);
                    string operationLocation = textHeaders.OperationLocation;
                    string operationId = operationLocation[^36..]; //hat operator of C# 8.0 : this slices out the last 36 chars, which contains the guid chars which are 32 hexadecimals chars + four hyphens

                    ReadOperationResult results;

                    do
                    {
                        results = await client.GetReadResultAsync(Guid.Parse(operationId));
                        Console.WriteLine($"Retrieving OCR results for operationId {operationId} for image {imageFilePath}");
                    }
                    while (results.Status == OperationStatusCodes.Running || results.Status == OperationStatusCodes.NotStarted);

                    IList<ReadResult?> result = results.AnalyzeResult.ReadResults;
                    return result;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        private static string ExtractText(ReadResult? readResult) => string.Join(Environment.NewLine, readResult?.Lines?.Select(l => l.Text) ?? new List<string>());

    }

}
