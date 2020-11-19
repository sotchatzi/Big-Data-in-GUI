using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Generators;

//Random util class
//stopwatch
using System.Diagnostics;
//number validation
using System.Text.RegularExpressions;


namespace Create_List_WPF
{
    ///
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        //Yield implementation
        private void generateYield_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (generateYield.IsChecked == true)
            {
                //Percentage of slow generated strings
                double slowPercentSize = 0;
                double failurePercentSize = 0;
                IGenerator generator = new YieldGenerator();
                PopulateGUI(generator, DisplayBoxYield, ElapsedTimeYield, NumberOfList, slowPercentSize, failurePercentSize);
            }
        }

        //For loop implementation
        private void generateFor_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (generateFor.IsChecked == true)
            {
                //Percentage of slow generated strings
                double slowPercentSize = 0;
                double failurePercentSize = 0;
                IGenerator generator = new ForLoopGenerator();
                PopulateGUI(generator, DisplayBoxFor, ElapsedTimeFor, NumberOfList, slowPercentSize, failurePercentSize);
            }
        }

        //yield slow implementation
        private void generateSlow1_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (generateSlow1.IsChecked == true)
            {
                //Percentage of slow generated strings
                double slowPercentSize = 0.2;
                double failurePercentSize = 0;
                IGenerator generator = new SlowGenerator();
                PopulateGUI(generator, DisplayBoxSlow1, ElapsedTimeSlow1, NumberOfList, slowPercentSize, failurePercentSize);
            }
        }

        //One by one implementation
        private void generateOneByOne_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (generateOneByOne.IsChecked == true)
            {
                double slowPercentSize = 0;
                double failurePercentSize = 0;
                new PopulateGUIOneByOne().PopulateGUI(NumberOfList, DisplayBoxOneByOne, ProgressBarOneByOne, slowPercentSize, failurePercentSize);
//                DisplayBoxOneByOne.Items.Refresh();
            }
        }

        private void generateOneByOne_UnCheckedChanged(object sender, RoutedEventArgs e)
        {
            if (generateOneByOne.IsChecked == false)
            {
                DisplayBoxOneByOne.Items.Clear();
            }
        }

        //Validate that the textbox accepts only numbers
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        //Populate the list in GUI and take the time back
        private void PopulateGUI(IGenerator generator, ListBox displayBox, TextBlock elapsedTime, TextBox NumberOfList, double slowPercentSize, double failurePercentSize)
        {
            //Start timestamp
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            //Retrieve size from the TextBox
            int size = Convert.ToInt32(NumberOfList.Text);

            //Transform percentage to number of elements
            double slowSize = slowPercentSize * size;
            double failureSize = failurePercentSize * size;

            //Display the random list
            displayBox.ItemsSource = generator.Generate(size, (int)slowSize, (int)failureSize);
            //End timestamp
            stopWatch.Stop();
            //Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            double minutesToSeconds = ts.Minutes * 60;
            //Display elapsed time
            elapsedTime.DataContext = new TextboxText() { seconds = ts.Seconds + minutesToSeconds, milliseconds = ts.Milliseconds };
        }
    }
}
