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

//Random util class
using System.IO;
//stopwatch
using System.Diagnostics;

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

            //Start timestamp
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            //One million size
            IEnumerable<ItemList> items = Generate(1000000);

            //End timestamp
            stopWatch.Stop();
            //Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            //Display random strings
            DisplayBox.ItemsSource = items;
            //Display elapsed time
            ElapsedTime.DataContext = new TextboxText() { seconds = ts.Seconds, milliseconds = ts.Milliseconds };
        }

        //for loop implementation
//        private IEnumerable<ItemList> Generate(int size)
//        {
//            List<ItemList> items = new List<ItemList>();
//            for (int i = 0; i < size; i++)
//            {
//                items.Add(new ItemList() {AnIndex = i, AString = RandomUtil.GetRandomString()});
//           }
//           return items;
//        }

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
    
    //TextboxText: elapsed time setter and getter
    public class TextboxText
    {
        public double seconds { get; set; }
        public double milliseconds { get; set; }

    }

    //ItemList: random string generator setter and getter
    public class ItemList
    {
        public string AString { get; set; }
        public int AnIndex { get; set; }
    }

    //RandomUtil: random strim generator
    static class RandomUtil
    {
        /// <summary>
        /// https://www.dotnetperls.com/random-string
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
