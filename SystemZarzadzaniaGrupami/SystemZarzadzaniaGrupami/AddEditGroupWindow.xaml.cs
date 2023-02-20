using StudentGroups;
using System.ComponentModel;
using System.Windows;

namespace StudentGroups
{
    public partial class AddEditGroupWindow : Window, INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    public string WindowTitle { get; set; }
    public StudentGroup Group { get; set; }
    public Student SelectedStudent { get; set; }

    public AddEditGroupWindow()
    {
        InitializeComponent();
        Group = new StudentGroup();
        WindowTitle = "Add Group";
        DataContext = this;
    }

    public AddEditGroupWindow(StudentGroup group)
    {
        InitializeComponent();
        Group = group;
        WindowTitle = "Edit Group";
        DataContext = this;
    }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            var addStudentWindow = new AddEditStudentWindow();
            addStudentWindow.Owner = this;
            if (addStudentWindow.ShowDialog() == true)
            {
                Group.Students.Add(addStudentWindow.Student);
            }
        }

        private void EditStudent_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedStudent == null)
            {
                MessageBox.Show("Please select a student to edit.");
                return;
            }

            var editStudentWindow = new AddEditStudentWindow(SelectedStudent);
            editStudentWindow.Owner = this;
            if (editStudentWindow.ShowDialog() == true)
            {
                // replace the edited student with the updated student
                int index = Group.Students.IndexOf(SelectedStudent);
                Group.Students[index] = editStudentWindow.Student;
            }
        }

    private void DeleteStudent_Click(object sender, RoutedEventArgs e)
    {
        if (SelectedStudent == null)
        {
            MessageBox.Show("Please select a student to delete.");
            return;
        }

        var result = MessageBox.Show($"Are you sure you want to delete {SelectedStudent.Name}?", "Delete Student", MessageBoxButton.YesNo);
        if (result == MessageBoxResult.Yes)
        {
            Group.Students.Remove(SelectedStudent);
        }
    }
    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
    }