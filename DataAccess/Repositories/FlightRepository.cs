using DataAccess.DAL;
using DataAccess.IRepositories;
using DataAccess.Models;

namespace DataAccess.Repositories
{
    // Define a public class named FlightRepository that inherits from BaseRepository with Flight as the generic type parameter.
    // It also implements the IFlightRepository interface.
    public class FlightRepository : BaseRepository<Flight>, IFlightRepository
    {
        // Constructor that takes an IDbFactory instance and passes it to the base class constructor.
        public FlightRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}
