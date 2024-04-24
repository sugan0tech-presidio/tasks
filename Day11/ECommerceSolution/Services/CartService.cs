using ECommerceApp.Entities;
using ECommerceApp.Repositories;

namespace ECommerceApp.Services;

public class CartService: BaseService<Cart>
{
    public CartService(BaseRepository<Cart> repository) : base(repository)
    {
    }
}