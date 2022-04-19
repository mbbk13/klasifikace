using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace klasifikace
{
    public class SQLRepository
    {
        private string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;
                                            Initial Catalog=Klasifikace;
                                            Integrated Security=True;
                                            Connect Timeout=30;
                                            Encrypt=False;
                                            TrustServerCertificate=False;
                                            ApplicationIntent=ReadWrite;
                                            MultiSubnetFailover=False";

        private Dictionary<int,Teacher> teachers;

        public SQLRepository()
        {
            teachers = GetTeachersFromD();
        }


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
            List<Student> students = new List<Student>();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = sqlConnection;
                        sqlCommand.CommandText = "select * from Student";
                        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                        {
                            while (sqlDataReader.Read())
                            {
                                students.Add(new Student()
                                {
                                    id = Convert.ToInt32(sqlDataReader["id"]),
                                    firstname = sqlDataReader["firstName"].ToString(),
                                    lastname = sqlDataReader["lastname"].ToString(),
                                    birthday = Convert.ToDateTime(sqlDataReader["birthday"]),
                                });
                            }
                        }
                    }
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Some error happend (Exception: {ex.Message}");
            }
            //return TempStudents();
            return students;
        }

        public List<Grade> GetGrades(Student student)
        {
            List<Grade> grades = new List<Grade>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using(SqlCommand sqlCommand = new SqlCommand("", sqlConnection))
                {
                    sqlCommand.CommandText = "";
                }
            }
            return grades;
        }

        private Dictionary<int,Teacher> GetTeachersFromD()
        {
            Dictionary<int, Teacher> teachers = new Dictionary<int, Teacher>();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    using (SqlCommand sqlCommand = new SqlCommand())
                    {
                        sqlCommand.Connection = sqlConnection;
                        sqlCommand.CommandText = "select * from Teacher";
                        using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                        {
                            while (sqlDataReader.Read())
                            {
                                var id = Convert.ToInt32(sqlDataReader["id"]);
                                teachers.Add(id, new Teacher()
                                {
                                    id = id,
                                    name = sqlDataReader["name"].ToString(),
                                    shortName = sqlDataReader["shortName"].ToString(),
                                });
                            }
                        }
                    }
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Some error happend (Exception: {ex.Message}");
            }
            //return TempStudents();
            return teachers;
        }   
        
        public List<Teacher> GetTeachers()
        {
            return teachers.SelectMany(t => t.Value);
        }

        public Teacher GetTeacher(int id)
        {
            foreach(var teacher in teachers)
            {
                if (teacher.id == id)
                {
                    return teacher;
                }
            }
            return null;
        }
    }
}
