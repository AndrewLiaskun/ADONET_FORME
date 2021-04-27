using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
using System.Xml.Linq;

namespace DZ2_XML
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        XDocument stoneDocument;
        public enum StoneType { precious,semiPrecious,fake}
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!File.Exists("stoneXml.xml"))
                {
                    XElement ruby = new XElement("stone", new XAttribute("name", "Ruby"), new XElement("color", Colors.Red),
                        new XElement("transparancy", true), new XElement("type", StoneType.precious), new XElement("description", "Red precious stone"));

                    XElement emerald = new XElement("stone", new XAttribute("name", "Emerald"), new XElement("color", Colors.Green),
                        new XElement("transparancy", true), new XElement("type", StoneType.precious), new XElement("description", "Green precious stone"));

                    XElement malachit = new XElement("stone", new XAttribute("name", "Malachit"), new XElement("color", Colors.Green),
                        new XElement("transparancy", false), new XElement("type", StoneType.semiPrecious), new XElement("description", "Green semi precious stone"));

                    XElement fakeMalachit = new XElement("stone", new XAttribute("name", "Malachit"), new XElement("color", Colors.Green),
                      new XElement("transparancy", false), new XElement("type", StoneType.fake), new XElement("description", "Green fake semi precious stone"));

                    XElement stones = new XElement("stones", ruby, emerald, malachit, fakeMalachit);

                    stoneDocument = new XDocument();
                    stoneDocument.Add(stones);
                    stoneDocument.Save("stoneXml.xml");
                }
                else
                {
                    stoneDocument = XDocument.Load("stoneXml.xml");

                    Refresh();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Refresh()
        {

            var items = stoneDocument.Element("stones").Elements().Select(x => new {
                Name = x.Attribute("name").Value,
                Color = ColorTranslator.FromHtml(x.Element("color").Value).Name,
                Trasparancy = x.Element("transparancy").Value,
                Type = x.Element("type").Value,
                Descriptio = x.Element("description").Value
            });
            dataGrid.ItemsSource = items;
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1(stoneDocument);
            window1.ShowDialog();
            Refresh();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            var findName = new DataGridCellInfo(dataGrid.SelectedItem, dataGrid.Columns[0]);
            var content = findName.Column.GetCellContent(findName.Item) as TextBlock;
            Window1 window1 = new Window1(stoneDocument, content.Text);
            window1.ShowDialog();
            Refresh();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var findName = new DataGridCellInfo(dataGrid.SelectedItem, dataGrid.Columns[0]);
                var content = findName.Column.GetCellContent(findName.Item) as TextBlock;
                stoneDocument.Element("stones").Elements("stone").Where(x => x.Attribute("name").Value == content.Text).FirstOrDefault().Remove();
                stoneDocument.Save("stoneXml.xml");
                Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void findButton_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1(stoneDocument, true);
            window1.ShowDialog();

            XDocument findStone = XDocument.Load("findStone.xml");

            var items = findStone.Element("stones").Elements().Select(x => new {
                Name = x.Attribute("name").Value,
                Color = ColorTranslator.FromHtml(x.Element("color").Value).Name,
                Trasparancy = x.Element("transparancy").Value,
                Type = x.Element("type").Value,
                Descriptio = x.Element("description").Value
            });
            dataGrid.ItemsSource = items;
        }
    }
}
