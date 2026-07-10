using Complements.Application;
using Complements.DB;
using Complements.Entities;
using Complements.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WinformsCleanArchitecture;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);

        var serviceProvider = serviceCollection.BuildServiceProvider();
        var mainForm = serviceProvider.GetRequiredService<FormMain>();
        
        Application.Run(mainForm);
    }

    private static void ConfigureServices(ServiceCollection serviceCollection) 
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        serviceCollection.AddDbContext<AppBrandDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        serviceCollection.AddSingleton(configuration);
        serviceCollection.AddTransient<IRepository<Brand>, BrandRepository>();
        serviceCollection.AddTransient<AddBrand>();
        serviceCollection.AddTransient<FormMain>();
        serviceCollection.AddTransient<FormBrand>();
    }
}