using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

//Random util class
//stopwatch
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreaded_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            PopulateGUI(ElapsedTime1);
        }

        private async void PopulateGUI(Label label)
        {
            var progress = new Progress<string>(s => label.Content = s);
            await Task.Factory.StartNew(() => Worker.LongWork(progress), TaskCreationOptions.LongRunning);
            label.Content = "completed";
        }
    }

    class Worker
    {
        public static void LongWork(IProgress<string> progress)
        {
            // Perform a long running work...
            for (var i = 0; i < 60; i++)
            {
                Task.Delay(500).Wait();
                progress.Report(i.ToString());
            }
        }
    }

}
