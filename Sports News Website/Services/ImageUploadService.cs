using Microsoft.Ajax.Utilities;
using Sports_News_Website.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace Sports_News_Website.Services
{
    public class ImageUploadService
    {
        public string UploadImage(NewsViewModel newsViewModel)
        {
            string fileName = newsViewModel.Photo.FileName; // the photo that is uploaded
            string targetFolder = System.Web.HttpContext.Current.Server.MapPath("~/Photo"); // the folder where the photo needs to go
            string targetPath = Path.Combine(targetFolder, fileName); // the whole path
            newsViewModel.Photo.SaveAs(targetPath); // saving the photo
            return fileName;
        }
        public bool CheckImageExtension(NewsViewModel newsViewModel)
        {
            if (!newsViewModel.Photo.FileName.EndsWith(".jpg") && !newsViewModel.Photo.FileName.EndsWith(".jpeg") && !newsViewModel.Photo.FileName.EndsWith(".png"))
            {
                return false;
            }
            return true;
        }
    }
}