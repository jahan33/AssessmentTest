using DataAccess.DAL;
using DataAccess.IRepositories;
using DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Service.IServices;
using Service.Services;
using System.Globalization;

class Program
{
    // Entry point of the application
    static void Main(string[] args)
    {
        // Check if the number of arguments is exactly 3 (start date, end date, and agency ID)
        if (args.Length != 3)
        {
            Console.WriteLine("Usage: TestApp.exe <start date> <end date> <agency id>");
            return; // Exit if the number of arguments is incorrect
        }

        // Parse the start date from the first argument using the specified format
        DateTime startDate = DateTime.ParseExact(args[0], "yyyy-MM-dd", CultureInfo.InvariantCulture);

        // Parse the end date from the second argument using the specified format
        DateTime endDate = DateTime.ParseExact(args[1], "yyyy-MM-dd", CultureInfo.InvariantCulture);

        // Parse the agency ID from the third argument
        int agencyId = int.Parse(args[2]);

        // Configure services and build the service provider
        var serviceProvider = ConfigureServices();

        // Ensure the database is created
        using (var scope = serviceProvider.CreateScope())
        {
            // Get the FlightDBContext from the service provider
            var dbContext = scope.ServiceProvider.GetRequiredService<FlightDBContext>();

            // Ensure the database is created if it does not exist
            dbContext.Database.EnsureCreated();
        }

        // Get the FlightChangeDetectionService from the service provider
        var flightService = serviceProvider.GetRequiredService<IFlightChangeDetectionService>();

        // Call the DetectChanges method on the flightService
        flightService.DetectChanges(startDate, endDate, agencyId);
        Console.WriteLine("Result.csv file has been downloaded.");
    }

    // Method to configure and register services with the dependency injection container
    private static IServiceProvider ConfigureServices()
    {
        // Create a new ServiceCollection to hold the service registrations
        var services = new ServiceCollection();

        // Register the FlightDBContext with the service collection
        services.AddDbContext<FlightDBContext>();

        // Register the IDbFactory implementation with a scoped lifetime
        services.AddScoped<IDbFactory, DbFactory>();

        // Register the IFlightRepository implementation with a scoped lifetime
        services.AddScoped<IFlightRepository, FlightRepository>();

        // Register the ISubscriptionRepository implementation with a scoped lifetime
        services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();

        // Register the IFlightChangeDetectionService implementation with a scoped lifetime
        services.AddScoped<IFlightChangeDetectionService, FlightChangeDetectionService>();

        // Build and return the service provider
        return services.BuildServiceProvider();
    }
}