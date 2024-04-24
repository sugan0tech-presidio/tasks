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
        private readonly BaseRepository<TBaseEntity> Repository;

        protected BaseService(BaseRepository<TBaseEntity> repository)
        {
            Repository = repository ?? throw new ArgumentNullException(nameof(repository), $"{GetType()} cannot be null.");
        }

        /// <summary>
        /// Retrieves an entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the entity to retrieve.</param>
        /// <returns>The entity with the specified ID.</returns>
        /// <exception cref="KeyNotFoundException">Thrown if the entity with the specified ID is not found.</exception>
        public virtual TBaseEntity GetById(int id)
        {
            try
            {
                return Repository.GetById(id);
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException($"Failed to retrieve {typeof(TBaseEntity).Name} with ID {id}.", ex);
            }
        }

        /// <summary>
        /// Retrieves all entities.
        /// </summary>
        /// <returns>A list of all entities.</returns>
        public virtual List<TBaseEntity> GetAll()
        {
            return Repository.GetAll();
        }

        /// <summary>
        /// Adds a new entity.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        /// <returns>The added entity.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the entity is null.</exception>
        public virtual TBaseEntity Add(TBaseEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), $"{typeof(TBaseEntity).Name} cannot be null.");

            try
            {
                return Repository.Add(entity);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to add {typeof(TBaseEntity).Name}.", ex);
            }
        }

        /// <summary>
        /// Updates an existing entity.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>The updated entity.</returns>
        /// <exception cref="KeyNotFoundException">Thrown if the entity to update is not found.</exception>
        public virtual TBaseEntity Update(TBaseEntity entity)
        {
            try
            {
                return Repository.Update(entity);
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException($"Failed to update {typeof(TBaseEntity).Name}. Entity not found.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update {typeof(TBaseEntity).Name}.", ex);
            }
        }

        /// <summary>
        /// Deletes an entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the entity to delete.</param>
        /// <exception cref="KeyNotFoundException">Thrown if the entity with the specified ID is not found.</exception>
        public virtual void Delete(int id)
        {
            try
            {
                Repository.Delete(id);
            }
            catch (KeyNotFoundException ex)
            {
                throw new KeyNotFoundException($"Failed to delete {typeof(TBaseEntity).Name}. Entity not found.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete {typeof(TBaseEntity).Name}.", ex);
            }
        }
    }
}
