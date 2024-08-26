namespace Service.DTO
{
    // Define a public class named FlightChangeResultDto.
    public class FlightChangeResultDto
    {
        // Define a public property to represent the FlightId of the flight.
        public int FlightId { get; set; }

        // Define a public property to represent the OriginCityId where the flight originates.
        public int OriginCityId { get; set; }

        // Define a public property to represent the DestinationCityId where the flight is heading.
        public int DestinationCityId { get; set; }

        // Define a public property to represent the DepartureTime of the flight.
        public DateTime DepartureTime { get; set; }

        // Define a public property to represent the ArrivalTime of the flight.
        public DateTime ArrivalTime { get; set; }

        // Define a public property to represent the AirlineId of the airline operating the flight.
        public int AirlineId { get; set; }

        // Define a public property to represent the Status of the flight.
        // Initialize Status to an empty string.
        public string Status { get; set; } = string.Empty;
    }







}
