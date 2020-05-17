using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class News
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [MinLength(6)]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MinLength(10)]
        public string Content { get; set; }
        [Required]
        public string Photo { get; set; }
        public Users User { get; set; }
        public virtual List<Comments> Comments { get; set; }
    }
}
