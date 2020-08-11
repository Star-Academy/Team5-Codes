using System;
using System.Collections.Generic;
using System.Linq;
using Phase4.Database;
using System.Text.Json;
using Phase4.Models;

namespace Team5_Codes
{
    class Program
    {
        private static List<Student> topThree = new List<Student>();

        static void Main(string[] args)
        {
            JsonFile studentFile = new StudentJsonFile("DataFiles\\Students.json");
            JsonFile ScoreFile = new ScoreJsonFile("DataFiles\\Scores.json");
            ShowBestGrades();
        }

        private static void ShowBestGrades()
        {
            foreach (var student in Student.GetAllStudent())
            {
                if (topThree.Capacity < 3)
                {
                    AddTopStudent(student);
                }
                else
                {
                    
                }
            }
        }

        private static void AddTopStudent(Student student)
        {

        }
    }
}
