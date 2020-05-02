using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class Athletes
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual Sports Sport { get; set; }
    }
}
