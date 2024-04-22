using PharmacyManagement.Repositories;
using PharmacyModels;

/// <summary>
/// A base repository implementation for entities.
/// </summary>
/// <typeparam name="TBaseEntity">The type of the entity.</typeparam>
public abstract class BaseEntityRepo<TBaseEntity> : IBaseRepo<TBaseEntity> where TBaseEntity : IEntity
{
    /// <summary>
    /// The dictionary storing entities by their ID.
    /// </summary>
    protected static readonly Dictionary<int, TBaseEntity> _entities = new ();

    /// <summary>
    /// Retrieves an entity by its ID.
    /// </summary>
    /// <param name="id">The ID of the entity to retrieve.</param>
    /// <returns>The entity with the specified ID.</returns>
    /// <exception cref="KeyNotFoundException">Thrown if the entity with the specified ID is not found.</exception>
    public TBaseEntity GetById(int id)
    {
        if (_entities.TryGetValue(id, out var entity))
            throw new KeyNotFoundException($"{GetType()} with key {id} not found!!!");
        
        return entity;
    }

    /// <summary>
    /// Retrieves all entities.
    /// </summary>
    /// <returns>A list of all entities.</returns>
    public List<TBaseEntity> GetAll()
    {
        return _entities.Values.ToList();
    }

    /// <summary>
    /// Adds a new entity.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    /// <returns>The added entity.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the entity is null.</exception>
    public TBaseEntity Add(TBaseEntity entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity), $"{GetType()} cannot be null.");

        var currSeq = 1;
        while (_entities.ContainsKey(currSeq))
            currSeq++;
        entity.Id = currSeq;
        
        _entities.Add(currSeq, entity);
        return entity;
    }

    /// <summary>
    /// Updates an existing entity.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    /// <returns>The updated entity.</returns>
    /// <exception cref="KeyNotFoundException">Thrown if the entity to update is not found.</exception>
    public TBaseEntity Update(TBaseEntity entity)
    {
        var id = entity.Id;
        if (_entities.ContainsKey(id))
        {
            _entities[id] = entity;
        }
        else
        {
            throw new KeyNotFoundException("Entity not found.");
        }

        return _entities[id];
    }

    /// <summary>
    /// Deletes an entity by its ID.
    /// </summary>
    /// <param name="id">The ID of the entity to delete.</param>
    /// <exception cref="KeyNotFoundException">Thrown if the entity with the specified ID is not found.</exception>
    public void Delete(int id)
    {
        if (!_entities.Remove(id))
        {
            throw new KeyNotFoundException("Entity not found.");
        }
    }
}