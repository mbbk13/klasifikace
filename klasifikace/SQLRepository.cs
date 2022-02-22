using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klasifikace
{
    public class SQLRepository
    {
        public List<Student> TempStudents()
        {
            List<Student> students = new List<Student>();
            var student = new Student()
            {
                id = 1,
                firstname = "Pepa",
                lastname = "Zdepa",
                birthday = DateTime.Parse("1.1.2000"),
                grades = new List<Grade>()
            };
            return students;
        }

        public List<Student> GetStudents(){
            List<Student> students = new List<Student>();

            return students;
        }
    }
}
