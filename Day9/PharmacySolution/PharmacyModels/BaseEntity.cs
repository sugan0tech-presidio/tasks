namespace PharmacyModels;

public abstract class BaseEntity
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