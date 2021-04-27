using System;
using System.Collections.Generic;
using System.Drawing;
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
using System.Xml.Linq;

namespace DZ2_XML
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        XDocument document;
        public enum StoneType { precious, semiPrecious, fake }
        string updateName;
        bool findByColor = false;
        public Window1()
        {
            InitializeComponent();
        }
        public Window1(XDocument doc) : this()
        {
            document = doc;
        } 
        public Window1(XDocument doc,bool find) : this()
        {
            document = doc;
            findByColor = find;
        }
        public Window1(XDocument doc,string name) : this()
        {
            document = doc;
            updateName = name;
        }

        private void okayButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (updateName == null && findByColor==false)
                {
                    if (isColorExists(colorBox.Text)) // ТУТ звичайне додавання
                    {
                        XElement myStone = new XElement("stone", new XAttribute("name", nameBox.Text), new XElement("color", colorBox.Text),
                        new XElement("transparancy", transparancyBox.SelectedItem), new XElement("type", typeBox.SelectedItem), new XElement("description", descriptionBox.Text));
                        document.Element("stones").Add(myStone);
                        document.Save("stoneXml.xml");
                    }
                    else
                    {
                        MessageBox.Show("This color does not exist");
                    }
                }
                if(findByColor==false) //ТУТ АПДЕЙТ
                {
                    XElement element = document.Element("stones").Elements().First(x => x.Attribute("name").Value == updateName);

                    element.SetElementValue("color", colorBox.Text);
                    element.SetElementValue("transparancy", transparancyBox.SelectedItem);
                    element.SetElementValue("type", typeBox.SelectedItem);
                    element.SetElementValue("description", descriptionBox.Text);
                    document.Save("stoneXml.xml");
                }
                if (updateName == null) //ТУТ ФАЙНД
                {

                    var items = document.Element("stones").Elements().Select(x => new {
                        Name = x.Attribute("name").Value,
                        Color = ColorTranslator.FromHtml(x.Element("color").Value).Name,
                        Transparency = x.Element("transparancy").Value,
                        TypeOfStone = x.Element("type").Value,
                        Description = x.Element("description").Value
                    }).Where(x => x.Color.ToLower() == colorBox.Text.ToLower());

                    XDocument findDoc = new XDocument();
                    foreach (var item in items)
                    {
                        XElement stone = new XElement("stone", new XAttribute("name", item.Name), new XElement("color", item.Color),
                        new XElement("transparancy", item.Transparency), new XElement("type", item.TypeOfStone), new XElement("description", item.Description));
                        XElement allStones = new XElement("stones", stone);
                        findDoc.Add(allStones);      //---------------------------------       // ТУТ помилка при додаванні декілька каменюк!
                        stone = null;
                        allStones = null;
                    }
                    findDoc.Save("findStone.xml");

                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            transparancyBox.Items.Add(true);
            transparancyBox.Items.Add(false);
            foreach (var item in Enum.GetValues(typeof(StoneType)))
            {
                typeBox.Items.Add(item);
            }

            if (updateName != null)
            {
                try
                {
                    var items = document.Element("stones").Elements().Select(x => new {
                        Name = x.Attribute("name").Value,
                        Color = ColorTranslator.FromHtml(x.Element("color").Value).Name,
                        Transparency = x.Element("transparancy").Value,
                        TypeOfStone = x.Element("type").Value,
                        Description = x.Element("description").Value
                    }).Where(x => x.Name == updateName);

                    nameBox.Text = items.Select(x => x.Name).FirstOrDefault();
                    colorBox.Text = items.Select(x => x.Color).FirstOrDefault();
                    transparancyBox.SelectedItem = items.Select(x => x.Transparency).FirstOrDefault();
                    typeBox.SelectedItem = items.Select(x => x.TypeOfStone).FirstOrDefault();
                    descriptionBox.Text = items.Select(x => x.Description).FirstOrDefault();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (findByColor == true)
            {
                nameBox.IsEnabled = false;
                transparancyBox.IsEnabled = false;
                typeBox.IsEnabled = false;
                descriptionBox.IsEnabled = false;
            }

            
        }

        private void canselButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private bool isColorExists(string myColor)
        {
            myColor = myColor.ToLower();
            List<char> ls = myColor.ToList();
            ls[0] = Char.ToUpper(ls[0]);
            myColor = new string(ls.ToArray());

            return Enum.IsDefined(typeof(KnownColor), myColor);
        }
    }
}
