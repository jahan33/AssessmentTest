using DataAccess.Models;

namespace DataAccess.IRepositories
{
    // Define a public interface named IFlightRepository that inherits from the generic IRepository interface with Flight as the type parameter.
    public interface IFlightRepository : IRepository<Flight>
    {
    }
}
