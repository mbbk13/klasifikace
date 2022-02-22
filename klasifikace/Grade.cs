using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klasifikace
{
    public class Grade
    {
        public int id { get; set; }
        public int gradeNumber { get; set; }
        public Subject subject { get; set; }
        public double weight { get; set; }
        public string comment { get; set; }
    }
}
