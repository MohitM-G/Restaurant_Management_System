﻿using System;
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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            Con = new Functions();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }
        Functions Con;

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if(UnameTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else if(UnameTb.Text == "Mohit" &&  PasswordTb.Text == "Admin")
            {
                Users Obj = new Users();
                Obj.Show();
                this.Hide();
            }
            else
            {
                string Query = "select * from UsersTb1 where UName = '{0}' and UPass = '{1}' ";
                Query = string.Format(Query, UnameTb.Text, PasswordTb.Text);
                DataTable dt = Con.GetData(Query);
                if(dt.Rows.Count == 0) 
                {
                    MessageBox.Show("Invalid Uname & Pass!!!!!!");
                }
                else
                {
                    Billing Obj = new Billing();
                    Obj.Show();
                    this.Hide();
                }

            }
        }
    }
}
