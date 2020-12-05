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
using System.IO;
using System.Windows.Documents;

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
                PopulateGUIcul(generator, DisplayBoxYield, ElapsedTimeYield, NumberOfList, getFail, TimeDelayEstimate, NormalEstimate);
            }
        }

        //For loop implementation
        private void generateFor_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (generateFor.IsChecked == true)
            {
                IGenerator generator = new ForLoopGenerator();
                PopulateGUIcul(generator, DisplayBoxFor, ElapsedTimeFor, NumberOfList, getFail, TimeDelayEstimate, NormalEstimate);
            }
        }

        //yield slow implementation
        private void generateSlow1_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (generateSlow1.IsChecked == true)
            {
                IGenerator generator = new SlowGenerator();
                PopulateGUIcul(generator, DisplayBoxSlow1, ElapsedTimeSlow1, NumberOfList, getFail, TimeDelayEstimate, NormalEstimate);
            }
        }

        //yield slow 20% implementation
        private void generateSlow20_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (generateSlow20.IsChecked == true)
            {
                IGenerator generator = new Slow20Generator();
                PopulateGUIcul(generator, DisplayBoxSlow20, ElapsedTimeSlow20, NumberOfList, getFail, TimeDelayEstimate, NormalEstimate);
            }
        }

        //yield fail 20% implementation
        private void generateFail20_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (generateFail20.IsChecked == true)
            {
                IGenerator generator = new Fail20Generator();
                PopulateGUIcul(generator, DisplayBoxFail20, ElapsedTimeFail20, NumberOfList, getFail, TimeDelayEstimate, NormalEstimate);
            }
        }

        //yield fail 20% slow 10% implementation
        private void generateFail20Slow10_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (generateFail20Slow10.IsChecked == true)
            {
                IGenerator generator = new Fail20Slow10Generator();
                PopulateGUIcul(generator, DisplayBoxFail20Slow10, ElapsedTimeFail20Slow10, NumberOfList, getFail, TimeDelayEstimate, NormalEstimate);
            }
        }

        //yield Normal 70 fail 20% slow 10% implementation
        private void generateNormal70Fail20Slow10_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (generateNormal70Fail20Slow10.IsChecked == true)
            {
                IGenerator generator = new Normal70Fail20Slow10();
                PopulateGUIcul(generator, DisplayBoxNormal70Fail20Slow10, ElapsedTimeNormal70Fail20Slow10, NumberOfList, getFail, TimeDelayEstimate, NormalEstimate);
            }
        }

        //Generator which user defines slow and fail
        private void generateSlowFail_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (generateSlowFail.IsChecked == true)
            {
                int slowPercentageSize = Convert.ToInt32(percentageSlow.Text);
                int failPercentageSize = Convert.ToInt32(percentageFail.Text);
                IGenerator generator = new FailSlowGenerator(failPercentageSize, slowPercentageSize);
                PopulateGUIcul(generator, DisplayBoxSlowFail, ElapsedTimeSlowFail, NumberOfList, getFail, TimeDelayEstimate, NormalEstimate);
            }
        }

        //Generator which user defines no overlap slow and fail
        private void generateSlowFailNoOverlap_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (generateSlowFailNoOverlap.IsChecked == true)
            {
                int slowPercentageNoOverlapSize = Convert.ToInt32(percentageSlow.Text);
                int failPercentageNoOverlapSize = Convert.ToInt32(percentageFail.Text);
                IGenerator generator = new UserDefinedFailSlowGenerator(failPercentageNoOverlapSize, slowPercentageNoOverlapSize);
                PopulateGUIcul(generator, DisplayBoxSlowFailNoOverlap, ElapsedTimeSlowFailNoOverlap, NumberOfList, getFail, TimeDelayEstimate, NormalEstimate);
            }
        }

        //One by one implementation
        private void generateOneByOne_CheckedChanged(object sender, RoutedEventArgs e)
        {
            if (generateOneByOne.IsChecked == true)
            {
                new PopulateGUIOneByOne().PopulateGUI(NumberOfList, DisplayBoxOneByOne, ProgressBarOneByOne);//, ElapsedTimeOneByOne);
//                DisplayBoxOneByOne.Items.Refresh();
            }
        }

        private void generateOneByOne_UnCheckedChanged(object sender, RoutedEventArgs e)
        {
            if (generateOneByOne.IsChecked == false)
            {
                DisplayBoxOneByOne.Items.Clear();
                NormalEstimate.DataContext = new MatrixText() { number = 0 };
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            getFail.DataContext = new MatrixText() { number = 0 };
            TimeDelayEstimate.DataContext = new MatrixText() { number = 0 };
            NormalEstimate.DataContext = new MatrixText() { number = 0 };
            //OperateTimeEstimate.DataContext = new MatrixText() { number = 0 };
        }

        //Validate that the textbox accepts only numbers
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Performance_Click(object sender, RoutedEventArgs e)
        {

            string textFile = @"C:\Users\DELL\source\repos\sotchatzi\Big-Data-in-GUI\PerformanceTests\bin\Debug\netcoreapp3.1\reportTime.txt";
            FileStream fs;
            if (File.Exists(textFile))
            {
                fs = new FileStream(textFile, FileMode.Open, FileAccess.Read);
                using (fs)
                {
                    TextRange text = new TextRange(richTextBox1.Document.ContentStart, richTextBox1.Document.ContentEnd);
                    text.Load(fs, DataFormats.Text);
                }

            }
        }

        /*
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
            TimeSpan ts = stopWatch.Elapsed;

            double totalMilliseconds = ts.TotalMilliseconds * 0.001;

            //double minutesToSeconds = ts.Minutes * 60;
            //Display elapsed time
            //Display Seconds
            elapsedTime.DataContext = totalMilliseconds;
            //elapsedTime.DataContext = new TextboxText() { seconds = ts.Seconds + minutesToSeconds, milliseconds = ts.Milliseconds };
        }
        */


        //PopulateGUI for list being generated where the percentage of times out and failures are defined by the user
        private void PopulateGUIcul(IGenerator generator, ListBox displayBox, TextBlock elapsedTime, TextBox NumberOfList, TextBlock getFail, TextBlock getSlow, TextBlock getNormal)
        {   //TextBox percentageSlow, TextBox percentageFail
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
            TimeSpan ts = stopWatch.Elapsed;

            //Take milliseconds and transform it to seconds
            double totalMilliseconds = ts.TotalMilliseconds * 0.001;
            //Display elapsed time
            elapsedTime.DataContext = new TextboxText() { seconds = Math.Round(totalMilliseconds, 4) };



            getFail.DataContext = new MatrixText() { number = 0 };
            getSlow.DataContext = new MatrixText() { number = 0 };
            getNormal.DataContext = new MatrixText() { number = 0 };
            int FFlag = 0, SFlag = 0, NFlag =0 ;
            foreach(ItemList itemFlag in displayBox.Items)
            {
                if(itemFlag.AFlag == 0)
                {
                    NFlag += 1;
                    getNormal.DataContext = new MatrixText() { number = NFlag };
                }
                else if (itemFlag.AFlag == 3)
                {
                    FFlag += 1;
                    SFlag += 1;
                    getFail.DataContext = new MatrixText() { number = FFlag };
                    getSlow.DataContext = new MatrixText() { number = SFlag };
                }
                else if(itemFlag.AFlag == 2)
                {
                    FFlag += 1;
                    getFail.DataContext = new MatrixText() { number = FFlag };
                }
                else
                {
                    SFlag += 1;
                    getSlow.DataContext = new MatrixText() { number = SFlag };
                }
            }

        }
    }
}
