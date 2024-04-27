using ECommerceApp.Entities;
using ECommerceApp.Services;

namespace ECommerceApp.Controllers;

public class CartController : BaseController<Cart>
{
    private readonly UserService UserService;
    private readonly ProductService ProductService;
    private readonly CartService CartService;
    private User user;

    public CartController(BaseService<Cart> entityService, UserService userService, ProductService productService) :
        base(entityService)
    {
        UserService = userService;
        ProductService = productService;
        CartService = entityService as CartService;
    }

    public new void Run()
    {
        if (AddUser())
        {
            Console.WriteLine($"Successfully Logged as {user.Name}");
            ShowMainMenu();
        }
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
                        user = null;
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

    private bool AddUser()
    {
        var id = GetFromConsole<int>("User Id");
        try
        {
            user = UserService.GetByIdAsync(id).Result;
            return true;
        }
        catch (KeyNotFoundException e)
        {
            Console.WriteLine(e);
        }

        return false;
    }

    private void ListCartItem()
    {
        Console.WriteLine("here at lastCartItem");
        if (user.Cart != null || user.Cart.Items.Count > 0)
        {
            foreach (var cartItem in user.Cart.Items)
            {
                Console.WriteLine(cartItem);
            }
        }
        else
        {
            Console.WriteLine("No items in cart");
        }
    }

    private void AddCartItem()
    {
        // todo to be done via login
        var userId = this.user.Id;

        var user = UserService.GetByIdAsync(userId).Result;

        Cart cart;
        if (user.Cart == null)
        {
            cart = CartService.AddAsync(new Cart()).Result;
        }
        else
            cart = user.Cart;

        user.Cart = cart;

        var productId = GetFromConsole<int>("Product Id");
        var quantity = GetFromConsole<int>("Quantity");

        user.Cart = CartService.AddItemToCart(cart.Id, ProductService.GetByIdAsync(productId).Result, quantity).Result;
        Console.WriteLine(user.Cart);
        UserService.UpdateAsync(user);
        _entityService.AddAsync(cart);
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