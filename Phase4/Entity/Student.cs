using System.Collections.Generic;
using System.Linq;

namespace Phase4.Models
{
    public class Student
    {
        private static List<Student> allStudent = new List<Student>();
        private int studentNumber;
        public string firstName { set; get; }
        public string lastName { set; get; }
        private List<double> grades;
        public double average { 
            get
            {
                grades = Grade.GetGradesByStudentId(studentNumber);
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
                if (student.studentNumber == id) {
                    return student;
                }
            }
            return null;
        }

        public override string ToString()
        {
            return firstName + " " + lastName + "\n" + average;
        }
    }
}