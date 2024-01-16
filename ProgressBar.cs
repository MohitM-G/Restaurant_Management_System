using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant_Management_System
{
    public partial class ProgressBar : Form
    {
        public ProgressBar()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.MyProgress.Increment(5);

            if (MyProgress.Value >= MyProgress.Maximum)
            {
                timer1.Stop();
                this.Hide();
                Login Obj = new Login();
                Obj.Show();
            }
        }

        private void ProgressBar_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
