using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class Comments
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public Users User { get; set; }
        public News News { get; set; }
    }
}
