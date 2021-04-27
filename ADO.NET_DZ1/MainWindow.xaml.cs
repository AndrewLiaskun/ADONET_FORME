using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

namespace ADO.NET_DZ1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection conn;
        SqlDataAdapter adapter;
        DataSet dataSet;

        public MainWindow()
        {
            InitializeComponent();
            SelectData();
        }

        private void FillButton_Click(object sender, RoutedEventArgs e)
        {
            SelectData();
        }

        void SelectData()
        {
            string conString = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            conn = new SqlConnection(conString);
            adapter = new SqlDataAdapter("select * from Product", conn);
            new SqlCommandBuilder(adapter);
            dataSet = new DataSet();
            adapter.Fill(dataSet, "Product");
            dataGrid.DataContext = dataSet.DefaultViewManager;

        }
    }
}
