using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Phase4.Models
{
    public class Student
    {
        private static List<Student> allStudent = new List<Student>();
        private int studentNumber;
        private string firstName;
        private string lastName;
        private List<double> grades;
        private double average;

        public int StudentNumber
        {
            get
            {
                return studentNumber;
            }
            set
            {
                studentNumber = value;
            }
        }
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }
        public double Average
        {
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
    }
}