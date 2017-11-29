using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentScores
{
    public class Student : ICloneable
    {
        private string name;
        private List<int> score = new List<int>();

        public Student()
        {
        }

        public Student(string name, List<int> score)
        {
            this.Name = name;
            this.Score = score;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }


        public List<int> Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
            }
        }
        public string GetDisplayText()
        {
            string scores = "";

            foreach (int i in score)
            {
                scores += "|" + i.ToString();
            }

            return name + scores;
        }

        public object Clone() => new Student(this.Name, this.Score);
    }
}
