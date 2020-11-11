using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Threading;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Collections;

namespace MultiThreaded_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static Collection<string> collection = new ObservableCollection<string>();
        public MainWindow()
        {
            InitializeComponent();
            Runtask(10000);

            //Task.Factory.StartNew(Work);

            //this.DisplayBox.ItemsSource = PopulateGUI();
            //StackPanel sp = new StackPanel();
            //sp.Margin = new Thickness(0, 0, 0, 0);
            //sp.Orientation = Orientation.Vertical;
            //List<ItemList> DisplayBox = new List<ItemList>();
            //PopulateGUI(DisplayBox);

        }

        /*
        /////////////////////////////////////////
        // StackPanel and Listbox does not work//
        /////////////////////////////////////////
        private async void PopulateGUI(List<ItemList> label)
        {
            
            //var progress = new Progress<string>(s => { TextBlock text = new TextBlock(); text.Text = s; label.Children.Add(text); });
            var progress = new Progress<ItemList>(s => { label.Add(s);});
            await Task.Factory.StartNew(() => Worker.LongWork(progress), TaskCreationOptions.LongRunning);

            //label.Content = "completed";
            
        }
    }

    class Worker
    {
        public static void LongWork(IProgress<ItemList> progress)
        {
            ItemList item = new ItemList();
            // Perform a long running work...
            for (var i = 0; i < 60; i++)
            {
                Task.Delay(500).Wait();
                item = new ItemList() { AnIndex = i, AString = RandomUtil.GetRandomString() };
                progress.Report(item);
            }
        }*/
        ///////////////////
        ///cannot stream///
        ///////////////////
        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    Task.Factory.StartNew(Work);
        //}

        /* private void Work()
         {
             Task task = new Task((tb) => Begin(this.first), this.first);
             task.Start();
             task.Wait();
         }
         private void GetResult(List<string> tb, string text)
         {
             tb.Text = text;
         }

         private void Begin(List<string> tb)
         {
             Random random = new Random();
             String Num = random.Next(0, 100).ToString();
             Action<List<string>, String> updateAction = new Action<List<string>, string>(GetResult);
             tb.Dispatcher.BeginInvoke(updateAction, tb, Num);

         }*/
        private void Runtask(int num)
        {
            Thread newThread = new Thread(new ParameterizedThreadStart(GetResult));
            newThread.Start(num);
        }
        
        
        /// <summary>
        /// Generate in worker thread, GUI in main thread
        /// </summary>
        /// <param name="inputNumber"></param>
        private void GetResult(object size)
        {
            IGenerator generator = new BadGenerator();
            IEnumerable<ItemList> result = generator.Generate((int)size);
            this.Dispatcher.BeginInvoke((Action)delegate ()
            {
                this.DisplayBox.ItemsSource = result;
            });
        }
        
        /*
        private IEnumerable<ItemList> BadGenerator(int size)
        {
            Random interval = new Random();
            for (int i = 0; i < size; i++)
            {
                Task.Delay(interval.Next(0, 2)).Wait();
                yield return new ItemList() { AnIndex = i, AString = RandomUtil.GetRandomString() };
            }

        }*/


        /*
        /// <summary>
        /// another method (needs a lock between threads)
        /// </summary>
        /// <param name="inputNumber"></param>
        private void GetResult1(object inputNumber)
        {
            List<ItemList> items = new List<ItemList>();
            for (int i = 0; i < (int)inputNumber; i++)
            {
                Thread.Sleep(100);
                items.Add(new ItemList() { AnIndex = i, AString = RandomUtil.GetRandomString() });      
                this.Dispatcher.BeginInvoke((Action)delegate ()
            {
                this.DisplayBox.ItemsSource = items;
            });
            }
        }*/

    }
}
