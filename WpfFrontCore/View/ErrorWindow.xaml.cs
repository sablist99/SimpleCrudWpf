using System.Windows;

namespace WpfFrontCore.View
{
    /// <summary>
    /// Логика взаимодействия для ErrorWindow.xaml
    /// </summary>
    public partial class ErrorWindow : Window
    {
        public ErrorWindow(string errorMessage)
        {
            InitializeComponent();
            ErrorTextBlock.Text = errorMessage;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e) => Close();
    }
}
