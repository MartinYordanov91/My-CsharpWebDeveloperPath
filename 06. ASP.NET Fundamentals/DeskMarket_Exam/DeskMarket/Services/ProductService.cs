using DeskMarket.Data;
using DeskMarket.Data.Models;
using DeskMarket.Models;
using DeskMarket.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using static DeskMarket.Common.ValidationConstants;

namespace DeskMarket.Services;

public class ProductService(ApplicationDbContext context) : IProductService
{
    public async Task AddProductAsync(ProductAddViewModel model, string userId)
    {
        var isValid = DateTime.TryParseExact(model.AddedOn, ProductAddedOnStringFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result);


        if (!isValid)
        {
            throw new InvalidOperationException("Invalid DateTime format");

        }

        Product product = new Product()
        {
            ProductName = model.ProductName,
            Description = model.Description,
            CategoryId = model.CategoryId,
            ImageUrl = model.ImageUrl,
            AddedOn = result,
            Price = model.Price,
            SellerId = userId,
        };

        await context.Products.AddAsync(product);
        await context.SaveChangesAsync();
    }

    public async Task AddToMyCartAsync(Product product, string userId)
    {
        ProductClient productClient = new ProductClient()
        {
            ClientId = userId,
            ProductId = product.Id,
        };

        await context.ProductsClients.AddAsync(productClient);
        await context.SaveChangesAsync();
    }

    public async Task EditModelAsync(ProductEditViewModel model, Product product)
    {
        var isValid = DateTime.TryParseExact(model.AddedOn, ProductAddedOnStringFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result);


        if (!isValid)
        {
            throw new InvalidOperationException("Invalid DateTime format");

        }

        product.ProductName = model.ProductName;
        product.Description = model.Description;
        product.CategoryId = model.CategoryId;
        product.ImageUrl = model.ImageUrl;
        product.AddedOn = result;
        product.Price = model.Price;
        product.SellerId = model.SellerId;


        await context.SaveChangesAsync();
    }

    public async Task<ProductAddViewModel> GetAddViewModelAsync()
    {
        var categories = await context.Categories
            .Select(c => new CategoryViewModel()
            {
                Id = c.Id,
                Name = c.Name,
            })
            .ToListAsync();

        var model = new ProductAddViewModel()
        {
            Categories = categories
        };

        return model;
    }

    public async Task<ICollection<ProductViewModel>> GetAllProductsAsync(string userId)
    {
        if (!string.IsNullOrEmpty(userId))
        {

            var authorizeModel = await context.Products
                 .Where(p => p.IsDeleted == false)
                 .AsNoTracking()
                 .Select(p => new ProductViewModel()
                 {
                     Id = p.Id,
                     ImageUrl = p.ImageUrl,
                     Price = p.Price,
                     ProductName = p.ProductName,
                     IsSeller = p.SellerId == userId,
                     HasBought = p.ProductsClients.Any(pc => pc.ClientId == userId && pc.ProductId == p.Id),
                 })
                 .ToListAsync();

            return authorizeModel;
        }

        return await context.Products
                 .Where(p => p.IsDeleted == false)
                 .AsNoTracking()
                 .Select(p => new ProductViewModel()
                 {
                     Id = p.Id,
                     ImageUrl = p.ImageUrl,
                     Price = p.Price,
                     ProductName = p.ProductName,
                     IsSeller = false,
                     HasBought = false,
                 })
                 .ToListAsync();
    }

    public async Task<ProductEditViewModel> GetEditViewModelAsync(int productId)
    {
        var categories = await context.Categories
            .Select(c => new CategoryViewModel()
            {
                Id = c.Id,
                Name = c.Name,
            })
            .ToListAsync();

        var model = await context.Products.FindAsync(productId);

        if (model == null)
        {
            throw new ArgumentNullException("Product Missing");
        }

        ProductEditViewModel viewModel = new ProductEditViewModel()
        {
            ProductName = model.ProductName,
            SellerId = model.SellerId,
            AddedOn = model.AddedOn.ToString(ProductAddedOnStringFormat),
            Description = model.Description,
            Categories = categories,
            CategoryId = model.CategoryId,
            ImageUrl = model.ImageUrl,
            Price = model.Price,
        };

        return viewModel;
    }

    public async Task<Product> GetProductByIdAsync(int id)
    {
        return await context.Products.FindAsync(id);
    }

    public async Task<ProductDetailsViewModel> GetProductDetailsViewAsync(int productId, string userId)
    {
        var model = await context.Products
             .Where(p => p.Id == productId)
             .Include(p => p.Seller)
             .Include(c => c.Category)
             .Select(p => new ProductDetailsViewModel()
             {
                 Id = p.Id,
                 ImageUrl = p.ImageUrl,
                 ProductName = p.ProductName,
                 Description = p.Description,
                 Price = p.Price,
                 AddedOn = p.AddedOn.ToString(ProductAddedOnStringFormat),
                 Seller = p.Seller.UserName,
                 CategoryName = p.Category.Name,
                 IsSeller = p.SellerId == userId,
                 HasBought = p.ProductsClients.Any(pc => pc.ClientId == userId && pc.ProductId == p.Id),

             })
             .FirstOrDefaultAsync();

        return model;
    }

    public bool isDataValid(string data)
    {
        if (DateTime.TryParseExact(data, ProductAddedOnStringFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
        {
            return true;
        }

        return false;
    }

    public async Task<ICollection<ProductViewModel>> MyCartProductsAsync(string userId)
    {
        return await context.ProductsClients
            .Where(pc => pc.ClientId == userId)
            .Where(p => p.Product.IsDeleted == false)
            .Select(pc => new ProductViewModel()
            {
                Id = pc.Product.Id,
                ImageUrl = pc.Product.ImageUrl,
                Price = pc.Product.Price,
                ProductName = pc.Product.ProductName,
                IsSeller = false,
                HasBought = true,
            })
            .ToListAsync();
    }

    public async Task RemoveFromCartAsync(string userId, Product product)
    {
        var productClient = await context.ProductsClients
            .Where(pc => pc.ClientId == userId && pc.ProductId == product.Id)
            .FirstOrDefaultAsync();

        if (productClient == null)
        {
            throw new InvalidOperationException("Product cant find");
        }

        context.ProductsClients.Remove(productClient);
        await context.SaveChangesAsync();
    }

    public async Task SoftDeliteAsync(Product product)
    {
        product.IsDeleted = true;

        await context.SaveChangesAsync();
    }
}
