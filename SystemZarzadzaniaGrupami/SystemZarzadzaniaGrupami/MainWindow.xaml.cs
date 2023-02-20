using System.Collections.ObjectModel;
using System.Windows;

namespace StudentGroups
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<StudentGroup> StudentGroups { get; set; }
        public StudentGroup SelectedStudentGroup { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            StudentGroups = new ObservableCollection<StudentGroup>();
        }

        private void AddGroup_Click(object sender, RoutedEventArgs e)
        {
            var addGroupWindow = new AddEditGroupWindow();
            addGroupWindow.Owner = this;
            if (addGroupWindow.ShowDialog() == true)
            {
                StudentGroups.Add(addGroupWindow.Group);
            }
        }

        private void EditGroup_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedStudentGroup == null)
            {
                MessageBox.Show("Please select a group to edit.");
                return;
            }

            var editGroupWindow = new AddEditGroupWindow(SelectedStudentGroup);
            editGroupWindow.Owner = this;
            if (editGroupWindow.ShowDialog() == true)
            {
                // replace the edited group with the updated group
                int index = StudentGroups.IndexOf(SelectedStudentGroup);
                StudentGroups[index] = editGroupWindow.Group;
            }
        }

        private void DeleteGroup_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedStudentGroup == null)
            {
                MessageBox.Show("Please select a group to delete.");
                return;
            }
            var result = MessageBox.Show($"Are you sure you want to delete {SelectedStudentGroup.Name}?", "Delete Group", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                StudentGroups.Remove(SelectedStudentGroup);
            }
        }
    }
}