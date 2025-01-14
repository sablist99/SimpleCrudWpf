using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace WpfFrontCore.Infrastructure
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected void CloseWindow()
        {
            // In MVVM, the ViewModel should not interact directly with the View.
            Application.Current.Windows.OfType<Window>()
                .FirstOrDefault(w => w.DataContext == this)?.Close();
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
