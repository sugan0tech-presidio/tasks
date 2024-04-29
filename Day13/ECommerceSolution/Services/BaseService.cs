using ECommerceApp.Entities;
using ECommerceApp.Repositories;

namespace ECommerceApp.Services;

/// <summary>
/// A base service implementation for entities.
/// </summary>
/// <typeparam name="TBaseEntity">The type of the entity.</typeparam>
public abstract class BaseService<TBaseEntity> where TBaseEntity : IEntity
{
    protected readonly BaseRepository<TBaseEntity> Repository;

    /// <summary>
    /// Constructs a new instance of the BaseService class.
    /// </summary>
    /// <param name="repository">The repository instance to be used by the service.</param>
    /// <exception cref="ArgumentNullException">Thrown if the provided repository is null.</exception>
    protected BaseService(BaseRepository<TBaseEntity> repository)
    {
        Repository = repository ?? throw new ArgumentNullException(nameof(repository),
            $"{typeof(BaseService<TBaseEntity>)} cannot be null.");
    }

    /// <summary>
    /// Retrieves an entity by its unique identifier asynchronously.
    /// </summary>
    /// <param name="id">The unique identifier of the entity to retrieve.</param>
    /// <returns>The entity with the specified identifier.</returns>
    /// <exception cref="KeyNotFoundException">Thrown if the entity with the specified identifier is not found.</exception>
    public async Task<TBaseEntity> GetByIdAsync(int id)
    {
        try
        {
            return await Repository.GetByIdAsync(id);
        }
        catch (KeyNotFoundException ex)
        {
            throw new KeyNotFoundException($"Failed to retrieve {typeof(TBaseEntity).Name} with ID {id}.", ex);
        }
    }

    /// <summary>
    /// Retrieves all entities asynchronously.
    /// </summary>
    /// <returns>A list of all entities.</returns>
    public async Task<List<TBaseEntity>> GetAllAsync()
    {
        return await Repository.GetAllAsync();
    }

    /// <summary>
    /// Adds a new entity asynchronously.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    /// <returns>The added entity.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the provided entity is null.</exception>
    public async Task<TBaseEntity> AddAsync(TBaseEntity entity)
    {
        try
        {
            return await Repository.AddAsync(entity);
        }
        catch (ArgumentNullException)
        {
            throw;
        }
    }

    /// <summary>
    /// Updates an existing entity asynchronously.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    /// <returns>The updated entity.</returns>
    /// <exception cref="KeyNotFoundException">Thrown if the entity to update is not found.</exception>
    public async Task<TBaseEntity> UpdateAsync(TBaseEntity entity)
    {
        try
        {
            return await Repository.UpdateAsync(entity);
        }
        catch (KeyNotFoundException ex)
        {
            throw new KeyNotFoundException($"Failed to update {typeof(TBaseEntity).Name}. Entity not found.", ex);
        }
    }

    /// <summary>
    /// Deletes an entity by its unique identifier asynchronously.
    /// </summary>
    /// <param name="id">The unique identifier of the entity to delete.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    /// <exception cref="KeyNotFoundException">Thrown if the entity to delete is not found.</exception>
    public virtual async Task DeleteAsync(int id)
    {
        try
        {
            await Repository.DeleteAsync(id);
        }
        catch (KeyNotFoundException ex)
        {
            throw new KeyNotFoundException($"Failed to delete {typeof(TBaseEntity).Name}. Entity not found.", ex);
        }
    }
}