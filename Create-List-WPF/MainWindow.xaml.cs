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
//number validation
using System.Text.RegularExpressions;


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

        }

        private void generateYield_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (generateYield.IsChecked == true)
            {
                //Start timestamp
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                //One million size
                //            IEnumerable<ItemList> items = Generate(1000000);

                //One million size and display in the GUI through yield
                //            DisplayBox.ItemsSource = GenerateYield(1000000);


                //10 million size and display in the GUI through yield
                IGenerator generator = new YieldGenerator();
                int size = Convert.ToInt32(NumberOfList.Text);
                DisplayBoxYield.ItemsSource = generator.Generate(size);

                //End timestamp
                stopWatch.Stop();
                //Get the elapsed time as a TimeSpan value.
                TimeSpan ts = stopWatch.Elapsed;

                //Display random strings
                //            DisplayBox.ItemsSource = items;
                //Display elapsed time
                ElapsedTimeYield.DataContext = new TextboxText() { seconds = ts.Seconds, milliseconds = ts.Milliseconds };
            }

        }
        //for loop implementation
        private void generateFor_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (generateFor.IsChecked == true)
            {
                //Start timestamp
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                //One million size
                //            IEnumerable<ItemList> items = Generate(1000000);

                //One million size and display in the GUI through yield
                //            DisplayBox.ItemsSource = GenerateYield(1000000);


                //10 million size and display in the GUI through yield
                IGenerator generator = new ForLoopGenerator();
                int size = Convert.ToInt32(NumberOfList.Text);
                DisplayBoxFor.ItemsSource = generator.Generate(size);



                //End timestamp
                stopWatch.Stop();
                //Get the elapsed time as a TimeSpan value.
                TimeSpan ts = stopWatch.Elapsed;

                //Display random strings
                //            DisplayBox.ItemsSource = items;
                //Display elapsed time
                ElapsedTimeFor.DataContext = new TextboxText() { seconds = ts.Seconds, milliseconds = ts.Milliseconds };
            }

        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }
}
