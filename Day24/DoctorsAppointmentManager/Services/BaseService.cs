using DoctorsAppointmentManager.Models;
using DoctorsAppointmentManager.Repos;

namespace DoctorsAppointmentManager.Services;

/// <summary>
/// A base service implementation for entities.
/// </summary>
/// <typeparam name="TBaseEntity">The type of the entity.</typeparam>
public abstract class BaseService<TBaseEntity> : IService<TBaseEntity> where TBaseEntity : BaseEntity
{
    protected readonly IBaseRepo<TBaseEntity> Repository;

    /// <summary>
    /// Constructs a new instance of the BaseService class.
    /// </summary>
    /// <param name="repository">The repository instance to be used by the service.</param>
    /// <exception cref="ArgumentNullException">Thrown if the provided repository is null.</exception>
    protected BaseService(IBaseRepo<TBaseEntity> repository)
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
    public async Task<TBaseEntity> GetById(int id)
    {
        try
        {
            return await Repository.GetById(id);
        }
        catch (KeyNotFoundException)
        {
            throw new KeyNotFoundException($"Failed to retrieve {typeof(TBaseEntity).Name} with ID {id}.");
        }
    }

    /// <summary>
    /// Retrieves all entities asynchronously.
    /// </summary>
    /// <returns>A list of all entities.</returns>
    public async Task<List<TBaseEntity>> GetAll()
    {
        return await Repository.GetAll();
    }

    /// <summary>
    /// Adds a new entity asynchronously.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    /// <returns>The added entity.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the provided entity is null.</exception>
    public async Task<TBaseEntity> Add(TBaseEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException($"Entity {typeof(TBaseEntity).Name} is null");
        }
        return await Repository.Add(entity);
    }

    /// <summary>
    /// Updates an existing entity asynchronously.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    /// <returns>The updated entity.</returns>
    /// <exception cref="KeyNotFoundException">Thrown if the entity to update is not found.</exception>
    public async Task<TBaseEntity> Update(TBaseEntity entity)
    {
        try
        {
            return await Repository.Update(entity);
        }
        catch (KeyNotFoundException)
        {
            throw new KeyNotFoundException($"Failed to update {typeof(TBaseEntity).Name}. Entity not found.");
        }
    }

    /// <summary>
    /// Deletes an entity by its unique identifier asynchronously.
    /// </summary>
    /// <param name="id">The unique identifier of the entity to delete.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    /// <exception cref="KeyNotFoundException">Thrown if the entity to delete is not found.</exception>
    public virtual async Task Delete(int id)
    {
        try
        {
            await Repository.DeleteById(id);
        }
        catch (KeyNotFoundException)
        {
            throw new KeyNotFoundException($"Failed to delete {typeof(TBaseEntity).Name}. Entity not found.");
        }
    }
}