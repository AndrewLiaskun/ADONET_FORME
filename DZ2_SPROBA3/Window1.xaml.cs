using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DZ2_SPROBA3
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        int fromSelectedID = -1;
        string fromComboBox;
        public Window1()
        {
            InitializeComponent();
        }
        public Window1(string str) : this()
        {
            fromComboBox = str;
        }
        public Window1(string str, int id) : this()
        {
            fromComboBox = str;
            fromSelectedID = id;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (fromSelectedID == -1)
                {
                    using (DataClasses1DataContext cnt = new DataClasses1DataContext())
                    {
                        if (fromComboBox == "Book")
                        {
                            Book book = new Book() { Title = textBox2.Text };
                            cnt.Book.InsertOnSubmit(book);
                            cnt.SubmitChanges();
                        }
                        if (fromComboBox == "Sage")
                        {
                            Sage sage = new Sage() { Name = textBox2.Text, Age = DateTime.Parse(textBox3.Text) };
                            cnt.Sage.InsertOnSubmit(sage);
                            cnt.SubmitChanges();
                        }
                        if (fromComboBox == "SageBook")
                        {
                            SageBook sageBook = new SageBook() { idBook = Convert.ToInt32(textBox2.Text),idSage=Convert.ToInt32(textBox3.Text) };
                            cnt.SageBook.InsertOnSubmit(sageBook);
                            cnt.SubmitChanges();
                        }
                    }
                }
                else
                {
                    using (DataClasses1DataContext cnt = new DataClasses1DataContext())
                    {
                        if (fromComboBox == "Book")
                        {
                            var book = cnt.Book.Where(x => x.Id == fromSelectedID).FirstOrDefault();
                            book.Title = textBox2.Text;
                            cnt.SubmitChanges();
                        }
                        if (fromComboBox == "Sage")
                        {
                            var sage = cnt.Sage.Where(x => x.Id == fromSelectedID).FirstOrDefault();
                            sage.Name = textBox2.Text;
                            sage.Age =  DateTime.Parse(textBox3.Text);
                            cnt.SubmitChanges();
                        }
                        if (fromComboBox == "SageBook")
                        {
                            var sageBook = cnt.SageBook.Where(x => x.Id == fromSelectedID).FirstOrDefault();
                            sageBook.idBook = Convert.ToInt32(textBox2.Text);
                            sageBook.idSage = Convert.ToInt32(textBox3.Text);
                            cnt.SubmitChanges();
                        }
                    }
                }
                this.Close();
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (fromSelectedID == -1)
                {
                    if (fromComboBox == "Book")
                    {
                        textBox1.Visibility = Visibility.Hidden;
                        textBox3.Visibility = Visibility.Hidden;
                        lable2.Content = "Title: ";
                    }
                    if (fromComboBox == "Sage")
                    {
                        textBox1.Visibility = Visibility.Hidden;
                        lable2.Content = "Name: ";
                        lable3.Content = "Birthday: ";
                    }
                    if (fromComboBox == "SageBook")
                    {
                        textBox1.Visibility = Visibility.Hidden;
                        lable3.Content = "idSage: ";
                        lable2.Content = "idBook: ";
                    }
                }
                else
                {
                    if (fromComboBox == "Book")
                    {
                        textBox1.Visibility = Visibility.Hidden;
                        textBox3.Visibility = Visibility.Hidden;
                        lable2.Content = "Title: ";
                        using (DataClasses1DataContext cnt = new DataClasses1DataContext())
                        {
                            textBox2.Text = cnt.Book.Where(x => x.Id == fromSelectedID).Select(y => y.Title).FirstOrDefault();
                        }
                    }
                    if (fromComboBox == "Sage")
                    {
                        textBox1.Visibility = Visibility.Hidden;
                        lable2.Content = "Name: ";
                        lable3.Content = "Birthday: ";
                        using (DataClasses1DataContext cnt = new DataClasses1DataContext())
                        {

                            textBox2.Text = cnt.Sage.Where(x => x.Id == fromSelectedID).Select(y => y.Name).FirstOrDefault();
                            textBox3.Text = Convert.ToString(cnt.Sage.Where(x => x.Id == fromSelectedID).Select(y => y.Age).FirstOrDefault());
                        }
                    }
                    if (fromComboBox == "SageBook")
                    {
                        textBox1.Visibility = Visibility.Hidden;
                        lable3.Content = "idSage: ";
                        lable2.Content = "idBook: ";
                        using (DataClasses1DataContext cnt = new DataClasses1DataContext())
                        {
                            textBox2.Text = Convert.ToString(cnt.SageBook.Where(x => x.Id == fromSelectedID).Select(y => y.idBook).FirstOrDefault());
                            textBox3.Text = Convert.ToString(cnt.SageBook.Where(x => x.Id == fromSelectedID).Select(y => y.idSage).FirstOrDefault());
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
