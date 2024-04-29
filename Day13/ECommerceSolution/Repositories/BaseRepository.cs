using ECommerceApp.Entities;

namespace ECommerceApp.Repositories;

/// <summary>
/// A base repository providing basic CRUD operations for entities implementing the IEntity interface.
/// </summary>
/// <typeparam name="TBaseEntity">The type of entity.</typeparam>
public abstract class BaseRepository<TBaseEntity> : IBaseRepository<TBaseEntity> where TBaseEntity : IEntity
{
    protected readonly List<TBaseEntity> Entities = new ();
    private readonly object _lock = new ();

    /// <summary>
    /// Retrieves an entity by its unique identifier asynchronously.
    /// </summary>
    /// <param name="id">The unique identifier of the entity to retrieve.</param>
    /// <returns>The entity with the specified identifier.</returns>
    /// <exception cref="KeyNotFoundException">Thrown if the entity with the specified identifier is not found.</exception>
    public async Task<TBaseEntity> GetByIdAsync(int id)
    {
        lock (_lock)
        {
            var entity = Entities.FirstOrDefault(e => e.Id == id);
            if (entity == null)
                throw new KeyNotFoundException($"{typeof(TBaseEntity)} with key {id} not found!!!");
            return entity;
        }
    }

    /// <summary>
    /// Retrieves all entities asynchronously.
    /// </summary>
    /// <returns>A list of all entities.</returns>
    public async Task<List<TBaseEntity>> GetAllAsync()
    {
        lock (_lock)
        {
            Entities.Sort();
            return Entities.ToList();
        }
    }

    /// <summary>
    /// Adds a new entity asynchronously.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    /// <returns>The added entity.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the provided entity is null.</exception>
    public async Task<TBaseEntity> AddAsync(TBaseEntity entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity), $"{typeof(TBaseEntity)} cannot be null.");

        lock (_lock)
        {
            var currSeq = 1;
            while (Entities.Any(e => e.Id == currSeq))
                currSeq++;
            entity.Id = currSeq;

            Entities.Add(entity);
            return entity;
        }
    }

    /// <summary>
    /// Updates an existing entity asynchronously.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    /// <returns>The updated entity.</returns>
    public async Task<TBaseEntity> UpdateAsync(TBaseEntity entity)
    {
        lock (_lock)
        {
            var existingEntity = GetByIdAsync(entity.Id).Result;
            if (existingEntity != null)
            {
                var index = Entities.IndexOf(existingEntity);
                Entities[index] = entity;
            }

            return entity;
        }
    }

    /// <summary>
    /// Deletes an entity by its unique identifier asynchronously.
    /// </summary>
    /// <param name="id">The unique identifier of the entity to delete.</param>
    public async Task DeleteAsync(int id)
    {
        lock (_lock)
        {
            var entityToRemove = GetByIdAsync(id).Result;
            if (entityToRemove != null)
            {
                Entities.Remove(entityToRemove);
            }
        }
    }
}