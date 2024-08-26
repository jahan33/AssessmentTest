using CsvHelper;
using DataAccess.IRepositories;
using DataAccess.Models;
using Service.DTO;
using Service.IServices;
using System.Globalization;

namespace Service.Services
{
    // Define a public class named FlightChangeDetectionService that implements the IFlightChangeDetectionService interface.
    public class FlightChangeDetectionService : IFlightChangeDetectionService
    {
        // Declare private fields for the flight and subscription repositories.
        private readonly IFlightRepository flightRepository;
        private readonly ISubscriptionRepository subscriptionRepository;

        // Constructor to initialize the repositories via dependency injection.
        public FlightChangeDetectionService(IFlightRepository _flightRepository, ISubscriptionRepository _subscriptionRepository)
        {
            flightRepository = _flightRepository;
            subscriptionRepository = _subscriptionRepository;
        }

        #region "Detect Changes"

        // Method to detect flight changes within a specified date range and for a specific agency.
        public void DetectChanges(DateTime startDate, DateTime endDate, int agencyId)
        {
            // Retrieve subscriptions for the given agency ID.
            var subscriptions = subscriptionRepository.Get(s => s.AgencyId == agencyId).ToList();

            // Retrieve flights within the specified date range and project them to a new Flight object.
            var flights = flightRepository.Get(f => f.DepartureTime >= startDate && f.DepartureTime <= endDate)
                .Select(s => new Flight
                {
                    FlightId = s.FlightId,
                    AirlineId = s.AirlineId,
                    RouteId = s.RouteId,
                    DepartureTime = s.DepartureTime,
                    ArrivalTime = s.ArrivalTime,
                    FK_Route_Flight = s.FK_Route_Flight
                })
                .ToList();

            // Initialize a list to hold the results of flight change detection.
            var results = new List<FlightChangeResultDto>();

            // Loop through each flight.
            foreach (var flight in flights)
            {
                // Loop through each subscription.
                foreach (var subscription in subscriptions)
                {
                    // Check if the flight matches the subscription's route.
                    if (flight.FK_Route_Flight != null && flight.FK_Route_Flight.OriginCityId == subscription.OriginCityId &&
                        flight.FK_Route_Flight.DestinationCityId == subscription.DestinationCityId)
                    {
                        // Determine if the flight is new (no similar flight within a week before or after).
                        bool isNew = !flights.Any(f =>
                            f.AirlineId == flight.AirlineId &&
                            f.DepartureTime >= flight.DepartureTime.AddDays(-7).AddMinutes(-30) &&
                            f.DepartureTime <= flight.DepartureTime.AddDays(-7).AddMinutes(30));

                        // Determine if the flight is discontinued (no similar flight within a week after).
                        bool isDiscontinued = !flights.Any(f =>
                            f.AirlineId == flight.AirlineId &&
                            f.DepartureTime >= flight.DepartureTime.AddDays(7).AddMinutes(-30) &&
                            f.DepartureTime <= flight.DepartureTime.AddDays(7).AddMinutes(30));

                        // If the flight is new, add it to the results with status "New".
                        if (isNew)
                        {
                            results.Add(new FlightChangeResultDto
                            {
                                FlightId = flight.FlightId,
                                OriginCityId = flight.FK_Route_Flight.OriginCityId,
                                DestinationCityId = flight.FK_Route_Flight.DestinationCityId,
                                DepartureTime = flight.DepartureTime,
                                ArrivalTime = flight.ArrivalTime,
                                AirlineId = flight.AirlineId,
                                Status = "New"
                            });
                        }

                        // If the flight is discontinued, add it to the results with status "Discontinued".
                        if (isDiscontinued)
                        {
                            results.Add(new FlightChangeResultDto
                            {
                                FlightId = flight.FlightId,
                                OriginCityId = flight.FK_Route_Flight.OriginCityId,
                                DestinationCityId = flight.FK_Route_Flight.DestinationCityId,
                                DepartureTime = flight.DepartureTime,
                                ArrivalTime = flight.ArrivalTime,
                                AirlineId = flight.AirlineId,
                                Status = "Discontinued"
                            });
                        }
                    }
                }
            }

            // Write the results to a CSV file.
            WriteResultsToCsv(results);
        }

        // Private method to write the list of FlightChangeResultDto to a CSV file.
        private void WriteResultsToCsv(List<FlightChangeResultDto> results)
        {
            // Create a new StreamWriter to write to "results.csv".
            using (var writer = new StreamWriter("results.csv"))
            // Create a new CsvWriter to handle the CSV writing.
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                // Write all records to the CSV file.
                csv.WriteRecords(results);
            }
        }

        #endregion
    }
}
