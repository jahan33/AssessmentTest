using DataAccess.DAL;
using DataAccess.IRepositories;
using DataAccess.Models;

namespace DataAccess.Repositories
{
    // Define a public class named SubscriptionRepository that inherits from BaseRepository with Subscription as the generic type parameter.
    // It also implements the ISubscriptionRepository interface.
    public class SubscriptionRepository : BaseRepository<Subscription>, ISubscriptionRepository
    {
        // Constructor that takes an IDbFactory instance and passes it to the base class constructor.
        public SubscriptionRepository(IDbFactory dbFactory)
            : base(dbFactory)
        {
        }
    }
}
