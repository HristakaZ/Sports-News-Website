using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sports_News_Website.ViewModels
{
    public class NewsViewModel
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public HttpPostedFileBase Photo { get; set; }
        public NewsViewModel()
        {

        }
    }
}