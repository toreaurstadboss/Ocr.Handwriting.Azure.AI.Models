using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;

namespace Ocr.Handwriting.Azure.AI.Lib
{
    public interface IComputerVisionClientFactory
    {
        ComputerVisionClient CreateClient();
    }
}