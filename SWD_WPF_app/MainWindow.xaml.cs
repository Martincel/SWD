using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Content = new InfoPage();
        }
        private void OpenPageWorkouts(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Workouts();
        }
        private void OpenPageSleeps(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new Sleeps();
        }

        private void OpenPageInfo(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new InfoPage();
        }

        private void OpenPageHeartRates(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new HeartRates();
        }
    }
}
