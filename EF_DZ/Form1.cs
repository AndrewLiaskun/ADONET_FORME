using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EF_DZ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ADDtoolStripButton_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
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

        }

        private void DELETEtoolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void REFRESHtoolStripButton_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_TextChanged(object sender, EventArgs e)
        {
            using (MyDbContext cnt = new MyDbContext())
            {
                try
                {
                    if (toolStripComboBox1.Text == "Book")
                    {
                        dataGridView1.DataSource = cnt.Books.Select(x => new { ID = x.Id, Title = x.Title }).ToList();
                    }
                    if (toolStripComboBox1.Text == "Sage")
                    {
                        dataGridView1.DataSource = cnt.Sages.Select(x => new { ID = x.Id, Name = x.Name,Age=x.Age.ToShortDateString() }).ToList();
                    }
                    if (toolStripComboBox1.Text == "SageBook")
                    {
                        //dataGridView1.DataSource = cnt.SageBooks.Select(x => new { ID = x.Id, SageID = x. }).ToList();
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }

            
        }
    }
}
