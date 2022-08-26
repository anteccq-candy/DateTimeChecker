using System.Windows;
using DateTimeChecker.Models;
using DateTimeChecker.ViewModels;
using DateTimeChecker.Views.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace DateTimeChecker;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private void App_OnStartup(object sender, StartupEventArgs e)
    {
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
        var provider = serviceCollection.BuildServiceProvider();

        provider.GetRequiredService<MainWindow>().Show();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<MainWindow>();
        services.AddSingleton<IDateTimeValidator, DateTimeValidator>();
        services.AddSingleton<MainWindowViewModel>();
    }
}