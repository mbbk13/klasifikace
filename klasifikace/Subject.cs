using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klasifikace
{
    public class Subject
    {
        public int id { get; set; }
        public string name { get; set; }
        public string shortName { get; set; }
        public Teacher teacher { get; set; }
    }
}
