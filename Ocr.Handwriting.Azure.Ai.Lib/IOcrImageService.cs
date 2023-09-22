using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;

namespace Ocr.Handwriting.Azure.AI.Lib
{
    public interface IOcrImageService
    {
        Task<IList<ReadResult?>?> GetReadResults(string imageFilePath);
        Task<string> GetReadResultsText(string imageFilePath);
    }
}