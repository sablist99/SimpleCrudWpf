using Domain.Infrastructure;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WpfFrontCore.Infrastructure;

namespace WpfFrontCore.ViewModel
{
    public class CrudTableViewModel<T> : ICrudTableViewModel, INotifyPropertyChanged where T : Entity
    {
        public ObservableCollection<T> TableData { get; set; } = [];
        public ObservableCollection<ControlConfiguration> TableConfiguration { get; set; } = [];

        private T? _selectedItem;
        public T? SelectedItem
        {
            get => _selectedItem;
            set { _selectedItem = value; OnPropertyChanged(); }
        }

        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public CrudTableViewModel()
        {
            AddCommand = new RelayCommand(OnAdd);
            EditCommand = new RelayCommand(OnEdit, CanEditOrDelete);
            DeleteCommand = new RelayCommand(OnDelete, CanEditOrDelete);
        }

        private void OnAdd()
        {
            throw new NotImplementedException();
        }

        private void OnEdit()
        {
            if (SelectedItem == null) return;

            throw new NotImplementedException();
        }

        private void OnDelete()
        {
            if (SelectedItem == null) return;

            throw new NotImplementedException();
            TableData.Remove(SelectedItem);
        }

        private bool CanEditOrDelete()
        {
            return SelectedItem != null;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
