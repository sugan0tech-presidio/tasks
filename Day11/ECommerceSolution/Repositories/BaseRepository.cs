using System;
using System.Collections.Generic;
using System.Linq;

using ECommerceApp.Entities;

namespace ECommerceApp.Repositories
{
    /// <summary>
    /// A base repository implementation for entities.
    /// </summary>
    /// <typeparam name="TBaseEntity">The type of the entity.</typeparam>
    public abstract class BaseRepository<TBaseEntity> : IBaseRepository<TBaseEntity> where TBaseEntity : IEntity
    {
        /// <summary>
        /// The list storing entities.
        /// </summary>
        protected readonly List<TBaseEntity> Entities = new();

        /// <summary>
        /// Retrieves an entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the entity to retrieve.</param>
        /// <returns>The entity with the specified ID.</returns>
        /// <exception cref="KeyNotFoundException">Thrown if the entity with the specified ID is not found.</exception>
        public TBaseEntity GetById(int id)
        {
            var entity = Entities.FirstOrDefault(e => e.Id == id);
            if (entity == null)
                throw new KeyNotFoundException($"{GetType()} with key {id} not found!!!");

            return entity;
        }

        /// <summary>
        /// Retrieves all entities.
        /// </summary>
        /// <returns>A list of all entities.</returns>
        public List<TBaseEntity> GetAll()
        {
            return Entities.ToList();
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
            while (Entities.Any(e => e.Id == currSeq))
                currSeq++;
            entity.Id = currSeq;

            Entities.Add(entity);
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
            var existingEntity = GetById(entity.Id);
            if (existingEntity != null)
            {
                var index = Entities.IndexOf(existingEntity);
                Entities[index] = entity;
            }

            return entity;
        }

        /// <summary>
        /// Deletes an entity by its ID.
        /// </summary>
        /// <param name="id">The ID of the entity to delete.</param>
        /// <exception cref="KeyNotFoundException">Thrown if the entity with the specified ID is not found.</exception>
        public void Delete(int id)
        {
            var entityToRemove = GetById(id);
            if (entityToRemove != null)
            {
                Entities.Remove(entityToRemove);
            }
        }
    }
}
