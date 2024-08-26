using DataAccess.Models;

namespace DataAccess.IRepositories
{
    // Define a public interface named ISubscriptionRepository that inherits from the generic IRepository interface with Subscription as the type parameter.
    public interface ISubscriptionRepository : IRepository<Subscription>
    {
    }
}
