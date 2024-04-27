using ECommerceApp.Entities;
using ECommerceApp.Services;

namespace ECommerceApp.Controllers;

public class UserController: BaseController<User>
{
    public UserController(BaseService<User> entityService) : base(entityService)
    {
    }

    protected override void AddEntityMember()
    {
        var name = GetFromConsole<string>($"{_entityName} Name");
        var email = GetFromConsole<string>("Email");
        var address = GetFromConsole<string>("Address");

        User user = new User(name, email, address);
        _entityService.Add(user);
    }

    protected override void UpdateEntityMember()
    {

        var id = GetFromConsole<int>($"{_entityName} Id");
        var user = _entityService.GetById(id);
        
        Console.WriteLine("Enter the field's to update:");
        Console.WriteLine("1. Name");
        Console.WriteLine("2. Email");
        Console.WriteLine("3. Address");

        var option = GetFromConsole<int>("Option");

        switch (option)
        {
            case 1:
                user.Name = GetFromConsole<string>("Updated  Name");
                break;
            case 2:
                user.Email = GetFromConsole<string>("Updated Email");
                break;
            case 3:
                user.Address = GetFromConsole<string>("Updated Address");
                break;
            default:
                Console.WriteLine("Invalid Option");
                break;
        }

        _entityService.Update(user);

    }
}