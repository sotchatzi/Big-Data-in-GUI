using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows.Controls;
using System.Windows;
using Generators;
using System.Diagnostics;

namespace Create_List_WPF
{
    class PopulateGUIOneByOne
    {
        public void PopulateGUI(TextBox NumberOfList, ListBox listBox, ProgressBar progressBar, TextBlock elapsedTime)
        {
            int size = Convert.ToInt32(NumberOfList.Text);
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            var mySource = Enumerable.Range(1, size).ToList();
            Task.Factory.StartNew(() => { 
                Generate(mySource, size, listBox, progressBar); 
            });
            //while (progressBar.Value < 99)
            //{
            //    continue;
            //};
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;

            double minutesToSeconds = ts.Minutes * 60;
            elapsedTime.DataContext = new TextboxText() { seconds = ts.Seconds + minutesToSeconds, milliseconds = ts.Milliseconds };
        }

        private void Generate(List<int> values, int size, ListBox listBox, ProgressBar progressBar)
        {
            int progressPercentage;

            foreach (var i in values)
            {
                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    listBox.Items.Add(new ItemList() { AnIndex = i, AString = RandomUtil.GetRandomString() });

                    progressPercentage = Convert.ToInt32((double)i / size * 100);
                    progressBar.Value = progressPercentage;
                }), DispatcherPriority.Background);
            }
        }

    }
}
