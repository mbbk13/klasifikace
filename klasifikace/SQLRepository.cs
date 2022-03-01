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
            var student1 = new Student()
            {
                id = 1,
                firstname = "Pepa",
                lastname = "Zdepa",
                birthday = DateTime.Parse("1.1.2000"),
                grades = new List<Grade>()
            };
            students.Add(student1);
            var student2 = new Student()
            {
                id = 2,
                firstname = "Franta",
                lastname = "Skočdopole",
                birthday = DateTime.Parse("28.2.2000"),
                grades = new List<Grade>()
            };
            students.Add(student2);
            return students;
        }

        public List<Student> GetStudents(){
            //List<Student> students = new List<Student>();
            return TempStudents();
            //return students;
        }
    }
}
