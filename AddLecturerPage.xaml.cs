using System.Windows;
using System.Windows.Controls;

namespace FacultyApp
{
    public partial class AddLecturerPage : Page
    {
        private Frame _mainFrame;
        private string _selectedDepartment;

        public AddLecturerPage(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
            LoadDepartments();
        }

        private void LoadDepartments()
        {
            DepartmentButtonsPanel.Items.Clear();
            foreach (var department in DataStore.Departments)
            {
                var button = new Button
                {
                    Content = department,
                    Width = 200,
                    Margin = new Thickness(5)
                };
                button.Click += DepartmentButton_Click;
                DepartmentButtonsPanel.Items.Add(button);
            }
        }

        private void DepartmentButton_Click(object sender, RoutedEventArgs e)
        {
            _selectedDepartment = (sender as Button).Content.ToString();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var lecturerName = LecturerNameTextBox.Text;
            if (!string.IsNullOrEmpty(lecturerName) && !string.IsNullOrEmpty(_selectedDepartment))
            {
                DataStore.Lecturers.Add(new Lecturer { Name = lecturerName, Department = _selectedDepartment });
                MessageBox.Show("Lecturer added successfully!");
            }
            else
            {
                MessageBox.Show("Please select a department and enter a lecturer name.");
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new DefaultPage(_mainFrame));
        }
    }
}
