using Phase4.Database;
using Phase4.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Team5_Codes
{
    class Program
    {
        private const int NumberOfWanted = 3;

        public static void Main(string[] args)
        {
            
            StudentJsonFile studentFile = new StudentJsonFile(@".\DataFiles\Students.json");
            ScoreJsonFile scoreFile = new ScoreJsonFile(@".\DataFiles\Scores.json");

            List<Student> allStudents = studentFile.Init();
            List<Grade> allScores = scoreFile.Init();

            Student[] topStudents = new Student[NumberOfWanted];
            allStudents = setStudentsGrades(allScores, allStudents);
            FindBestGrades(ref topStudents, allStudents);

            for (int i = 0; i < NumberOfWanted; i++)
            {
                Console.WriteLine((i + 1) + ":\n" + topStudents[i]);
            }
            
        }

        private static void FindBestGrades(ref Student[] topStudents, List<Student> allStudents)
        {
            allStudents = allStudents.OrderByDescending(x => x.Average).ToList();
            for (int i = 0; i < NumberOfWanted; i++)
            {
                topStudents[i] = allStudents[i];
            }
        }

        private static List<Student> setStudentsGrades(List<Grade> allScores, List<Student> allStudents) {
            foreach (var student in allStudents) {
                student.setGrades(allScores);
            }
            return allStudents;
        }
    }
}
