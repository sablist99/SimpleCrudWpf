using Domain.Infrastructure;
using System.Collections.ObjectModel;
using System.Net.Http;
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

            FetchDataDelegate = async () => await Client.GetAllAsync();

            try
            {
                OnRefresh();
            }
            catch (Exception ex) { }
        }
        
        public delegate Task<IEnumerable<T>> ClientDelegate<T>();

        public ClientDelegate<T> FetchDataDelegate { get; set; }

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
                    OnPropertyChanged();
                }
            }
        }

        public T? SelectedItem
        {
            get => _selectedItem;
            set 
            { 
                _selectedItem = value; 
                OnPropertyChanged();

                // Check the possibility of executing commands
                ((RelayCommand)EditCommand).RaiseCanExecuteChanged();
                ((RelayCommand)DeleteCommand).RaiseCanExecuteChanged();
            }
        }

        protected virtual void OnAdd()
        {
            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                var errorWindow = new ErrorWindow($"Add data error: {ex.Message}");
                errorWindow.ShowDialog();
            }
        }

        protected virtual void OnEdit()
        {
            if (SelectedItem == null) return;

            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                var errorWindow = new ErrorWindow($"Edit data error: {ex.Message}");
                errorWindow.ShowDialog();
            }
        }

        protected virtual async void OnDelete()
        {
            if (SelectedItem == null) return;

            try
            {
                var fieldValues = TableConfiguration
                    .Select(config => new FieldValue
                    {
                        Field = config.Label,
                        Value = SelectedItem.GetType()
                                            .GetProperty(config.FieldName)?
                                            .GetValue(SelectedItem, null)?
                                            .ToString() ?? string.Empty
                    });

                var viewModel = new ConfirmDeleteViewModel(fieldValues);
                var confirmWindow = new ConfirmDeleteWindow { DataContext = viewModel };

                confirmWindow.ShowDialog();

                if (viewModel.DialogResult)
                {
                    await Client.DeleteAsync(SelectedItem.Id);
                    TableData.Remove(SelectedItem);
                }
            }
            catch (HttpRequestException ex) when (ex.Message.Contains("foreign key constraint"))
            {
                var errorWindow = new ErrorWindow("The record cannot be deleted because it is in use.");
                errorWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                var errorWindow = new ErrorWindow($"Delete data error: {ex.Message}");
                errorWindow.ShowDialog();
            }
        }

        protected virtual async void OnRefresh()
        {
            try
            {
                TableData = new ObservableCollection<T>(await FetchDataDelegate.Invoke());
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
