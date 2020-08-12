using System;
using System.Collections.Generic;
using Phase4.Database;
using Phase4.Models;

namespace Team5_Codes
{
    class Program
    {
        // private static List<Student> topThree = new List<Student>();
        private static Student[] topThree = new Student[3];
        private static int counter = 0;

        public static void Main(string[] args)
        {
            JsonFile studentFile = new StudentJsonFile("DataFiles\\Students.json");
            JsonFile ScoreFile = new ScoreJsonFile("DataFiles\\Scores.json");

            FindBestGrades();

            Console.WriteLine("1st:\n" +
            topThree[0].FirstName + " " + topThree[0].LastName + "\n" + topThree[0].Average);
            Console.WriteLine("2nd:\n" +
            topThree[1].FirstName + " " + topThree[1].LastName + "\n" + topThree[1].Average);
            Console.WriteLine("3rd:\n" +
            topThree[2].FirstName + " " + topThree[2].LastName + "\n" + topThree[2].Average);
        }

        private static void FindBestGrades()
        {
            foreach (var student in Student.GetAllStudent())
            {
                if (counter < 3)
                {
                    AddTopStudent(student);
                    counter++;
                }
                else
                {
                    if (topThree[2].Average > student.Average)
                    {
                        return;
                    }
                    else if (topThree[1].Average > student.Average)
                    {
                        AddTopStudent(student);
                    }
                    else if (topThree[0].Average > student.Average)
                    {
                        AddTopStudent(student);
                    }
                    else
                    {
                        AddTopStudent(student);
                    }
                }
            }
        }
        
        private static void AddTopStudent(Student student)
        {
            if (counter == 0)
            {
                topThree[0] = student;
            }
            else if (counter == 1)
            {
                if (topThree[0].Average > student.Average)
                {
                    topThree[1] = student;
                }
                else
                {
                    var temp = topThree[0];
                    topThree[0] = student;
                    topThree[1] = temp;
                }
            }
            else
            {
                if (topThree[1].Average > student.Average)
                {
                    topThree[2] = student;
                }
                else if (topThree[0].Average > student.Average)
                {
                    var temp = topThree[1];
                    topThree[1] = student;
                    topThree[2] = temp;
                }
                else
                {
                    topThree[2] = topThree[1];
                    topThree[1] = topThree[0];
                    topThree[0] = student;
                }
            }
        }
    }
}
