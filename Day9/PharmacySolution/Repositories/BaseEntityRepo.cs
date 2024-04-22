using PharmacyModels;

namespace PharmacyManagement.Repositories;

public abstract class BaseEntityRepo<TBaseEntity> : IBaseRepo<TBaseEntity> where TBaseEntity : IEntity
{
    private readonly Dictionary<int, TBaseEntity> _entities = new ();

    public TBaseEntity GetById(int id)
    {
        if (_entities.TryGetValue(id, out var entity))
            throw new KeyNotFoundException($"{GetType()} with key {id} not found!!!");
        
        return entity;
    }

    public List<TBaseEntity> GetAll()
    {
        return _entities.Values.ToList();
    }

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

    public void Delete(int id)
    {
        if (!_entities.Remove(id))
        {
            throw new KeyNotFoundException("Entity not found.");
        }
    }
}