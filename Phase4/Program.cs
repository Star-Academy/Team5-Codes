using System;
using System.Collections.Generic;
using Phase4.Database;
using Phase4.Models;

namespace Team5_Codes
{
    class Program
    {
        private static List<Student> topThree = new List<Student>(3);

        static void Main(string[] args)
        {
            JsonFile studentFile = new StudentJsonFile("DataFiles\\Students.json");
            JsonFile ScoreFile = new ScoreJsonFile("DataFiles\\Scores.json");
            FindBestGrades();
            Console.WriteLine(topThree[0].Average);
            Console.WriteLine(topThree[1].Average);
            Console.WriteLine(topThree[2].Average);
        }

        private static void FindBestGrades()
        {
            foreach (var student in Student.GetAllStudent())
            {
                if (topThree.Capacity < 3)
                {
                    AddTopStudent(student);
                }
                else
                {
                    if (topThree[2].Average < student.Average)
                    {
                        return;
                    }
                    else if (topThree[1].Average < student.Average)
                    {
                        AddTopStudent(student, 2);
                    }
                    else if (topThree[0].Average < student.Average)
                    {
                        AddTopStudent(student, 1);
                    }
                    else
                    {
                        AddTopStudent(student, 0);
                    }
                }
            }
        }
        private static void AddTopStudent(Student student, int index)
        {
            topThree[index] = student;
        }
        private static void AddTopStudent(Student student)
        {
            if (topThree.Capacity == 0) {
                topThree[0] = student;
            } else if (topThree.Capacity == 1) {
                if (topThree[0].Average > student.Average) {
                    topThree[1] = student;
                } else {
                    var temp = topThree[0];
                    topThree[0] = student;
                    topThree[1] = temp;
                }
            } else {
                if (topThree[1].Average > student.Average) {
                    topThree[2] = student;
                } else if (topThree[0].Average > student.Average) {
                    var temp = topThree[1];
                    topThree[1] = student;
                    topThree[2] = temp;
                } else {
                    topThree[2] = topThree[1];
                    topThree[1] = topThree[0];
                    topThree[0] = student;
                }
            }
        }
    }
}
