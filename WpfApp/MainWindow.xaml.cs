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
                IGenerator generator = new YieldGenerator();
                PopulateGUI(generator, DisplayBoxYield, ElapsedTimeYield, NumberOfList);
            }
        }

        //For loop implementation
        private void generateFor_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (generateFor.IsChecked == true)
            {
                IGenerator generator = new ForLoopGenerator();
                PopulateGUI(generator, DisplayBoxFor, ElapsedTimeFor, NumberOfList);
            }
        }

        //yield slow implementation
        private void generateSlow1_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (generateSlow1.IsChecked == true)
            {
                IGenerator generator = new SlowGenerator();
                PopulateGUI(generator, DisplayBoxSlow1, ElapsedTimeSlow1, NumberOfList);
            }
        }

        //yield slow 20% implementation
        private void generateSlow20_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (generateSlow20.IsChecked == true)
            {
                IGenerator generator = new Slow20Generator();
                PopulateGUI(generator, DisplayBoxSlow20, ElapsedTimeSlow20, NumberOfList);
            }
        }

        //yield fail 20% implementation
        private void generateFail20_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (generateFail20.IsChecked == true)
            {
                IGenerator generator = new Fail20Generator();
                PopulateGUI(generator, DisplayBoxFail20, ElapsedTimeFail20, NumberOfList);
            }
        }

        //yield fail 20% slow 10% implementation
        private void generateFail20Slow10_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (generateFail20Slow10.IsChecked == true)
            {
                IGenerator generator = new Fail20Slow10Generator();
                PopulateGUI(generator, DisplayBoxFail20Slow10, ElapsedTimeFail20Slow10, NumberOfList);
            }
        }

        //yield fail 20% timeout 10% implementation
        private void generateFail20Timeout10_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (generateFail20Timeout10.IsChecked == true)
            {
                IGenerator generator = new Fail20Timesout10Generator();
                PopulateGUI(generator, DisplayBoxFail20Timeout10, ElapsedTimeFail20Timeout10, NumberOfList);
            }
        }


        //One by one implementation
        private void generateOneByOne_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (generateOneByOne.IsChecked == true)
            {
                new PopulateGUIOneByOne().PopulateGUI(NumberOfList, DisplayBoxOneByOne, ProgressBarOneByOne, ElapsedTimeOneByOne);
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
        private void PopulateGUI(IGenerator generator, ListBox displayBox, TextBlock elapsedTime, TextBox NumberOfList )
        {
            //Start timestamp
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            //Retrieve size from the TextBox
            int size = Convert.ToInt32(NumberOfList.Text);
            //Display the random list
            displayBox.ItemsSource = generator.Generate(size);
            //End timestamp
            stopWatch.Stop();
            //Get the elapsed time as a TimeSpan value.
            //test
            TimeSpan ts = stopWatch.Elapsed;

            double minutesToSeconds = ts.Minutes * 60;
            //Display elapsed time
            elapsedTime.DataContext = new TextboxText() { seconds = ts.Seconds + minutesToSeconds, milliseconds = ts.Milliseconds };
        }
    }
}
