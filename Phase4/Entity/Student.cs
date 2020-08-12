using System.Collections.Generic;
using System.Linq;

namespace Phase4.Models
{
    public class Student
    {
        private static List<Student> allStudent = new List<Student>();
        public string FirstName { set; get; }
        public string LastName { set; get; }
        
        public int StudentNumber { get; set; }

        private List<double> grades;
        public double Average { 
            get
            {
                grades = Grade.GetGradesByStudentId(StudentNumber);
                return grades.Average();
            } 
        }

        public static List<Student> GetAllStudent()
        {
            return allStudent;
        }

        public static void AddStudent(Student student)
        {
            allStudent.Add(student);
        }

        public static Student GetStudentById (int id) {
            foreach (var student in allStudent) {
                if (student.StudentNumber == id) {
                    return student;
                }
            }
            return null;
        }

        public override string ToString()
        {
            return FirstName + " " + LastName + "\n" + Average;
        }
    }
}