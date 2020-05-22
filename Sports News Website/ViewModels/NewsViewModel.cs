using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sports_News_Website.ViewModels
{
    public class NewsViewModel
    {
        public int ID { get; set; }
        [Required]
        [MinLength(6)]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MinLength(10)]
        public string Content { get; set; }
        public HttpPostedFileBase Photo { get; set; }
        public NewsViewModel()
        {

        }
    }
}