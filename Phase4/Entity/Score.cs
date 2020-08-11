namespace Phase4.Models
{
    public class Score
    {
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
    }
}