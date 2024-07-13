using System.Windows;
using System.Windows.Controls;

namespace FacultyApp
{
    public partial class AddDepartmentPage : Page
    {
        private Frame _mainFrame;

        public AddDepartmentPage(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            // Add logic to save the department
            var departmentName = DepartmentNameTextBox.Text;
            if (!string.IsNullOrEmpty(departmentName))
            {
                // Save department (example: to a static list or a database)
                DataStore.Departments.Add(departmentName);
                MessageBox.Show("Department added successfully!");
            }
            else
            {
                MessageBox.Show("Please enter a department name.");
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new DefaultPage(_mainFrame));
        }
    }
}
