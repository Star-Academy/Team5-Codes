using System.Collections.Generic;

namespace Phase4.Models
{
    public class Score
    {
        private static List<Score> allScore = new List<Score>();
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
        public double ScoreNumber
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

        public static List<Score> GetAllScore () {
            return allScore;
        }

        public static void AddScore(Score score) {
            allScore.Add(score);
        }
    }
}