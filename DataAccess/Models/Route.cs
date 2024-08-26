using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{
    // Apply a unique index on the combination of OriginCityId, DestinationCityId, and DepartureDate properties.
    [Index(nameof(Route.OriginCityId), nameof(Route.DestinationCityId), nameof(Route.DepartureDate), IsUnique = true)]
    // Define a public class named Route.
    public class Route
    {
        // Constructor to initialize the Flights collection as a HashSet.
        public Route()
        {
            Flights = new HashSet<Flight>();
        }

        // Mark RouteId as the primary key for the Route entity.
        [Key]
        // Map this property to the "route_id" column in the database and set the order of the column.
        [Column("route_id", Order = 1)]
        // Make the RouteId property required and set a custom error message.
        [Required(ErrorMessage = "Route is required")]
        // Define a public property named RouteId of type int.
        public int RouteId { get; set; }

        // Map this property to the "origin_city_id" column in the database and set the order of the column.
        [Column("origin_city_id", Order = 2)]
        // Make the OriginCityId property required and set a custom error message.
        [Required(ErrorMessage = "Origin city is required")]
        // Define a public property named OriginCityId of type int.
        public int OriginCityId { get; set; }

        // Map this property to the "destination_city_id" column in the database and set the order of the column.
        [Column("destination_city_id", Order = 3)]
        // Make the DestinationCityId property required and set a custom error message.
        [Required(ErrorMessage = "Destination city is required")]
        // Define a public property named DestinationCityId of type int.
        public int DestinationCityId { get; set; }

        // Map this property to the "departure_date" column in the database and set the order of the column.
        [Column("departure_date", Order = 4)]
        // Make the DepartureDate property required and set a custom error message.
        [Required(ErrorMessage = "Departure date is required")]
        // Define a public property named DepartureDate of type DateTime.
        public DateTime DepartureDate { get; set; }

        // Define a navigation property to represent the collection of Flights associated with this Route.
        // The InverseProperty attribute specifies that this collection corresponds to the FK_Route_Flight navigation property in the Flight class.
        [InverseProperty("FK_Route_Flight")]
        public ICollection<Flight> Flights { get; set; }
    }
}
