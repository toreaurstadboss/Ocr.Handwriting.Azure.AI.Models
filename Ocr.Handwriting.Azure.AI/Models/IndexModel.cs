﻿namespace Ocr.Handwriting.Azure.AI.Models
{

    public class IndexModel
    {
        public string FilePath { get; set; }
        public long FileSize { get; set; }
        public string OcrOutputText { get; set; }
        public string SavedFilePath { get; set; }
        public string PreviewImageUrl { get; set; }


        public IndexModel()
        {            
        }

        public IndexModel(ImageSaveModel imageSaveModel)
        {
            FilePath = imageSaveModel.FilePath;
            FileSize = imageSaveModel.FileSize;
            SavedFilePath = imageSaveModel.SavedFilePath;
            PreviewImageUrl = imageSaveModel.PreviewImageUrl;              
        }
    }

}
