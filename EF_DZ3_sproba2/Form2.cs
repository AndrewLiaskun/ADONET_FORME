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
    public partial class Form2 : Form
    {
        string fromComboBox;
        int toSearch = -1;
        int toSearchSageBook=-1;
        Sage s;
        Book b;
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(string txt):this()
        {
            fromComboBox = txt;
        }  
        public Form2(string txt,int search):this()
        {
            fromComboBox = txt;
            toSearch = search;
        }    
        public Form2(string txt,int search,int search2):this()
        {
            fromComboBox = txt;
            toSearch = search;
            toSearchSageBook = search2;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                if (toSearch == -1)
                {
                    if (fromComboBox == "Sage")
                    {
                        label1.Text = "Name: ";
                        label2.Text = "Age: ";
                        comboBox1.Visible = false;
                        comboBox2.Visible = false;
                    }
                    if (fromComboBox == "Book")
                    {
                        label1.Visible = false;
                        textBox1.Visible = false;
                        label2.Text = "Title: ";
                        comboBox1.Visible = false;
                        comboBox2.Visible = false;
                    }
                    if (fromComboBox == "SageBook")
                    {
                        label1.Text = "Book: ";
                        label2.Text = "Sage: ";

                        textBox1.Visible = false;
                        textBox2.Visible = false;
                        using (MyDbContext cnt = new MyDbContext())
                        {
                            comboBox1.DataSource = cnt.Books.Select(x => x.Id).ToList();
                            comboBox2.DataSource = cnt.Sages.Select(x => x.Id).ToList();
                        }
                    }
                }
                else
                {
                    using (MyDbContext cnt = new MyDbContext())
                    {
                        if (fromComboBox == "Sage")
                        {
                            label1.Text = "Name: ";
                            label2.Text = "Age: ";
                            s = cnt.Sages.First(x => x.Id == toSearch);
                            textBox1.Text = s.Name;
                            textBox2.Text = Convert.ToString(s.Age.ToShortDateString());
                            comboBox1.Visible = false;
                            comboBox2.Visible = false;
                        }
                        if (fromComboBox == "Book")
                        {
                            label1.Visible = false;
                            textBox1.Visible = false;
                            label2.Text = "Title: ";
                            b = cnt.Books.First(x => x.Id == toSearch);
                            textBox2.Text = b.Title;
                            comboBox1.Visible = false;
                            comboBox2.Visible = false;
                        }
                        if (fromComboBox == "SageBook")
                        {
                            label1.Text = "Book: ";
                            label2.Text = "Sage: ";
                            textBox1.Visible = false;
                            textBox2.Visible = false;

                            comboBox1.DataSource = cnt.Books.Select(x => x.Id).ToList();
                            comboBox2.DataSource = cnt.Sages.Select(x => x.Id).ToList();
                            comboBox1.Text = toSearch.ToString();
                            comboBox2.Text = toSearchSageBook.ToString();
                        }
                    }
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
                    if (toSearch == -1)
                    {
                        if (fromComboBox == "Sage")
                        {
                            cnt.Sages.Add(new Sage() { Name = textBox1.Text, Age = DateTime.Parse(textBox2.Text) });
                            cnt.SaveChanges();
                            this.Close();
                        }
                        if (fromComboBox == "Book")
                        {
                            cnt.Books.Add(new Book() { Title = textBox2.Text });
                            cnt.SaveChanges();
                            this.Close();
                        }
                        if (fromComboBox == "SageBook")
                        {
                            int bID = Convert.ToInt32(comboBox1.Text);
                            int sID = Convert.ToInt32(comboBox2.Text);
                            Book b = cnt.Books.First(x => x.Id == bID);
                            Sage s = cnt.Sages.First(x => x.Id == sID);
                            s.Books.Add(b);
                            cnt.SaveChanges();
                            this.Close();
                        }
                    }
                    else
                    {
                        if (fromComboBox == "Sage")
                        {
                            s = cnt.Sages.First(x => x.Id == toSearch);
                            s.Name = textBox1.Text;
                            s.Age = DateTime.Parse(textBox2.Text);
                            cnt.SaveChanges();
                            this.Close();
                        }
                        if (fromComboBox == "Book")
                        {
                            b = cnt.Books.First(x => x.Id == toSearch);
                            b.Title = textBox2.Text;
                            cnt.SaveChanges();
                            this.Close();
                        }
                        if (fromComboBox == "SageBook")
                        {
                            int bID = Convert.ToInt32(comboBox1.Text);
                            int sID = Convert.ToInt32(comboBox2.Text);
                            cnt.Sages.Find(toSearchSageBook).Books.Remove(cnt.Books.Find(toSearch));
                            cnt.Sages.Find(sID).Books.Add(cnt.Books.Find(bID));
                            cnt.SaveChanges();
                            this.Close();
                        }
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
