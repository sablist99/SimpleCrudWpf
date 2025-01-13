using System.Collections.ObjectModel;
using WpfFrontCore.Infrastructure;

namespace WpfFrontCore.ViewModel
{
    public interface ICrudTableViewModel
    {
        ObservableCollection<ControlConfiguration> TableConfiguration { get; }
    }
}
