using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant_Management_System
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
            Con = new Functions();
            ShowUsers();
        }

        Functions Con;

        private void ShowUsers()
        {
            try
            {
                string Query = "select * from UsersTb1";
                UsersList.DataSource = Con.GetData(Query);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            Regex r = new Regex(@"^[0-9]{10}$");
            if (r.IsMatch(PhoneTb.Text))
            {
                PhoneTb.BackColor = System.Drawing.Color.White;
                string[] row1 = new string[] { PhoneTb.Text };
            }
            else
            {
                PhoneTb.BackColor = System.Drawing.Color.Red;
                MessageBox.Show("Invalid Phone No");
            }
            if (NameTb.Text == "" || PasswordTb.Text == "" || GenCb.SelectedIndex == -1 || PhoneTb.Text == "" || AddTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string Name = NameTb.Text;
                    string Gender = GenCb.SelectedItem.ToString();
                    string Password = PasswordTb.Text;
                    string Phone = PhoneTb.Text;
                    string Adress = AddTb.Text;
                    string Query = "insert into UsersTb1 values('{0}','{1}','{2}','{3}','{4}')";
                    Query = string.Format(Query, Name, Gender, Password, Phone, Adress);
                    Con.SetData(Query);
                    ShowUsers();
                    MessageBox.Show("User Added!!!");

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int key = 0;

        private void UsersList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            NameTb.Text = UsersList.SelectedRows[0].Cells[1].Value.ToString();
            GenCb.Text = UsersList.SelectedRows[0].Cells[2].Value.ToString();
            PasswordTb.Text = UsersList.SelectedRows[0].Cells[3].Value.ToString();
            PhoneTb.Text = UsersList.SelectedRows[0].Cells[4].Value.ToString();
            AddTb.Text = UsersList.SelectedRows[0].Cells[5].Value.ToString();
            if (NameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(UsersList.SelectedRows[0].Cells[0].Value.ToString());

            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (NameTb.Text == "" || PasswordTb.Text == "" || GenCb.SelectedIndex == -1 || PhoneTb.Text == "" || AddTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string Name = NameTb.Text;
                    string Gender = GenCb.SelectedItem.ToString();
                    string Password = PasswordTb.Text;
                    string Phone = PhoneTb.Text;
                    string Adress = AddTb.Text;
                    string Query = "update UsersTb1 set UName = '{0}',UGen = '{1}',UPass = '{2}',UPhone = '{3}',UAdress = '{4}' where Uid = {5}";
                    Query = string.Format(Query, Name, Gender, Password, Phone, Adress,key);
                    Con.SetData(Query);
                    ShowUsers();
                    MessageBox.Show("User Updated!!!");

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string Name = NameTb.Text;
                    string Gender = GenCb.SelectedItem.ToString();
                    string Password = PasswordTb.Text;
                    string Phone = PhoneTb.Text;
                    string Adress = AddTb.Text;
                    string Query = "delete from UsersTb1 where Uid = {0}";
                    Query = string.Format(Query, key);
                    Con.SetData(Query);
                    ShowUsers();
                    MessageBox.Show("User Deleted!!!");

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void UserLbl_Click(object sender, EventArgs e)
        {
            Users Obj = new Users();
            Obj.Show();
            this.Hide();
        }

        private void ItemLbl_Click(object sender, EventArgs e)
        {
            Items Obj = new Items();
            Obj.Show();
            this.Hide();
        }

        private void CatLbl_Click(object sender, EventArgs e)
        {
            Category Obj = new Category();
            Obj.Show();
            this.Hide();
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Login Obj = new Login();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Users Obj = new Users();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Items Obj = new Items();
            Obj.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Category Obj = new Category();
            Obj.Show();
            this.Hide();
        }

        private void PhoneTb_TextChanged(object sender, EventArgs e)
        { 
            if (PhoneTb.Text.Length == 10)
            {
                PhoneTb.BackColor = System.Drawing.Color.White;
            }
            else
            {
                PhoneTb.BackColor = System.Drawing.Color.Red;
            }
        }
    }
}