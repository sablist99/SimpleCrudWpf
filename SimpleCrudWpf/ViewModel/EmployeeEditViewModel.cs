using Domain.Model;
using WpfFrontCore.Infrastructure;

namespace SimpleCrudWpf.ViewModel
{
    public class EmployeeEditViewModel : DialogBaseViewModel
    {
        public EmployeeEditViewModel() : base()
        {
            Employee = new Employee();
        }

        public EmployeeEditViewModel(Employee employee) : this()
        {
            if (employee == null) { throw new Exception("Empty employee"); }

            Employee = new Employee(employee);
        }

        private Employee _employee = null!;
        public Employee Employee
        {
            get => _employee;
            set
            {
                _employee = value;
                OnPropertyChanged();
                ((RelayCommand)SaveCommand).RaiseCanExecuteChanged();
            }
        }

        public string Name
        {
            get => Employee.Name;
            set
            {
                if (Employee.Name != value)
                {
                    Employee.Name = value;
                    OnPropertyChanged();
                    ((RelayCommand)SaveCommand).RaiseCanExecuteChanged();
                }
            }
        }

        public string LastName
        {
            get => Employee.LastName;
            set
            {
                if (Employee.LastName != value)
                {
                    Employee.LastName = value;
                    OnPropertyChanged();
                    ((RelayCommand)SaveCommand).RaiseCanExecuteChanged();
                }
            }
        }

        public string Patronymic
        {
            get => Employee.Patronymic;
            set
            {
                if (Employee.Patronymic != value)
                {
                    Employee.Patronymic = value;
                    OnPropertyChanged();
                    ((RelayCommand)SaveCommand).RaiseCanExecuteChanged();
                }
            }
        }

        public string Email
        {
            get => Employee.Email;
            set
            {
                if (Employee.Email != value)
                {
                    Employee.Email = value;
                    OnPropertyChanged();
                    ((RelayCommand)SaveCommand).RaiseCanExecuteChanged();
                }
            }
        }

        protected override bool CanSave()
        {
            return !string.IsNullOrWhiteSpace(Employee.Name) && !string.IsNullOrWhiteSpace(Employee.LastName);
        }
    }
}
