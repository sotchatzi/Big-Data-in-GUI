﻿using System;
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
            //Display elapsed time
            elapsedTime.DataContext = new TextboxText() { seconds = ts.Seconds, milliseconds = ts.Milliseconds };
        }
    }
}