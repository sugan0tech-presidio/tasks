namespace AwesomePizzas.Services;

public interface IBaseService<TBaseEntity>
{
    public Task<TBaseEntity> GetById(int id);
    public Task<List<TBaseEntity>> GetAll();
    public Task<TBaseEntity> Add(TBaseEntity entity);
    public Task<TBaseEntity> Update(TBaseEntity entity);
    public Task<bool> Delete(int id);
}