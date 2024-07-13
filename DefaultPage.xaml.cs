using System.Windows;
using System.Windows.Controls;

namespace FacultyApp
{
    public partial class DefaultPage : Page
    {
        private Frame _mainFrame;

        public DefaultPage(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
        }

        private void AddDepartment_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new AddDepartmentPage(_mainFrame));
        }

        private void AddLecturer_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new AddLecturerPage(_mainFrame));
        }

        private void Preview_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new PreviewPage(_mainFrame));
        }
    }
}
