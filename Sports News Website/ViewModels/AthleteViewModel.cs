using DataStructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sports_News_Website.ViewModels
{
    public class AthleteViewModel
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Sport { get; set; }
    }
}