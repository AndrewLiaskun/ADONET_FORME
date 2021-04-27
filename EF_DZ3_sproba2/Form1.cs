using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EF_DZ3_sproba2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ADDtoolStripButton_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(toolStripComboBox1.Text);
            form.ShowDialog();
            myRefresh();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                toolStripComboBox1.Text = "Book";
                using (MyDbContext cnt = new MyDbContext())
                {
                    dataGridView1.DataSource = cnt.Books.Select(x => new { ID = x.Id, Title = x.Title }).ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void UPDATEtoolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (toolStripComboBox1.Text == "Book")
                {
                    int findID = Convert.ToInt32(dataGridView1.SelectedCells[0].Value);
                    Form2 form = new Form2(toolStripComboBox1.Text, findID);
                    form.ShowDialog();
                    myRefresh();
                }
                if (toolStripComboBox1.Text == "Sage")
                {
                    
                    int findID = Convert.ToInt32(dataGridView1.SelectedCells[0].Value);
                    Form2 form = new Form2(toolStripComboBox1.Text, findID);
                    form.ShowDialog();
                    myRefresh();
                }
                if (toolStripComboBox1.Text == "SageBook")
                {
                    int selectedRowIndex =dataGridView1.SelectedCells[0].RowIndex;
                    var selectedRow = dataGridView1.Rows[selectedRowIndex];
                    int BookID = Convert.ToInt32(selectedRow.Cells[0].Value);
                    int SageID = Convert.ToInt32(selectedRow.Cells[1].Value);
                    Form2 form = new Form2(toolStripComboBox1.Text, BookID, SageID);
                    form.ShowDialog();
                    myRefresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
         
        }

        private void DELETEtoolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (MyDbContext cnt = new MyDbContext())
                {
                    if (toolStripComboBox1.Text == "Book")
                    {
                        if (dataGridView1.SelectedCells.Count > 0)
                        {
                            int findID = Convert.ToInt32(dataGridView1.SelectedCells[0].Value);
                            var res = cnt.Books.Where(x => x.Id == findID).FirstOrDefault();
                            cnt.Books.Remove(res);
                            cnt.SaveChanges();
                            myRefresh();
                        }

                    }
                    if (toolStripComboBox1.Text == "Sage")
                    {
                        int findID = Convert.ToInt32(dataGridView1.SelectedCells[0].Value);
                        var res = cnt.Sages.Where(x => x.Id == findID).FirstOrDefault();
                        cnt.Sages.Remove(res);
                        cnt.SaveChanges();
                        myRefresh();
                    }
                    if (toolStripComboBox1.Text == "SageBook")
                    {                        
                        int BookTitle = Convert.ToInt32(dataGridView1.SelectedCells[0].Value);
                        int SageName = Convert.ToInt32(dataGridView1.SelectedCells[1].Value);
                        Book bToDelete = cnt.Books.First(x => x.Id == BookTitle);
                        Sage sToDelete = cnt.Sages.First(x => x.Id == SageName);
                        sToDelete.Books.Remove(bToDelete);
                        cnt.SaveChanges();
                        myRefresh();
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void toolStripComboBox1_TextChanged(object sender, EventArgs e)
        {
            myRefresh();
        }
        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            myRefresh();
        }
        private void myRefresh()
        {
            using (MyDbContext cnt = new MyDbContext())
            {
                try
                {
                    if (toolStripComboBox1.Text == "Book")
                        dataGridView1.DataSource = cnt.Books.Select(x => new { ID = x.Id, Title = x.Title }).ToList();
                    
                    if (toolStripComboBox1.Text == "Sage")
                        dataGridView1.DataSource = cnt.Sages.Select(x => new { ID = x.Id, Name = x.Name, Age = x.Age }).ToList();

                    if (toolStripComboBox1.Text == "SageBook")
                        dataGridView1.DataSource = cnt.Sages.SelectMany(x => x.Books.Select(y => new { BookID = y.Id, SageId = x.Id })).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


    }
}
