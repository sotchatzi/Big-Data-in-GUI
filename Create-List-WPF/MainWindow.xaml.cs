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

            int size = 10000;
            IGenerator generator1 = new SlowGenerator();
            IGenerator generator2 = new YieldGenerator();

            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            DisplayBox1.ItemsSource = generator1.Generate(size);
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            ElapsedTime1.DataContext = new TextboxText() { seconds = ts.Seconds, milliseconds = ts.Milliseconds };

            stopWatch.Restart();
            DisplayBox2.ItemsSource = generator2.Generate(size);
            stopWatch.Stop();
            ts = stopWatch.Elapsed;
            ElapsedTime2.DataContext = new TextboxText() { seconds = ts.Seconds, milliseconds = ts.Milliseconds };
        }
    }
}
