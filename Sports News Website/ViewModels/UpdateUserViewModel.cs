using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sports_News_Website.ViewModels
{
    public class UpdateUserViewModel
    {
        public int ID { get; set; }
        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        public string Username { get; set; }
        public bool IsAdmin { get; set; }
    }
}