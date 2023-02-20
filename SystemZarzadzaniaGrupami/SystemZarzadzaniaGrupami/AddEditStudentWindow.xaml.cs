using System.Windows;

namespace StudentGroups
{
    public partial class AddEditStudentWindow : Window
    {
        public AddEditStudentWindow()
        {
        }

        public AddEditStudentWindow(AddEditStudentViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        public AddEditStudentWindow(Student selectedStudent)
        {
            SelectedStudent = selectedStudent;
        }

        public Student Student { get; internal set; }
        public Student SelectedStudent { get; }
    }
}
