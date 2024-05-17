using AwesomeRequestTracker.Models;

namespace AwesomeRequestTracker.Services
{
    /// <summary>
    /// A base service interface for entities.
    /// </summary>
    /// <typeparam name="TBaseEntity">The type of the entity.</typeparam>
    public interface IBaseService<TBaseEntity> where TBaseEntity : BaseEntity
    {
        /// <summary>
        /// Retrieves an entity by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the entity to retrieve.</param>
        /// <returns>The entity with the specified identifier.</returns>
        /// <exception cref="KeyNotFoundException">Thrown if the entity with the specified identifier is not found.</exception>
        Task<TBaseEntity> GetById(int id);

        /// <summary>
        /// Retrieves all entities asynchronously.
        /// </summary>
        /// <returns>A list of all entities.</returns>
        Task<List<TBaseEntity>> GetAll();

        /// <summary>
        /// Adds a new entity asynchronously.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>The added entity.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the provided entity is null.</exception>
        Task<TBaseEntity> Add(TBaseEntity entity);

        /// <summary>
        /// Updates an existing entity asynchronously.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>The updated entity.</returns>
        /// <exception cref="KeyNotFoundException">Thrown if the entity to update is not found.</exception>
        Task<TBaseEntity> Update(TBaseEntity entity);

        /// <summary>
        /// Deletes an entity by its unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the entity to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        /// <exception cref="KeyNotFoundException">Thrown if the entity to delete is not found.</exception>
        Task Delete(int id);
    }
}
