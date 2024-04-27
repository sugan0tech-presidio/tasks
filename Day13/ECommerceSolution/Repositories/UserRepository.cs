using ECommerceApp.Entities;

namespace ECommerceApp.Repositories;

public class UserRepository : BaseRepository<User>
{
    /// <summary>
    /// Adds a new entity.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    /// <returns>The added entity.</returns>
    /// <exception cref="ArgumentNullException">Thrown if the entity is null.</exception>
    public User Add(User entity)
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
}