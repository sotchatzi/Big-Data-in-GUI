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

using System.IO;

namespace Create_List_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // time stamp 1
            
            //One million size
            IEnumerable<ItemList> items = Generate(1000000);

            // time stamp 2


           DisplayBox.ItemsSource = items;
        }

        private IEnumerable<ItemList> Generate(int size)
        {
            List<ItemList> items = new List<ItemList>();
            for (int i = 0; i < size; i++)
            {
                items.Add(new ItemList() {AnIndex = i, AString = RandomUtil.GetRandomString()});
            }

            return items;
        }
    }

    public class ItemList
    {
        public string AString { get; set; }
        public int AnIndex { get; set; }
    }

    static class RandomUtil
    {
        /// https://www.dotnetperls.com/random-string
        /// <summary>
        /// Get random string of 11 characters.
        /// </summary>
        /// <returns>Random string.</returns>
        public static string GetRandomString()
        {
            string path = System.IO.Path.GetRandomFileName();
            path = path.Replace(".", ""); // Remove period.
            return path;
        }
    }
}
