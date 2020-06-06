using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sports_News_Website.ViewModels
{
    public class ChangeUserPasswordViewModel
    {
        public int ID { get; set; }
        [Required]
        [MinLength(4)]
        public string Password { get; set; }
    }
}