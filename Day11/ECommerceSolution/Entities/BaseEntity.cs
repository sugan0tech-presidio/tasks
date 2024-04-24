namespace ECommerceApp.Entities;

public abstract class BaseEntity: IEntity
{
    public int Id { get; set; }
    
    public override bool Equals(object? obj)
    {
        var item = obj as BaseEntity;
        return item != null && item.Id.Equals(Id);
    }
}