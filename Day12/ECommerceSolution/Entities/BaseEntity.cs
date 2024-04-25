namespace ECommerceApp.Entities;

/// <summary>
/// Base entity Implements IEntity
/// Only carries Id -> can corelate with most of the CRUD operations
/// </summary>
public abstract class BaseEntity : IEntity
{
    public int Id { get; set; }

    /// <summary>
    ///  Compares Id from Base Entity
    /// </summary>
    /// <param name="obj">Any object reference</param>
    /// <returns>comparision status</returns>
    public override bool Equals(object? obj)
    {
        var item = obj as BaseEntity;
        return item != null && item.Id.Equals(Id);
    }
}