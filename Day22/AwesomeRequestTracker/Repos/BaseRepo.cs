using AwesomeRequestTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace AwesomeRequestTracker.Repos;

/// <summary>
/// A base repository implementation for entities.
/// </summary>
/// <typeparam name="TBaseEntity">The type of the entity.</typeparam>
public abstract class BaseRepo<TBaseEntity> : IBaseRepo<TBaseEntity> where TBaseEntity : BaseEntity
{
    protected BaseRepo(AwesomeRequestTrackerContext context)
    {
        _context = context;
    }

    protected readonly AwesomeRequestTrackerContext _context;
    private readonly object _lock = new ();

    /// <summary>
    /// Retrieves an entity by its unique identifier asynchronously.
    /// </summary>
    /// <param name="id">The unique identifier of the entity to retrieve.</param>
    /// <returns>The entity with the specified identifier.</returns>
    /// <exception cref="KeyNotFoundException">Thrown if the entity with the specified identifier is not found.</exception>
    public async Task<TBaseEntity> GetById(int id)
    {
        lock (_lock)
        {
            var entity = _context.Set<TBaseEntity>().SingleOrDefault(entity => entity.Id.Equals(id));
            if (entity == null)
                throw new KeyNotFoundException($"{typeof(TBaseEntity)} with key {id} not found!!!");
            return entity;
        }
    }

    /// <summary>
    /// Retrieves all entities asynchronously.
    /// </summary>
    /// <returns>A list of all entities.</returns>
    public async Task<List<TBaseEntity>> GetAll()
    {
        lock (_lock)
        {
            return _context.Set<TBaseEntity>().ToList();
        }
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
            throw new ArgumentNullException(nameof(entity), $"{typeof(TBaseEntity)} cannot be null.");
        //
        // try
        // {
        //     entity.Id = GetAll().Result.Max(entity => entity.Id) + 1;
        // }
        // catch (InvalidOperationException e)
        // {
        //     entity.Id = 1;
        // }
        
        lock (_lock)
        {
            _context.Add(entity);
            _context.SaveChanges();
            return entity;
        }
    }

    /// <summary>
    /// Updates an existing entity asynchronously.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    /// <returns>The updated entity.</returns>
    public async Task<TBaseEntity> Update(TBaseEntity updateEntity)
    {
        lock (_lock)
        {
            var entity = GetById(updateEntity.Id).Result;
            if (entity != null)
            {
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChangesAsync();
            }
            return entity;
        }
    }

    /// <summary>
    /// Deletes an entity by its unique identifier asynchronously.
    /// </summary>
    /// <param name="id">The unique identifier of the entity to delete.</param>
    public async Task<TBaseEntity> DeleteById(int id)
    {
        lock (_lock)
        {
            var entity = GetById(id).Result;
            if (entity != null)
            {
                _context.Set<TBaseEntity>().Remove(entity);
                _context.SaveChangesAsync();
            }
            return entity;        }
    }
}