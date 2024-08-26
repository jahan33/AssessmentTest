using DataAccess.DAL;
using DataAccess.IRepositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repositories
{
    // Define an abstract class named BaseRepository with a generic type parameter T that implements IRepository<T>.
    // The constraint where T must be a class ensures that T is a reference type.
    public abstract class BaseRepository<T> : IRepository<T>
        where T : class
    {
        // Declare a private variable to hold the FlightDBContext instance.
        private FlightDBContext _context;

        // Declare a private variable to hold the DbSet<T> for the entity type T.
        private DbSet<T> _dbset;

        // Declare a private boolean variable to track whether the repository has been disposed.
        private bool disposedValue;

        /// <summary>
        /// Constructor to initialize the repository with a given IDbFactory.
        /// </summary>
        /// <param name="dbFactory">An IDbFactory instance used to create the DbContext.</param>
        protected BaseRepository(IDbFactory dbFactory)
        {
            // Assign the IDbFactory instance to the DbFactory property.
            DbFactory = dbFactory;

            // Initialize the DbSet<T> for the entity type T.
            _dbset = Context.Set<T>();
        }

        /// <summary>
        /// Property to get the IDbFactory instance used to create the DbContext.
        /// </summary>
        protected IDbFactory DbFactory { get; private set; }

        /// <summary>
        /// Property to get the DbContext instance, creating it if it does not already exist.
        /// </summary>
        protected DbContext Context
        {
            get
            {
                // Return the existing DbContext or create a new one using the DbFactory.
                return _context ?? (_context = DbFactory.Get());
            }
        }

        // Asynchronous method to add a new entity to the DbSet.
        public virtual async void Add(T entity)
        {
            // Set the entity state to Added.
            _context.Entry(entity).State = EntityState.Added;

            // Save changes asynchronously.
            await _context.SaveChangesAsync();
        }

        // Asynchronous method to update an existing entity in the DbSet.
        public virtual async void Update(T entity)
        {
            // Set the entity state to Modified.
            _context.Entry(entity).State = EntityState.Modified;

            // Save changes asynchronously.
            await _context.SaveChangesAsync();
        }

        // Method to delete an entity from the DbSet.
        public virtual void Delete(T entity)
        {
            // Remove the entity from the DbSet.
            _dbset.Remove(entity);
        }

        // Method to delete entities that match a given predicate from the DbSet.
        public void Delete(Expression<Func<T, bool>> where)
        {
            // Get the entities that match the predicate.
            IEnumerable<T> objects = _dbset.Where(where).AsEnumerable();

            // Remove each entity from the DbSet.
            foreach (T obj in objects)
                _dbset.Remove(obj);
        }

        // Method to get an entity by its ID.
        public virtual T GetById(long id)
        {
            // Find and return the entity with the specified ID.
            return _dbset.Find(id);
        }

        // Method to get all entities from the DbSet.
        public virtual IEnumerable<T> GetAll()
        {
            // Return all entities as a list.
            return _dbset.ToList();
        }

        // Method to get entities that match a given predicate as an IQueryable.
        public virtual IQueryable<T> Get(Expression<Func<T, bool>> where)
        {
            // Return an IQueryable of entities that match the predicate.
            return _dbset.AsQueryable().Where(where);
        }

        // Method to get a single entity that matches a given predicate.
        public T GetSingle(Expression<Func<T, bool>> where)
        {
            // Return the first entity that matches the predicate or null if none is found.
            return _dbset.Where(where).FirstOrDefault();
        }

        // Protected method to dispose of resources.
        protected virtual void Dispose(bool disposing)
        {
            // Check if the repository has already been disposed.
            if (!disposedValue)
            {
                // If disposing is true, perform managed resource cleanup.
                if (disposing)
                {
                    // Dispose of managed resources here if needed.
                }

                // Mark the repository as disposed.
                disposedValue = true;
            }
        }

        // Public method to dispose of the repository.
        public void Dispose()
        {
            // Call the protected Dispose method with disposing set to true.
            Dispose(disposing: true);

            // Suppress finalization of this object.
            GC.SuppressFinalize(this);
        }
    }
}
