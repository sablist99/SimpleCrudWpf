using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfFrontCore.Infrastructure
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region PropertyChanged
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion PropertyChanged
    }
}
