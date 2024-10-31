using DeskMarket.Data.Models;
using DeskMarket.Models;

namespace DeskMarket.Services.Contracts;

public interface IProductService
{
    Task<ICollection<ProductViewModel>> GetAllProductsAsync(string userId);


    Task<ProductAddViewModel> GetAddViewModelAsync();

    Task<ProductEditViewModel> GetEditViewModelAsync(int productId);

    Task EditModelAsync(ProductEditViewModel model , Product product);

    Task AddProductAsync(ProductAddViewModel model , string userId);

    bool isDataValid(string data);

    Task<Product> GetProductByIdAsync(int id);

    Task AddToMyCartAsync(Product product, string userId);

    Task<ICollection<ProductViewModel>> MyCartProductsAsync(string userId);

    Task RemoveFromCartAsync(string userId , Product product);

    Task<ProductDetailsViewModel> GetProductDetailsViewAsync(int productId, string userId);

    Task SoftDeliteAsync(Product product);
}
