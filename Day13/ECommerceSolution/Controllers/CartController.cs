using System.Xml;
using ECommerceApp.Entities;
using ECommerceApp.Services;

namespace ECommerceApp.Controllers;

public class CartController : BaseController<Cart>
{
    private readonly UserService UserService;
    private readonly ProductService ProductService;
    private readonly CartService CartService;
    private readonly User user;

    public CartController(BaseService<Cart> entityService, UserService userService, ProductService productService) :
        base(entityService)
    {
        UserService = userService;
        ProductService = productService;
        CartService = entityService as CartService;
    }

    private void ShowMainMenu()
    {
        while (true)
        {
            Console.WriteLine($"\n{_entityName}'s Menu:");
            Console.WriteLine("1. List CartItems's ");
            Console.WriteLine("2. Add Item ");
            Console.WriteLine("3. Update Cart Item");
            Console.WriteLine("4. Delete Cart Item");
            Console.WriteLine("5. Clear Console");
            Console.WriteLine("6. exit to Main Menu");

            Console.Write("\nEnter your choice: ");
            var choice = Console.ReadLine();

            try
            {
                switch (choice)
                {
                    case "1":
                        ListCartItem();
                        break;
                    case "2":
                        AddCartItem();
                        break;
                    case "3":
                        UpdateItem();
                        break;
                    case "4":
                        DeleteItem();
                        break;
                    case "5":
                        Console.Clear();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine(e);
            }
        }
    }


    private void ListCartItem()
    {
        foreach (var cartItem in user.Cart.Items)
        {
            Console.WriteLine(cartItem);
        }
    }

    private void AddCartItem()
    {
        // todo to be done via login
        var userId = GetFromConsole<int>("User Id");

        var user = UserService.GetById(userId);

        Cart cart = new Cart(user);

        var productId = GetFromConsole<int>("Product Id");
        var quantity = GetFromConsole<int>("Quantity");

        CartService.AddItemToCart(cart.Id, ProductService.GetById(productId), quantity);
        _entityService.Add(cart);
    }

    private void DeleteItem()
    {
        var productId = GetFromConsole<int>("Product Id");
        CartService.RemoveItemFromCart(user.Cart.Id, productId);
    }

    private void UpdateItem()
    {
        var productId = GetFromConsole<int>("Product Id");
        var quantity = GetFromConsole<int>("Quantity");
        CartService.UpdateCartItemQuantity(user.Cart.Id, productId, quantity);
    }
}