using ECommerceApp.Entities;

namespace ECommerceApp.Repositories
{
    public abstract class BaseRepository<TBaseEntity> : IBaseRepository<TBaseEntity> where TBaseEntity : IEntity
    {
        protected readonly List<TBaseEntity> Entities = new List<TBaseEntity>();
        private readonly object _lock = new object();

        public async Task<TBaseEntity> GetByIdAsync(int id)
        {
            lock (_lock)
            {
                var entity = Entities.FirstOrDefault(e => e.Id == id);
                if (entity == null)
                    throw new KeyNotFoundException($"{GetType()} with key {id} not found!!!");
                return entity;
            }
        }

        public async Task<List<TBaseEntity>> GetAllAsync()
        {
            lock (_lock)
            {
                Entities.Sort();
                return Entities.ToList();
            }
        }

        public async Task<TBaseEntity> AddAsync(TBaseEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), $"{GetType()} cannot be null.");

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
}
