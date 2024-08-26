using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Models
{

    // Define a public class named Flight.
    public class Flight
    {
        // Mark FlightId as the primary key for the Flight entity.
        [Key]
        // Map this property to the "flight_id" column in the database and set the order of the column.
        [Column("flight_id", Order = 1)]
        // Define a public property named FlightId of type int.
        public int FlightId { get; set; }

        // Map this property to the "route_id" column in the database and set the order of the column.
        [Column("route_id", Order = 2)]
        // Set this property as a foreign key referencing the Route entity with the name "FK_Route_Flight".
        [ForeignKey("FK_Route_Flight")]
        // Make the RouteId property required and set a custom error message.
        [Required(ErrorMessage = "Route is required")]
        // Define a public property named RouteId of type int.
        public int RouteId { get; set; }

        // Map this property to the "departure_time" column in the database and set the order of the column.
        [Column("departure_time", Order = 3)]
        // Make the DepartureTime property required and set a custom error message.
        [Required(ErrorMessage = "Departure time is required")]
        // Define a public property named DepartureTime of type DateTime.
        public DateTime DepartureTime { get; set; }

        // Map this property to the "arrival_time" column in the database and set the order of the column.
        [Column("arrival_time", Order = 4)]
        // Make the ArrivalTime property required and set a custom error message.
        [Required(ErrorMessage = "Arrival time is required")]
        // Define a public property named ArrivalTime of type DateTime.
        public DateTime ArrivalTime { get; set; }

        // Map this property to the "airline_id" column in the database and set the order of the column.
        [Column("airline_id", Order = 5)]
        // Make the AirlineId property required and set a custom error message.
        [Required(ErrorMessage = "Airline is required")]
        // Define a public property named AirlineId of type int.
        public int AirlineId { get; set; }

        // Define a navigation property to represent the relationship between Flight and Route.
        // This virtual property represents the foreign key "FK_Route_Flight" to the Route entity.
        public virtual Route FK_Route_Flight { get; set; }
    }
}
