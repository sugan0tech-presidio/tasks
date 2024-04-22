namespace PharmacyModels;

public abstract class BaseEntity: IEntity
{
    
    protected BaseEntity()
    {
    }

    protected BaseEntity(int id)
    {
        Id = id;
    }

    public int Id { set; get; }
}