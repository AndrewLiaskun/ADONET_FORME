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

namespace DZ1_sproba3
{
    public partial class Form1 : Form
    {
        DataSet dataSet;
        SqlDataAdapter adapter;
        SqlConnection connection;
        SqlCommandBuilder builder;
        string conString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
        string sqlProduct = "select *, 'Delete' as [Delete] from Product";
        string sqlCategory = "select *, 'Delete' as [Delete] from Category";
        bool newRowAdding = false;


        public Form1()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void ReloadData()
        {
            try
            {
                if (toolStripComboBox1.Text == "Product")
                {
                    dataSet.Tables["Product"].Clear();
                    adapter.Fill(dataSet, "Product");
                    dataGridView1.DataSource = dataSet.Tables["Product"];
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                        dataGridView1[dataGridView1.Columns.Count - 1, i] = linkCell;
                    }
                }
                else if (toolStripComboBox1.Text == "Category")
                {
                    dataSet.Tables["Category"].Clear();
                    adapter.Fill(dataSet, "Category");
                    dataGridView1.DataSource = dataSet.Tables["Category"];
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                        dataGridView1[dataGridView1.Columns.Count - 1, i] = linkCell;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private void toolStripComboBox1_TextChanged(object sender, EventArgs e)
        {
            if (toolStripComboBox1.Text == "Product")
            {
                dataGridView1.DataSource = null;
                toolStripComboBox1.Text = "Product";
                connection = new SqlConnection(conString);
                adapter = new SqlDataAdapter(sqlProduct, connection);
                builder = new SqlCommandBuilder(adapter);

                builder.GetInsertCommand();
                builder.GetDeleteCommand();
                builder.GetUpdateCommand();

                dataSet = new DataSet();
                adapter.Fill(dataSet, "Product");
                dataGridView1.DataSource = dataSet.Tables["Product"];
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[dataGridView1.Columns.Count - 1, i] = linkCell;
                }

            }
            else if(toolStripComboBox1.Text == "Category")
            {
                dataGridView1.DataSource = null;
                toolStripComboBox1.Text = "Category";
                connection = new SqlConnection(conString);
                adapter = new SqlDataAdapter(sqlCategory, connection);
                builder = new SqlCommandBuilder(adapter);

                builder.GetInsertCommand();
                builder.GetDeleteCommand();
                builder.GetUpdateCommand();

                dataSet = new DataSet();
                adapter.Fill(dataSet, "Category");
                dataGridView1.DataSource = dataSet.Tables["Category"];
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[dataGridView1.Columns.Count - 1, i] = linkCell;
                }
            }
        }


        private void toolStripUpdate_Click(object sender, EventArgs e)
        {
            ReloadData();
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    newRowAdding = true;
                    int lastRow = dataGridView1.Rows.Count - 2;
                    DataGridViewRow row = dataGridView1.Rows[lastRow];
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[dataGridView1.Columns.Count - 1, lastRow] = linkCell;

                    row.Cells["Delete"].Value = "Insert";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dataGridView1.Columns.Count - 1)
                {
                    string task = dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.Columns.Count - 1].Value.ToString();
                    if (task == "Delete")
                    {
                        int rowIndex = e.RowIndex;
                        dataGridView1.Rows.RemoveAt(rowIndex);
                        if (toolStripComboBox1.Text == "Product")
                        {
                            dataSet.Tables["Product"].Rows[rowIndex].Delete();
                            adapter.Update(dataSet, "Product");
                        }
                        else if (toolStripComboBox1.Text == "Category")
                        {
                            dataSet.Tables["Category"].Rows[rowIndex].Delete();
                            adapter.Update(dataSet, "Category");
                        }
                    }
                    else if (task == "Insert")
                    {
                        int rowIndex = dataGridView1.Rows.Count - 2;
                        if (toolStripComboBox1.Text == "Product")
                        {
                            DataRow row = dataSet.Tables["Product"].NewRow();

                            row["title"] = dataGridView1.Rows[rowIndex].Cells["title"].Value;
                            row["description"] = dataGridView1.Rows[rowIndex].Cells["description"].Value;
                            row["idCategory"] = dataGridView1.Rows[rowIndex].Cells["idCategory"].Value;
                            row["price"] = dataGridView1.Rows[rowIndex].Cells["price"].Value;

                            dataSet.Tables["Product"].Rows.Add(row);
                            dataSet.Tables["Product"].Rows.RemoveAt(dataSet.Tables["Product"].Rows.Count - 1);
                            dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                            dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.Columns.Count - 1].Value = "Delete";
                            adapter.Update(dataSet, "Product");

                        }else if(toolStripComboBox1.Text == "Category")
                        {
                            DataRow row = dataSet.Tables["Category"].NewRow();

                            row["name"] = dataGridView1.Rows[rowIndex].Cells["name"].Value;


                            dataSet.Tables["Category"].Rows.Add(row);
                            dataSet.Tables["Category"].Rows.RemoveAt(dataSet.Tables["Category"].Rows.Count - 1);
                            dataGridView1.Rows.RemoveAt(dataGridView1.Rows.Count - 2);
                            dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.Columns.Count - 1].Value = "Delete";
                            adapter.Update(dataSet, "Category");
                        }
                        ReloadData();
                        newRowAdding = false;

                    }
                    else if (task == "Update")
                    {
                        int r = e.RowIndex;
                        if (toolStripComboBox1.Text == "Product")
                        {
                            dataSet.Tables["Product"].Rows[r]["title"] = dataGridView1.Rows[r].Cells["title"].Value;
                            dataSet.Tables["Product"].Rows[r]["description"] = dataGridView1.Rows[r].Cells["description"].Value;
                            dataSet.Tables["Product"].Rows[r]["idCategory"] = dataGridView1.Rows[r].Cells["idCategory"].Value;
                            dataSet.Tables["Product"].Rows[r]["price"] = dataGridView1.Rows[r].Cells["price"].Value;

                            adapter.Update(dataSet, "Product");
                            dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.Columns.Count - 1].Value = "Delete";
                        }
                        else if (toolStripComboBox1.Text == "Category")
                        {
                            dataSet.Tables["Category"].Rows[r]["name"] = dataGridView1.Rows[r].Cells["name"].Value;

                            adapter.Update(dataSet, "Category");
                            dataGridView1.Rows[e.RowIndex].Cells[dataGridView1.Columns.Count - 1].Value = "Delete";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (newRowAdding == false)
                {
                    int rowIndex = dataGridView1.SelectedCells[0].RowIndex;
                    DataGridViewRow editingRow = dataGridView1.Rows[rowIndex];
                    DataGridViewLinkCell linkCell = new DataGridViewLinkCell();
                    dataGridView1[dataGridView1.Columns.Count - 1, rowIndex] = linkCell;

                    editingRow.Cells["Delete"].Value = "Update";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(contorol_PressKey);
            if(toolStripComboBox1.Text == "Product")
            {
                if(dataGridView1.CurrentCell.ColumnIndex==4 || dataGridView1.CurrentCell.ColumnIndex == 5)
                {
                    TextBox text = e.Control as TextBox;
                    if (text != null)
                        e.Control.KeyPress += new KeyPressEventHandler(contorol_PressKey);
                }
            }
        }

        private void contorol_PressKey(object obj,KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }
    }
}
