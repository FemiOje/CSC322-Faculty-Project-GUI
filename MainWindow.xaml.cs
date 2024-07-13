using System.Windows;

namespace FacultyApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new DefaultPage(MainFrame));
        }
    }
}
