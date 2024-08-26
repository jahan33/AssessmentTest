using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess.DAL
{
    // Define a public class named FlightDBContext that inherits from DbContext.
    public class FlightDBContext : DbContext
    {

        #region "DB set"

        // Define a DbSet property to represent the Route table in the database.
        public DbSet<Route> Route { get; set; }

        // Define a DbSet property to represent the Flight table in the database.
        public DbSet<Flight> Flight { get; set; }

        // Define a DbSet property to represent the Subscription table in the database.
        public DbSet<Subscription> Subscription { get; set; }

        #endregion

        // Override the OnConfiguring method to configure the database context.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Check if the optionsBuilder has already been configured.
            if (!optionsBuilder.IsConfigured)
            {
                // Create a configuration object by building the configuration from the appsettings.json file.
                IConfigurationRoot configuration = new ConfigurationBuilder()
                                                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                                    .AddJsonFile("appsettings.json")
                                                    .Build();

                // Retrieve the connection string named "DefaultConnection" from the configuration.
                string defaultConnection = configuration.GetConnectionString("DefaultConnection");

                // Configure the DbContext to use SQL Server with the specified connection string.
                optionsBuilder.UseSqlServer(defaultConnection);
            }
        }
    }
}
