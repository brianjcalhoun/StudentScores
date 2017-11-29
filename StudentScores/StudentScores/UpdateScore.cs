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
    public partial class UpdateScore : Form
    {
        public UpdateScore()
        {
            InitializeComponent();
        }

        private int updatedScore;

        public int ScoreUpdate
        {
            get
            {
                return updatedScore;
            }
            set
            {
                updatedScore = value;
            }
        }

        public int updateScore()
            //returns updated score to form
        {
            this.ShowDialog();
            return ScoreUpdate;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
            //add score value to text box
        {
            int s = 0;

            if (Int32.TryParse(txtScore.Text, out s))
            {
                if (s <= 100 && s >= 0)
                {
                    ScoreUpdate = Convert.ToInt32(txtScore.Text);
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
            //allows only numbers and backspace
        {
            e.Handled = !(char.IsNumber(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void txtScore_TextChanged(object sender, EventArgs e)
            //hides label direction when text is entered
        {
            TextBox tb = sender as TextBox;
            lblUpdateScore.Text = "";
        }
    }
}
