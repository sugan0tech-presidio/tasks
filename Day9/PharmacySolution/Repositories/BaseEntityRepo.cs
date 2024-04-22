using PharmacyModels;

namespace PharmacyManagement.Repositories;

public abstract class BaseEntityRepo : IBaseRepo<BaseEntity>
{
    private readonly Dictionary<int, BaseEntity> _entities = new ();

    public BaseEntity GetById(int id)
    {
        if (_entities.TryGetValue(id, out var entity))
            throw new KeyNotFoundException($"{GetType()} with key {id} not found!!!");
        
        return entity;
    }

    public List<BaseEntity> GetAll()
    {
        return _entities.Values.ToList();
    }

    public BaseEntity Add(BaseEntity entity)
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

    public BaseEntity Update(BaseEntity entity)
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