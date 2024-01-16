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
    public partial class Billing : Form
    {
        public Billing()
        {
            InitializeComponent();
            Con = new Functions();
            ShowItems();
        }
        Functions Con;

        private void ShowItems()
        {
            try
            {
                string Query = "select * from ItemTb1";
                IteamsList.DataSource = Con.GetData(Query);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

        }
        int n = 0;
        int GrdTotal = 0;

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if(QtyTb.Text == "" || PriceTb.Text == "")
            {
                MessageBox.Show("Missing Data!!!");
            }
            else
            {
                int Qte = Convert.ToInt32(QtyTb.Text);
                int Total = Convert.ToInt32(PriceTb.Text) * Qte;
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(BillDGV);
                newRow.Cells[0].Value = n + 1;
                newRow.Cells[1].Value = ItemTb.Text; 
                newRow.Cells[2].Value = PriceTb.Text;
                newRow.Cells[3].Value = QtyTb.Text;
                newRow.Cells[4].Value = "Rs " + Total;
                newRow.Cells[5].Value = BDateTn.Text;
                BillDGV.Rows.Add(newRow);
                n++;
                GrdTotal = GrdTotal + Total;
                GrdTotalLbl.Text = "Rs" + GrdTotal;

            }
        }
        int key = 0;

        private void IteamsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ItemTb.Text = IteamsList.SelectedRows[0].Cells[1].Value.ToString();
           //QtyTb.Text = IteamsList.SelectedRows[0].Cells[2].Value.ToString();
            PriceTb.Text = IteamsList.SelectedRows[0].Cells[3].Value.ToString();
            if (ItemTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(IteamsList.SelectedRows[0].Cells[0].Value.ToString());

            }
        }

        private void ExitBtn_Click_1(object sender, EventArgs e)
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

        private void BillDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Delet_Click(object sender, EventArgs e)
        {
            int rowindex = BillDGV.CurrentCell.RowIndex;
            BillDGV.Rows.RemoveAt(rowindex);
        }
    }
}
