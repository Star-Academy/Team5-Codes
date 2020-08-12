using System.Collections.Generic;
using System.Linq;

namespace Phase4.Models
{
    public class Student
    {
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public int StudentNumber { get; set; }
        private List<double> studentGrades;
        public double Average { 
            get
            {
                return studentGrades.Average();
            } 
        }

        public override string ToString()
        {
            return FirstName + " " + LastName + "\n" + Average;
        }

        public void setGrades (List<Grade> allGrades) {
            studentGrades = new List<double>();
            foreach (var grade in allGrades) {
                if (grade.StudentNumber == this.StudentNumber) {
                    studentGrades.Add(grade.Score);
                }
            }
        }
    }
}