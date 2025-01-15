using Domain.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfFrontCore.Client;
using WpfFrontCore.Infrastructure;

namespace SimpleCrudWpf.ViewModel
{
    public class ProjectEditViewModel : DialogBaseViewModel
    {
        public ProjectEditViewModel(ApiClient<Employee> employeeClient) : base()
        {
            Project = new Project();
            Init(employeeClient);
        }

        public ProjectEditViewModel(ApiClient<Employee> employeeClient, Project project) : base()
        {
            Project = new Project(project);
            Init(employeeClient);
        }

        private void Init(ApiClient<Employee> employeeClient)
        {
            EmployeeClient = employeeClient;

            NextCommand = new RelayCommand(OnNextStep);
            BackCommand = new RelayCommand(OnBackStep);

            Employees = new ObservableCollection<Employee>();
            SelectedEmployees = new ObservableCollection<Employee>();

            LoadEmployees();
        }

        private ApiClient<Employee> EmployeeClient { get; set; } = null!;

        public Project Project { get; set; }




        public ObservableCollection<Employee> Employees { get; set; } = new ObservableCollection<Employee>();
        public ObservableCollection<Employee> SelectedEmployees { get; set; } = [];






        private async void LoadEmployees()
        {
            var employees = await EmployeeClient.GetAllAsync();
            Employees = new ObservableCollection<Employee>(employees);
        }



        protected override bool CanSave()
        {
            return !string.IsNullOrWhiteSpace(Project.Title) && Project.StartDate != default && Project.EndDate != default;
        }

        #region Steps
        private readonly int _lastStep = 3;
        public ICommand NextCommand { get; set; } = null!;
        public ICommand BackCommand { get; set; } = null!;

        private void OnNextStep()
        {
            if (CurrentStep < _lastStep)
            {
                CurrentStep++;
            }
        }

        private void OnBackStep()
        {
            if (CurrentStep > 0)
            {
                CurrentStep--;
            }
        }

        public bool IsLastStep => CurrentStep == _lastStep;

        private int _currentStep;
        public int CurrentStep
        {
            get => _currentStep;
            set
            {
                if (_currentStep != value)
                {
                    _currentStep = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion
    }
}