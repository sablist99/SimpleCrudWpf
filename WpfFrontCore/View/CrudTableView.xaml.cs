using System.Windows.Controls;
using WpfFrontCore.ViewModel;

namespace WpfFrontCore.View
{
    public partial class CrudTableView : UserControl
    {
        public CrudTableView()
        {
            InitializeComponent();
            DataContextChanged += OnDataContextChanged;
        }

        private void OnDataContextChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            CreateColumns();
        }

        /// <summary>
        /// Generate columns by TableConfiguration
        /// </summary>
        private void CreateColumns()
        {
            DataGridControl.Columns.Clear();

            if (DataContext is ICrudTableViewModel viewModel)
            {
                foreach (var columnConfig in viewModel.TableConfiguration)
                {
                    var column = new DataGridTextColumn
                    {
                        Header = columnConfig.Label,
                        Binding = new System.Windows.Data.Binding(columnConfig.FieldName),
                    };
                    DataGridControl.Columns.Add(column);
                }
            }
        }
    }
}
