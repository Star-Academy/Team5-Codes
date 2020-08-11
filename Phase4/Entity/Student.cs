using System.Collections.Generic;

namespace Phase4.Models
{
    public class Student
    {
        private static List<Student> allStudent = new List<Student>();
        private int studentNumber;
        private string firstName;
        private string lastName;

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

        public static List<Student> GetAllStudent () {
            return allStudent;
        }

        public static void AddStudent(Student student) {
            allStudent.Add(student);
        }

    }
}