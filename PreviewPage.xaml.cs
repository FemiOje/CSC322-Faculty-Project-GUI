using System.Windows;
using System.Windows.Controls;
using System.Printing;
using System.Windows.Documents;

namespace FacultyApp
{
    public partial class PreviewPage : Page
    {
        private Frame _mainFrame;

        public PreviewPage(Frame mainFrame)
        {
            InitializeComponent();
            _mainFrame = mainFrame;
            LoadData();
        }

        private void LoadData()
        {
            DepartmentsList.Items.Clear();
            foreach (var department in DataStore.Departments)
            {
                var departmentItem = new StackPanel { Margin = new Thickness(10) };
                departmentItem.Children.Add(new TextBlock { Text = department, FontWeight = FontWeights.Bold });

                var lecturers = DataStore.Lecturers.FindAll(l => l.Department == department);
                foreach (var lecturer in lecturers)
                {
                    departmentItem.Children.Add(new TextBlock { Text = lecturer.Name, Margin = new Thickness(20, 0, 0, 0) });
                }

                DepartmentsList.Items.Add(departmentItem);
            }
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();

            if (printDialog.ShowDialog() == true)
            {
                // Create a document
                FlowDocument doc = new FlowDocument();

                // Add data to the document
                foreach (var item in DepartmentsList.Items)
                {
                    if (item is StackPanel stackPanel)
                    {
                        foreach (var child in stackPanel.Children)
                        {
                            if (child is TextBlock textBlock)
                            {
                                doc.Blocks.Add(new Paragraph(new Run(textBlock.Text)));
                            }
                        }
                    }
                }

                // Print the document
                IDocumentPaginatorSource idpSource = doc;
                printDialog.PrintDocument(idpSource.DocumentPaginator, "Departments and Lecturers");
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            _mainFrame.Navigate(new DefaultPage(_mainFrame));
        }
    }
}
