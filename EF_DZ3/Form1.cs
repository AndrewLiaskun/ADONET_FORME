using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EF_DZ3
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

        }

        private void DELETEtoolStripButton_Click(object sender, EventArgs e)
        {

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
                    {
                        dataGridView1.DataSource = cnt.Books.Select(x => new { ID = x.Id, Title = x.Title }).ToList();
                    }
                    if (toolStripComboBox1.Text == "Sage")
                    {
                        dataGridView1.DataSource = cnt.Sages.Select(x => new { ID = x.Id, Name = x.Name, Age = x.Age }).ToList();
                    }
                    //if (toolStripComboBox1.Text == "SageBook")
                    //{
                    //    dataGridView1.DataSource = cnt..Select(x => new { ID = x, SageID = x. }).ToList();
                    //}
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }


    }
}
