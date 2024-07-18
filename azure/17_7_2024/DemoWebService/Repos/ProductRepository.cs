using DemoWebService.Models;
using DemoWebService.Services;
using Microsoft.EntityFrameworkCore;

namespace DemoWebService.Repos;

public class ProductRepository(ProductContext context, BlobService blobService) : IProductRepository
{
    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        var products = await context.Products.ToListAsync();
        foreach (var product in products)
        {
            product.PictureUrl = await blobService.GetBlobAsBase64StringAsync("products", product.PictureUrl.Split("/").Last());
        }
        return products;
    }

    public async Task<Product> GetProductByIdAsync(int productId)
    {
        var product = await context.Products.FindAsync(productId);
        if (product != null)
        {
            product.PictureUrl = await blobService.GetBlobAsBase64StringAsync("products", product.PictureUrl.Split("/").Last());
        }
        return product;
    }
}