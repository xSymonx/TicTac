using GalaSoft.MvvmLight.Command;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace StudentGroups
{
    public class AddEditStudentViewModel : INotifyPropertyChanged
    {
        private Student _student;
        private bool _sameAsResidentialAddress;

        public event PropertyChangedEventHandler PropertyChanged;

        public Student Student
        {
            get { return _student; }
            set
            {
                if (_student != value)
                {
                    _student = value;
                    OnPropertyChanged(nameof(Student));
                }
            }
        }

        public bool SameAsResidentialAddress
        {
            get { return _sameAsResidentialAddress; }
            set
            {
                if (_sameAsResidentialAddress != value)
                {
                    _sameAsResidentialAddress = value;
                    OnPropertyChanged(nameof(SameAsResidentialAddress));
                    OnPropertyChanged(nameof(MailingAddressEnabled));
                }
            }
        }

        public bool MailingAddressEnabled
        {
            get { return !_sameAsResidentialAddress; }
        }

        public string WindowTitle { get; set; }

        public ICommand OKCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public AddEditStudentViewModel(Student student, string title)
        {
            _student = student;
            WindowTitle = title;

            OKCommand = new RelayCommand<Window>(OK);
            CancelCommand = new RelayCommand<Window>(Cancel);
        }

        private void OK(Window window)
        {
            window.DialogResult = true;
            window.Close();
        }

        private void Cancel(Window window)
        {
            window.DialogResult = false;
            window.Close();
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
