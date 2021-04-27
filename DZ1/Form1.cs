using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DZ1
{
    public partial class Form1 : Form
    {

        DataSet dataSet;
        SqlDataAdapter adapter;
        SqlConnection connection;
        string conString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        string sql = "select * from Product";

        public Form1()
        {
            InitializeComponent();
            setDataSet();
        }

        private void setDataSet()
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;

            connection = new SqlConnection(conString);
            adapter = new SqlDataAdapter(sql, connection);
            new SqlCommandBuilder(adapter);
            dataSet = new DataSet();

            adapter.Fill(dataSet, "Product");
            dataGridView1.DataSource = dataSet.Tables[0];
            dataGridView1.ReadOnly = true;


        }


        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow row = dataSet.Tables[0].NewRow();
                row["title"] = TitleTextBox.Text;
                row["description"] = DescriptionTextBox.Text;
                row["idCategory"] = IDCategoryTextBox.Text;
                row["price"] = PriceTextBox.Text;
                dataSet.Tables[0].Rows.Add(row);
                adapter.Update(dataSet.Tables[0]);
                ClearTextBoxes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
                adapter.Update(dataSet.Tables[0]);
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    TitleTextBox.Text = row.Cells[1].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearTextBoxes()
        {
            IDtextBox.Text = null;
            TitleTextBox.Text = null;
            DescriptionTextBox.Text = null;
            IDCategoryTextBox.Text = null;
            PriceTextBox.Text = null;
        }
        private void IDCategoryTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }

        private void PriceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }

        private void IDtextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }
    }
}
