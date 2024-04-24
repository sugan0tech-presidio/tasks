namespace ECommerceApp.Repositories;

public interface IBaseRepository<TEntity>
{
    TEntity GetById(int id);
    List<TEntity> GetAll();
    TEntity Add(TEntity entity);
    TEntity Update(TEntity entity);
    void Delete(int id);
}