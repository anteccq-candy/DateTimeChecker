using System;
using DateTimeChecker.Models;
using DateTimeChecker.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace DateTimeChecker.Views;

public class ViewModelResolver
{
    private readonly IServiceProvider _serviceProvider;

    public static readonly ViewModelResolver Resolver = new();

    private ViewModelResolver()
    {
        _serviceProvider = ConfigureServices(services =>
        {
            services.AddSingleton<IDateTimeValidator, DateTimeValidator>();
            services.AddSingleton<MainWindowViewModel>();
        });
    }

    private static IServiceProvider ConfigureServices(Action<IServiceCollection> services)
    {
        var serviceCollection = new ServiceCollection();
        services(serviceCollection);
        return serviceCollection.BuildServiceProvider();
    }

    public T Get<T>() where T : class
        => _serviceProvider.GetRequiredService<T>();
}
