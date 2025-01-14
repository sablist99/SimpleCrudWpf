using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WpfFrontCore.Infrastructure;

namespace WpfFrontCore.ViewModel
{
    public class ConfirmDeleteViewModel : BaseViewModel
    {
        public ObservableCollection<FieldValue> FieldValues { get; }

        public ICommand YesCommand { get; }
        public ICommand NoCommand { get; }

        public bool DialogResult { get; private set; }

        public ConfirmDeleteViewModel(IEnumerable<FieldValue> fieldValues)
        {
            FieldValues = new ObservableCollection<FieldValue>(fieldValues);
            YesCommand = new RelayCommand(OnYes);
            NoCommand = new RelayCommand(OnNo);
        }

        private void OnYes()
        {
            DialogResult = true;
            CloseWindow();
        }

        private void OnNo()
        {
            DialogResult = false;
            CloseWindow();
        }


        private void CloseWindow()
        {
            // In MVVM, the ViewModel should not interact directly with the View.
            Application.Current.Windows.OfType<Window>()
                .FirstOrDefault(w => w.DataContext == this)?.Close();
        }
    }
}
