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

            int size = 1000;
            IGenerator generator1 = new SlowGenerator();
            IGenerator generator2 = new YieldGenerator();

            PopulateGUI(generator1, DisplayBox1, ElapsedTime1, size);
            PopulateGUI(generator2, DisplayBox2, ElapsedTime2, size);
        }

        private void PopulateGUI(IGenerator generator, ListBox displayBox, TextBlock elapsedTime, int size)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            displayBox.ItemsSource = generator.Generate(size);
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            elapsedTime.DataContext = new TextboxText() {seconds = ts.Seconds, milliseconds = ts.Milliseconds};
        }
    }
}
