//stopwatch
using System.Diagnostics;
using System.Reflection.Emit;

namespace Create_List_WPF
{
    public class Measurement
    {
        public void TimeMeasurement(ref ILGenerator gen)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            //One million size
            //            IEnumerable<ItemList> items = Generate(1000000);

            //One million size and display in the GUI through yield
            //            DisplayBox.ItemsSource = GenerateYield(1000000);


            //10 million size and display in the GUI through yield
            IGenerator generator = new gen();
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
    }
}