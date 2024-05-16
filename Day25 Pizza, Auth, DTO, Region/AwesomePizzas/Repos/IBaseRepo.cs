namespace AwesomePizzas.Repos;

public interface IBaseRepo<TEntity>
{
    Task<TEntity> GetById(int id);
    Task<List<TEntity>> GetAll();
    Task<TEntity> Add(TEntity entity);
    Task<TEntity> Update(TEntity entity);
    Task<TEntity> DeleteById(int id);
}