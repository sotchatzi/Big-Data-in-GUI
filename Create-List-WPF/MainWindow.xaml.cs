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
            int i;
            List<ItemList> items = new List<ItemList>();
            for (i = 0; i < 1000000; i++)
            {
                //                items.Add(new ItemList() { AString = i + " " +   RandomUtil.GetRandomString() });
                items.Add(new ItemList() { AnIndex = i, AString = RandomUtil.GetRandomString() });
                DisplayBox.ItemsSource = items;
            }


           // DisplayBox.ItemsSource = items;
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
