using DataAccess.DAL;
using DataAccess.IRepositories;
using DataAccess.Models;

namespace DataAccess.Repositories
{
    // Define a public class named RouteRepository that inherits from BaseRepository with Route as the generic type parameter.
    // It also implements the IRouteRepository interface.
    public class RouteRepository : BaseRepository<Route>, IRouteRepository
    {
        // Constructor that takes an IDbFactory instance and passes it to the base class constructor.
        public RouteRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}
