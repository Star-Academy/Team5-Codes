using Phase4.Database;
using Phase4.Models;
using System;
using System.Linq;

namespace Team5_Codes
{
    class Program
    {
        private const int NumberOfWanted = 3;
        private static Student[] topStudents = new Student[NumberOfWanted];

        public static void Main(string[] args)
        {
            
            StudentJsonFile studentFile = new StudentJsonFile(@"C:\Users\Farshid726\Desktop\Codes\CodeStar\Team5-Codes\Phase4\DataFiles\\Students.json");
            ScoreJsonFile ScoreFile = new ScoreJsonFile(@"C:\Users\Farshid726\Desktop\Codes\CodeStar\Team5-Codes\Phase4\DataFiles\\Scores.json");

            FindBestGrades();

            for (int i = 0; i < NumberOfWanted; i++)
            {
                Console.WriteLine("" + (i + 1) + "st:\n" + topStudents[i]);
            }
            
        }

        private static void FindBestGrades()
        {
            var list = Student.GetAllStudent();
            list = list.OrderBy(x => -x.Average).ToList();
            for (int i = 0; i < NumberOfWanted; i++)
            {
                topStudents[i] = list[i];
            }
        }
    }
}
