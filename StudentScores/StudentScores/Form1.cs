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
    public partial class Scores : Form
    {
        public Scores()
        {
            InitializeComponent();
        }

        List<Student> students = new List<Student>();

        private void Scores_Load(object sender, EventArgs e)
        {
            //added sample students
            students.Add(new Student("Geddy Lee", new List<int> { 97, 30, 50 }));
            students.Add(new Student("Neil Peart", new List<int> { 99, 93, 97 }));
            students.Add(new Student("Alex Lifeson", new List<int> { 100, 100, 100 }));

            FillStudentListBox();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            //opens up add student form
            AddStudent addStudentForm = new AddStudent();
            Student newStudent = addStudentForm.addStudent();

            if (newStudent.Name != null & newStudent.Score != null)
            {
                students.Add(newStudent);
                this.FillStudentListBox();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int s = lstStudents.SelectedIndex;
            if (s != -1)
            {
                //opens up updates student form
                UpdateStudent updateStudentForm = new UpdateStudent();
                updateStudentForm.updatedStudent(students[lstStudents.SelectedIndex]);

                FillStudentListBox();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //making a the selected item in the list box an int
            int i = lstStudents.SelectedIndex;

            //statement confirming and executing the deletion of selected student in student list box 
            if (i != -1)
            {
                Student student = students[i];
                string message = "Are you want to delete " + student.Name + "?";
                DialogResult button = MessageBox.Show(message, "Confrim Delete", MessageBoxButtons.YesNo);

                if (button == DialogResult.Yes)
                {
                    students.Remove(student);
                    FillStudentListBox();
                }
            }
        }

        private void lstStudents_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            int s = lstStudents.SelectedIndex;
            if (s != -1)
            {
                //selected item
                string curItem = lstStudents.SelectedItem.ToString();

                //assigned variables
                int scoreTotal = 0;
                int scoreCount = 0;
                int scoreAverage = 0;

                //turn selected list item into an array
                string[] studentData = curItem.Split('|');

                //for loop that gathers everything but Name (index 0)
                for (int i = 1; i < studentData.Length; i++)
                {
                    scoreTotal += Convert.ToInt32(studentData[i]);
                }

                if (scoreTotal == 0 & scoreCount == 0 & scoreAverage == 0)
                {
                    txtScoreTotal.Text = "";
                    txtScoreCount.Text = "";
                    txtScoreAverage.Text = "";
                }
                else
                {
                    //Gets total score
                    txtScoreTotal.Text = scoreTotal.ToString();

                    //gets total number of scores
                    scoreCount = studentData.Length - 1;
                    txtScoreCount.Text = scoreCount.ToString();

                    //get average of total scores
                    scoreAverage = scoreTotal / scoreCount;
                    txtScoreAverage.Text = scoreAverage.ToString();
                }
            }
        }

        private void FillStudentListBox()
        {
            //method for adding students into list box
            lstStudents.Items.Clear();
            foreach (Student s in students)
            {
                lstStudents.Items.Add(s.GetDisplayText());
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //closes application
            this.Close();
        }

    }
}
