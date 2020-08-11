using System.Collections.Generic;

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
                return CalculateAvearage();
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

        private double CalculateAvearage()
        {
            grades = Score.getGradesByStudentId(studentNumber);
            double sum = 0;
            foreach (var eachGrade in grades)
            {
                sum += eachGrade;
            }
            return sum / (grades.Capacity);
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