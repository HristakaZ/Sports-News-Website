using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Sports_News_Website.ViewModels
{
    public class UpdateAthleteViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [MinLength(4)]
        [Required]
        public string Name { get; set; }
        public int? Sport { get; set; }
    }
}