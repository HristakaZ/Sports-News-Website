using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sports_News_Website.Models
{
    public class News
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Photo { get; set; }
    }
}