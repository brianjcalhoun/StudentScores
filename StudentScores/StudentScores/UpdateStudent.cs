using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentScores
{
    public partial class UpdateStudent : Form
    {
        public UpdateStudent()
        {
            InitializeComponent();
        }

        private List<int> scores = new List<int>();

        private Student studentUpdate;

        public Student updatedStudent(Student Student)
            //returns my updated student to the main form
        {
            studentUpdate = Student;
            this.ShowDialog();
            return studentUpdate;
        }


        private void UpdateStudent_Load(object sender, EventArgs e)
            //Loads selected student from main form
        {
            txtStudentName.Text = studentUpdate.Name;

            foreach (int score in studentUpdate.Score)
            {
                scores.Add(score);
            }

            FillScoresListBox();
        }

        private void btnAdd_Click(object sender, EventArgs e)
            //Opens form to add a score 
        {
            AddScore addScoreForm = new AddScore();
            int newScore = addScoreForm.AddNewScore();
            if (newScore != -1 & newScore != 0)
            {
                scores.Add(newScore);
                this.FillScoresListBox();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
            //Opens form to update a score
        {
            int s = lstScores.SelectedIndex;
            if (s != -1)
            {
                UpdateScore updateScoreForm = new UpdateScore();
                updateScoreForm.ScoreUpdate = scores[lstScores.SelectedIndex];
                scores[lstScores.SelectedIndex] = updateScoreForm.updateScore();

                FillScoresListBox();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            //Removes score from list at selected index
            scores.RemoveAt(lstScores.SelectedIndex);
            FillScoresListBox();
        }

        private void btnClearScores_Click(object sender, EventArgs e)
        {
            //clears student scores
            scores.Clear();
            lstScores.Items.Clear();
        }

        private void FillScoresListBox()
        {
            //add students from student list to display in the List Box
            lstScores.Items.Clear();

            foreach (int s in scores)
            {
                lstScores.Items.Add(s);
            }

            lstScores.SelectedIndex = -1;
        }

        private void btnOK_Click(object sender, EventArgs e)
            //returns update student info to main form
        {
            studentUpdate.Score = scores;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
