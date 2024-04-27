using ECommerceApp.Entities;
using ECommerceApp.Services;

namespace ECommerceApp.Controllers;

public class ProductController: BaseController<Product>
{
    public ProductController(BaseService<Product> entityService) : base(entityService)
    {
    }

    protected override void AddEntityMember()
    {
        var name = GetFromConsole<string>($"{_entityName} Name");
        var price = GetFromConsole<double>("Price Value");
        var stock = GetFromConsole<int>("Stock Value");
        var brand = GetFromConsole<string>("Brand");
        var category = GetFromConsole<string>("Category");

        Product product = new Product
        {
            Name = name,
            Price = price,
            Stock = stock,
            Brand = brand,
            Category = category
        };
        _entityService.Add(product);
    }

    protected override void UpdateEntityMember()
    {

        var id = GetFromConsole<int>($"{_entityName} Id");
        var product = _entityService.GetById(id);
        
        Console.WriteLine("Enter the field's to update:");
        Console.WriteLine("1. Name");
        Console.WriteLine("2. Price");
        Console.WriteLine("3. Stock");

        var option = GetFromConsole<int>("Option");

        switch (option)
        {
            case 1:
                product.Name = GetFromConsole<string>("Updated  Name");
                break;
            case 2:
                product.Price = GetFromConsole<double>("Updated Price Value");
                break;
            case 3:
                product.Stock = GetFromConsole<int>("Updated Quantity");
                break;
            default:
                Console.WriteLine("Invalid Option");
                break;
        }

        _entityService.Update(product);

    }
}