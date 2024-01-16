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
    public partial class Category : Form
    {
        Functions Con;

        public Category()
        {
            InitializeComponent();
            Con = new Functions();
            ShowCategories();
        }
        private void ShowCategories()
        {
            try
            {
                string Query = "select * from CategoryTb1";
                CategoriesList.DataSource = Con.GetData(Query);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }
        private void AddBtn_Click_1(object sender, EventArgs e)
        {
            if (CatNameTb.Text == "" || DescTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string Category = CatNameTb.Text;
                    string Desc = DescTb.Text;
                    string Query = "insert into CategoryTb1 values('{0}','{1}')";
                    Query = string.Format(Query, Category, Desc);
                    Con.SetData(Query);
                    ShowCategories();
                    MessageBox.Show("Cotegory Added!!!");

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        int key = 0;
        private void CategoriesList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CatNameTb.Text = CategoriesList.SelectedRows[0].Cells[1].Value.ToString();
            DescTb.Text = CategoriesList.SelectedRows[0].Cells[2].Value.ToString();
            if (CatNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(CategoriesList.SelectedRows[0].Cells[0].Value.ToString());

            }
        }

        private void EditBtn_Click(object sender, EventArgs e)
        {
            if (CatNameTb.Text == "" || DescTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                try
                {
                    string Category = CatNameTb.Text;
                    string Desc = DescTb.Text;
                    string Query = "Update CategoryTb1 set CatName = '{0}',CatDesc = '{1}' where CatCode = {2}";
                    Query = string.Format(Query, Category, Desc, key);
                    Con.SetData(Query);
                    ShowCategories();
                    MessageBox.Show("Cotegory Update!!!");

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
                    string Category = CatNameTb.Text;
                    string Desc = DescTb.Text;
                    string Query = "Delete from CategoryTb1 where CatCode = {0}";
                    Query = string.Format(Query, key);
                    Con.SetData(Query);
                    ShowCategories();
                    MessageBox.Show("Cotegory Deleted!!!");

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void UserLbl_Click_1(object sender, EventArgs e)
        {
            Users Obj = new Users();
            Obj.Show();
            this.Hide();
        }

        private void ItemLbl_Click_1(object sender, EventArgs e)
        {
            Items Obj = new Items();
            Obj.Show();
            this.Hide();
        }

        private void CatLbl_Click_1(object sender, EventArgs e)
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
    }
}   
