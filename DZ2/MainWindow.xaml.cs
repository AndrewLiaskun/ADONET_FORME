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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DZ2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                using (DataClasses1DataContext cnt = new DataClasses1DataContext())
                {
                    dataGrid.ItemsSource = cnt.Book.Select(x => new { ID=x.Id, Title = x.Title });
                    comboBox.Text = "Book";                    
                }
            }
            catch (Exception)
            {

                throw;
            }

            
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Window1 window = new Window1(comboBox.Text);
                window.ShowDialog();
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var findID = new DataGridCellInfo(dataGrid.SelectedItem, dataGrid.Columns[0]);
                var content = findID.Column.GetCellContent(findID.Item) as TextBlock;
                Window1 window = new Window1(comboBox.Text, Convert.ToInt32(content.Text));
                window.ShowDialog();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (DataClasses1DataContext cnt = new DataClasses1DataContext())
                {
                    if (comboBox.Text == "Book")
                    {
                        var findID = new DataGridCellInfo(dataGrid.SelectedItem, dataGrid.Columns[0]);
                        var content = findID.Column.GetCellContent(findID.Item) as TextBlock;
                        var res = cnt.GetTable<Book>().OrderByDescending(x => x.Id == Convert.ToInt32(content.Text)).FirstOrDefault();
                        cnt.Book.DeleteOnSubmit(res);
                        cnt.SubmitChanges();
                    }if (comboBox.Text == "Sage")
                    {
                        var findID = new DataGridCellInfo(dataGrid.SelectedItem, dataGrid.Columns[0]);
                        var content = findID.Column.GetCellContent(findID.Item) as TextBlock;
                        var res = cnt.GetTable<Sage>().OrderByDescending(x => x.Id == Convert.ToInt32(content.Text)).FirstOrDefault();
                        cnt.Sage.DeleteOnSubmit(res);
                        cnt.SubmitChanges();
                    }if (comboBox.Text == "SageBook")
                    {
                        var findID = new DataGridCellInfo(dataGrid.SelectedItem, dataGrid.Columns[0]);
                        var content = findID.Column.GetCellContent(findID.Item) as TextBlock;
                        var res = cnt.GetTable<SageBook>().OrderByDescending(x => x.Id == Convert.ToInt32(content.Text)).FirstOrDefault();
                        cnt.SageBook.DeleteOnSubmit(res);
                        cnt.SubmitChanges();
                    }
                    
                } 
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
        private void Refresh()
        {
            try
            {
                using (DataClasses1DataContext cnt = new DataClasses1DataContext())
                {
                    if (comboBox.Text == "Book")
                    {
                        dataGrid.ItemsSource = null;
                        dataGrid.Items.Clear();
                        dataGrid.ItemsSource = cnt.Book.Select(x => new { ID = x.Id, Title = x.Title });
                    }
                    if (comboBox.Text == "Sage")
                    {
                        dataGrid.ItemsSource = null;
                        dataGrid.Items.Clear();                        
                        dataGrid.ItemsSource = cnt.Sage.Select(x => new { ID = x.Id, Name = x.Name, Age = x.Age });
                    }
                        
                    if (comboBox.Text == "SageBook")
                    {
                        dataGrid.ItemsSource = null;
                        dataGrid.Items.Clear();
                        dataGrid.ItemsSource = cnt.SageBook.Select(x => new { id=x.Id,idSage = x.idSage, idBook = x.idBook });
                    }
                        
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }


    }
}
