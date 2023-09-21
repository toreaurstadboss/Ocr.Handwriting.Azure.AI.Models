namespace Ocr.Handwriting.Azure.AI.Models
{

    public class IndexModel
    {
        public string FilePath { get; set; }
        public long FileSize { get; set; }
        public string OcrOutputText { get; set; }
    }

}
