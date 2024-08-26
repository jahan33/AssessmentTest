using System.Linq.Expressions;

namespace DataAccess.IRepositories
{
    // Define a public interface named IRepository with a generic type parameter T that inherits from IDisposable.
    public interface IRepository<T> : IDisposable
    {
        /// <summary>
        /// Adds a new entity of type T to the repository.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        void Add(T entity);

        /// <summary>
        /// Updates an existing entity of type T in the repository.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        void Update(T entity);

        /// <summary>
        /// Deletes an entity of type T from the repository.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        void Delete(T entity);

        /// <summary>
        /// Deletes entities that match the given predicate from the repository.
        /// </summary>
        /// <param name="where">A predicate to filter the entities to delete.</param>
        void Delete(Expression<Func<T, bool>> where);

        /// <summary>
        /// Retrieves an entity of type T from the repository by its ID.
        /// </summary>
        /// <param name="id">The ID of the entity.</param>
        /// <returns>Returns the entity with the specified ID.</returns>
        T GetById(long id);

        /// <summary>
        /// Retrieves a single entity of type T that matches the given predicate.
        /// </summary>
        /// <param name="where">A predicate to filter the entity.</param>
        /// <returns>Returns the first entity that matches the predicate.</returns>
        T GetSingle(Expression<Func<T, bool>> where);

        /// <summary>
        /// Retrieves all entities of type T from the repository.
        /// </summary>
        /// <returns>Returns an IEnumerable of all entities.</returns>
        IEnumerable<T> GetAll();

        // IQueryable<T> GetAllTemp();

        /// <summary>
        /// Retrieves entities of type T that match the given predicate as an IQueryable.
        /// </summary>
        /// <param name="where">A predicate to filter the entities.</param>
        /// <returns>Returns an IQueryable of entities that match the predicate.</returns>
        IQueryable<T> Get(Expression<Func<T, bool>> where);
    }
}
