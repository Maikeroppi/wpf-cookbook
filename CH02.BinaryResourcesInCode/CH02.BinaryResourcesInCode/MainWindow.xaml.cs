using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CH02.BinaryResourcesInCode
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var info = Application.GetResourceStream(new Uri("books.xml", UriKind.Relative));
            var books = XElement.Load(info.Stream);
            var booklist = from book in books.Elements("Book")
                           orderby (string)book.Attribute("Author")
                           select new
                           {
                               Name = (string)book.Attribute("Name"),
                               Author = (string)book.Attribute("Author")
                           };

            foreach(var book in booklist)
            {
                _text.Text += book.ToString() + Environment.NewLine;
            }
        }
    }
}
