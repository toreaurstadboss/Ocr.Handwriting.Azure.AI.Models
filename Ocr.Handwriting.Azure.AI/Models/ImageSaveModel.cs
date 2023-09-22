namespace Ocr.Handwriting.Azure.AI.Models
{

    public class ImageSaveModel
    {
        public string PreviewImageUrl { get; set; }
        public string SavedFilePath { get; set; }
        public string FilePath { get; set; }
        public long FileSize { get; set; }
    }

}
