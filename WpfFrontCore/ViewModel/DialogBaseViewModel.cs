using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using WpfFrontCore.ViewModel;

namespace WpfFrontCore.Infrastructure
{
    public class DialogBaseViewModel : BaseViewModel
    {
        public DialogBaseViewModel ()
        {
            SaveCommand = new RelayCommand(OnSave, CanSave);
            CancelCommand = new RelayCommand(OnCancel);
        }
        protected void CloseWindow()
        {
            // In MVVM, the ViewModel should not interact directly with the View.
            Application.Current.Windows.OfType<Window>()
                .FirstOrDefault(w => w.DataContext == this)?.Close();
        }

        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }
        public bool DialogResult { get; private set; }

        private void OnSave()
        {
            DialogResult = true;
            CloseWindow();
        }

        protected virtual bool CanSave() =>
            throw new NotImplementedException();

        private void OnCancel()
        {
            DialogResult = false;
            CloseWindow();
        }

        #region PropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion PropertyChanged
    }
}
