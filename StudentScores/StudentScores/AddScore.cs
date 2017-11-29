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
    public partial class AddScore : Form
    {
        public AddScore()
        {
            InitializeComponent();
        }

        private int newScore;

        public int AddNewScore()
            //returns new score to updateform
        {
            this.ShowDialog();
            return newScore;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        //add new score value to text box
        {
            int i = 0;

            if (Int32.TryParse(txtScore.Text, out i))
            {
                if (i <= 100 && i >= 0)
                {
                    newScore = Convert.ToInt32(txtScore.Text);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Valid score range is 0-100.", "Entry Error");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
            //closes form
        {
            txtScore.Clear();
            this.Close();
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
            lblAddScore.Text = "";
        }
    }
}
