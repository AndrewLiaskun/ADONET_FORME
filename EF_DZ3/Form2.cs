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
    public partial class Form2 : Form
    {
        string fromComboBox;
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(string txt):this()
        {
            fromComboBox = txt;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                if (fromComboBox == "Sage")
                {
                    label1.Text = "Name: ";
                    label2.Text = "Age: ";
                }  
                if (fromComboBox == "Book")
                {
                    label1.Visible = false;
                    textBox1.Visible = false;
                    label2.Text = "Title: ";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonOkay_Click(object sender, EventArgs e)
        {
            try
            {
                using (MyDbContext cnt = new MyDbContext())
                {
                    if (fromComboBox == "Sage")
                    {
                        cnt.Sages.Add(new Sage() { Name = textBox1.Text, Age = DateTime.Parse(textBox2.Text)});
                        cnt.SaveChanges();
                        this.Close();
                    }     
                    if (fromComboBox == "Book")
                    {
                        cnt.Books.Add(new Book() {  Title = textBox2.Text });
                        cnt.SaveChanges();
                        this.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
