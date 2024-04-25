using ECommerceApp.Entities;
using ECommerceApp.Repositories;

namespace ECommerceApp.Services;

public class CartItemService: BaseService<CartItem>
{
    public CartItemService(BaseRepository<CartItem> repository) : base(repository)
    {
    }
}