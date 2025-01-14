using Domain.Model;
using System.Windows.Input;
using WpfFrontCore.Infrastructure;

namespace SimpleCrudWpf.ViewModel
{
    public class EmployeeEditViewModel : BaseViewModel
    {
        public EmployeeEditViewModel()
        {
            SaveCommand = new RelayCommand(OnSave, CanSave);
            CancelCommand = new RelayCommand(OnCancel);
        }

        public EmployeeEditViewModel(Employee employee) : this()
        {
            Id = employee.Id;
            Name = employee.Name;
            LastName = employee.LastName;
            Patronymic = employee.Patronymic;
            Email = employee.Email;
        }

        public int Id { get; set; } 

        private string _name = string.Empty;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
                ((RelayCommand)SaveCommand).RaiseCanExecuteChanged();
            }
        }

        private string _lastName = string.Empty;
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged();
                ((RelayCommand)SaveCommand).RaiseCanExecuteChanged();
            }
        }

        private string _patronymic = string.Empty;
        public string Patronymic
        {
            get => _patronymic;
            set
            {
                _patronymic = value;
                OnPropertyChanged();
                ((RelayCommand)SaveCommand).RaiseCanExecuteChanged();
            }
        }

        private string _email = string.Empty;
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
                ((RelayCommand)SaveCommand).RaiseCanExecuteChanged();
            }
        }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public bool DialogResult { get; private set; }

        private void OnSave()
        {
            DialogResult = true;
            CloseWindow();
        }

        private bool CanSave()
        {
            return !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(LastName);
        }

        private void OnCancel()
        {
            DialogResult = false;
            CloseWindow();
        }
    }
}
