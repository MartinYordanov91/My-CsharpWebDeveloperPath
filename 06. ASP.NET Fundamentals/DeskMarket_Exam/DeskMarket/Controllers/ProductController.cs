using DeskMarket.Data.Models;
using DeskMarket.Models;
using DeskMarket.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DeskMarket.Controllers;

[Authorize]
public class ProductController(IProductService service) : BaseController
{

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {

        var userId = GetUserId();

        var model = await service.GetAllProductsAsync(userId);
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Add()
    {
        var model = await service.GetAddViewModelAsync();

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Add(ProductAddViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        if (!service.isDataValid(model.AddedOn))
        {
            return View(model);
        }

        var userId = GetUserId();
        await service.AddProductAsync(model, userId);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Cart()
    {
        string userId = GetUserId();

        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized();
        }

        var model = await service.MyCartProductsAsync(userId);
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> AddToCart(int id)
    {
        Product product = await service.GetProductByIdAsync(id);

        if (product == null)
        {
            return RedirectToAction(nameof(Index));
        }

        string userId = GetUserId();

        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized();
        }

        await service.AddToMyCartAsync(product, userId);

        return RedirectToAction(nameof(Cart));
    }

    [HttpPost]
    public async Task<IActionResult> RemoveFromCart(int id)
    {
        Product product = await service.GetProductByIdAsync(id);

        if (product == null)
        {
            return RedirectToAction(nameof(Cart));
        }

        string userId = GetUserId();

        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized();
        }

        await service.RemoveFromCartAsync(userId, product);
        return RedirectToAction(nameof(Cart));
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var userId = GetUserId();

        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized();
        }

        var model = await service.GetProductDetailsViewAsync(id, userId);
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int Id)
    {

        ProductEditViewModel model = await service.GetEditViewModelAsync(Id);

        if (model == null)
        {
            return BadRequest();
        }

        string userId = GetUserId();

        if (string.IsNullOrEmpty(userId) || model.SellerId != userId)
        {
            return Unauthorized();
        }

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ProductEditViewModel model, int id)
    {
        Product product = await service.GetProductByIdAsync(id);

        if (product == null)
        {
            return BadRequest();
        }

        var userId = GetUserId();

        if (string.IsNullOrEmpty(userId) && model.SellerId != userId)
        {
            return Unauthorized();
        }

        await service.EditModelAsync(model, product);
        return RedirectToAction("Details", new { id });
    }

    [HttpGet]

    public async Task<IActionResult> Delete(int id)
    {
        Product product = await service.GetProductByIdAsync(id);

        if (product == null)
        {
            return BadRequest();
        }

        ProductDeleteViewModel model = new ProductDeleteViewModel()
        {
            Id = id,
            ProductName = product.ProductName,
            Seller = GetUserName(),
            SellerId = GetUserId(),

        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(ProductDeleteViewModel model , int id)
    {
        Product product = await service.GetProductByIdAsync(id);

        if (product == null)
        {
            return BadRequest();
        }

        await service.SoftDeliteAsync(product);
        return RedirectToAction(nameof(Index));
    }
}


