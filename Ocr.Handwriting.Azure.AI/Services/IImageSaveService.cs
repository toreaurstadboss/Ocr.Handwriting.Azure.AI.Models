using Microsoft.AspNetCore.Components.Forms;
using Ocr.Handwriting.Azure.AI.Models;

namespace Ocr.Handwriting.Azure.AI.Services
{
    public interface IImageSaveService
    {
        Task<ImageSaveModel> SaveImage(IBrowserFile browserFile);
    }
}