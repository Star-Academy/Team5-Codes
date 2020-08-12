using System.Collections.Generic;

namespace Phase4.Models
{
    public class Grade
    {
        private static List<Grade> allScore = new List<Grade>();
        public int StudentNumber { get; set; }
        public string Lesson { get; set; }
        public double Score{ get; set; }
        public static List<double> GetGradesByStudentId(int studentNumber)
        {
            List<double> output = new List<double>();
            foreach (var grade in allScore)
            {
                if (grade.StudentNumber == studentNumber)
                {
                    output.Add(grade.Score);
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