using System;
using System.Collections.Generic;
using Phase4.Database;
using Phase4.Models;

namespace Team5_Codes
{
    class Program
    {
        private static Student[] topStudents;
        // private const int topNumber = 3;
        public static void Main(string[] args)
        {
            JsonFile studentFile = new StudentJsonFile("DataFiles\\Students.json");
            JsonFile ScoreFile = new ScoreJsonFile("DataFiles\\Scores.json");

            topStudents =  new Student[3];

            List<Student> allStudent = Student.GetAllStudent();
            allStudent.Sort(delegate (Student std1, Student std2)
            {
                return std2.Average.CompareTo(std1.Average);
            });
            topStudents = allStudent.ToArray();

            for (int i = 0; i < 3 && i < topStudents.Length; i++)
            {
                Console.WriteLine((i + 1) + ":\n" + topStudents[0].FirstName + " " + topStudents[0].LastName + "\n" + topStudents[0].Average);
            }
        }
    }
}