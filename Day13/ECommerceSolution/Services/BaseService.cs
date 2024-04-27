using ECommerceApp.Entities;
using ECommerceApp.Repositories;

namespace ECommerceApp.Services
{
    /// <summary>
    /// A base service implementation for entities.
    /// </summary>
    /// <typeparam name="TBaseEntity">The type of the entity.</typeparam>
    public abstract class BaseService<TBaseEntity> where TBaseEntity : IEntity
    {
        protected readonly BaseRepository<TBaseEntity> Repository;

        protected BaseService(BaseRepository<TBaseEntity> repository)
        {
            Repository = repository ?? throw new ArgumentNullException(nameof(repository), $"{GetType()} cannot be null.");
        }

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

        public async Task<List<TBaseEntity>> GetAllAsync()
        {
            return await Repository.GetAllAsync();
        }

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
}
