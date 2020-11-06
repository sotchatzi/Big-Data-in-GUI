using System;
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
            //            IEnumerable<ItemList> items = Generate(1000000);

            //One million size and display in the GUI through yield
            //            DisplayBox.ItemsSource = GenerateYield(1000000);

            //10 million size and display in the GUI through yield
            IGenerator generator = new ForLoopGenerator();
            DisplayBox.ItemsSource = generator.Generate(1000000);

            //End timestamp
            stopWatch.Stop();
            //Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            //Display random strings
//            DisplayBox.ItemsSource = items;
            //Display elapsed time
            ElapsedTime.DataContext = new TextboxText() { seconds = ts.Seconds, milliseconds = ts.Milliseconds };
        }

        //for loop implementation


        //Generate string list through yield

    }
}
