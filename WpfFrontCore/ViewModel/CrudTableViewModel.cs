using Domain.Infrastructure;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfFrontCore.Client;
using WpfFrontCore.Infrastructure;
using WpfFrontCore.View;

namespace WpfFrontCore.ViewModel
{
    public class CrudTableViewModel<T> : BaseViewModel, ICrudTableViewModel where T : Entity
    {
        public CrudTableViewModel(ApiClient<T> client)
        {
            AddCommand = new RelayCommand(OnAdd);
            EditCommand = new RelayCommand(OnEdit, CanEditOrDelete);
            DeleteCommand = new RelayCommand(OnDelete, CanEditOrDelete);
            RefreshCommand = new RelayCommand(OnRefresh);

            Client = client;

            try
            {
                OnRefresh();
            }
            catch (Exception ex) { }
        }

        public ObservableCollection<ControlConfiguration> TableConfiguration { get; set; } = [];

        public ApiClient<T> Client { get; set; }

        public ObservableCollection<T> TableData
        {
            get => _tableData;
            set
            {
                if (_tableData != value)
                {
                    _tableData = value;
                    OnPropertyChanged(); // Уведомляем об изменении
                }
            }
        }

        public T? SelectedItem
        {
            get => _selectedItem;
            set { _selectedItem = value; OnPropertyChanged(); }
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

        private async void OnRefresh()
        {
            try
            {
                TableData = new ObservableCollection<T>(await Client.GetAllAsync());
            }
            catch (Exception ex)
            {
                var errorWindow = new ErrorWindow($"Refresh data error: {ex.Message}");
                errorWindow.ShowDialog();
            }
        }

        #region Commands
        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand RefreshCommand { get; }

        private bool CanEditOrDelete()
        {
            return SelectedItem != null;
        }
        #endregion Commands

        #region PrivateFields
        private ObservableCollection<T> _tableData = [];
        private T? _selectedItem;
        #endregion PrivateFields
    }
}
