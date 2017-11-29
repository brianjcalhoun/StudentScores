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
    public partial class AddStudent : Form
    {

        public AddStudent()
        {
            InitializeComponent();
        }

        private Student newStudent = new Student();

        List<int> totalScores = new List<int>();

        //Returns the new student to the main form
        public Student addStudent()
        {
            this.ShowDialog();
            return newStudent;
        }

        private void btnAddScore_Click(object sender, EventArgs e)
        {
            //make a list of scores
            int s = 0;

            if (Int32.TryParse(txtScore.Text, out s))
            {
                if (s <= 100 && s >= 0)
                {
                    totalScores.Add(Convert.ToInt32(txtScore.Text));
                    txtScores.Text += (txtScore.Text + "|");
                    txtScore.Clear();
                    txtScore.Focus();
                }
                else
                {
                    MessageBox.Show("Valid score range is 0-100.", "Entry Error");
                }
            }
        }

        private void btnClearScores_Click(object sender, EventArgs e)
        {
            //clears all of student scores and creates a new list to start adding new scores
            totalScores = new List<int>();
            txtScores.Clear();
            txtScore.Focus();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //grabs student name and scores list to send to main form
            if (txtName.Text != "" && txtScores.Text != null)
            {
                newStudent = new Student(txtName.Text.Trim(), totalScores);
                this.Close();
            }
            else
            {
                MessageBox.Show("Please verify the Name and Score entry fields to contine.", "Entry Error");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //closes add student window
            this.Close();
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        //allows letters, backspace, and spacebar ornly
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Space || e.KeyChar == (char)Keys.Back);
            lblName.Enabled = false;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        //hides label Text when text is entered
        {
            TextBox tb = sender as TextBox;
            lblName.Text = "";
        }

        private void txtScore_KeyPress(object sender, KeyPressEventArgs e)
        //allows numbers and backspace only
        {
            e.Handled = !(char.IsNumber(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txtScore_TextChanged(object sender, EventArgs e)
        //hides label direction when text is entered
        {
            TextBox tb = sender as TextBox;
            lblScore.Text = "";
        }
    }
}
