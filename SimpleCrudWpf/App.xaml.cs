using Domain.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleCrudWpf.ViewModel;
using System.IO;
using System.Windows;
using WpfFrontCore.Client;

namespace SimpleCrudWpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfiguration configuration = builder.Build();

            var services = new ServiceCollection();

            // Configuration registration
            services.AddSingleton<IConfiguration>(configuration);

            // Registering HttpClient for different API
            services.AddHttpClient<ApiClient<Employee>>(client =>
            {
                string uri = $"{configuration["ApiSettings:ApiBaseUrl"]}Employee";
                client.BaseAddress = new Uri(uri);
            });

            services.AddHttpClient<ApiClient<Project>>(client =>
            {
                string uri = $"{configuration["ApiSettings:ApiBaseUrl"]}Project";
                client.BaseAddress = new Uri(uri);
            });

            services.AddHttpClient<ApiClient<EmployeeOnProject>>(client =>
            {
                string uri = $"{configuration["ApiSettings:ApiBaseUrl"]}EmployeeOnProject";
                client.BaseAddress = new Uri(uri);
            });

            // Registering ViewModel
            services.AddTransient<MainWindowViewModel>();
            services.AddTransient<EmployeeCrudTableViewModel>();
            services.AddTransient<EmployeeOnProjectCrudTableViewModel>();
            services.AddTransient<ProjectCrudTableViewModel>();

            // Registering MainWindow
            services.AddTransient<MainWindow>();

            ServiceProvider = services.BuildServiceProvider();

            // Get MainWindow from DI
            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            // And show window
            mainWindow.Show();

            base.OnStartup(e);
        }
    }
}
