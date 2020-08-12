using System;
using System.Collections.Generic;

namespace Phase4.Models
{
    public class Grade
    {
        private static List<Grade> allScore = new List<Grade>();
        private int studentNumber;
        private string lesson;
        private double scoreNumber;

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
        public string Lesson
        {
            get
            {
                return lesson;
            }
            set
            {
                lesson = value;
            }
        }
        public double Score
        {
            get
            {
                return scoreNumber;
            }
            set
            {
                scoreNumber = value;
            }
        }

        public static List<double> GetGradesByStudentId(int studentNumber)
        {
            List<double> output = new List<double>();
            foreach (var grade in allScore)
            {
                if (grade.studentNumber == studentNumber)
                {
                    output.Add(grade.scoreNumber);
                }
            }
            return output;
        }

        public static List<Grade> GetAllScore()
        {
            return allScore;
        }

        public static void AddScore(Grade score)
        {
            allScore.Add(score);
        }
    }
}