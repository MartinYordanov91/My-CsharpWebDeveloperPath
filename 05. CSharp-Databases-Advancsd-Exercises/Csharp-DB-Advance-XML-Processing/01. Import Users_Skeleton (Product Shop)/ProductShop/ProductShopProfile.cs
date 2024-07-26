using AutoMapper;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop;

public class ProductShopProfile : Profile
{
    public ProductShopProfile()
    {
        // Userr
        this.CreateMap<UsersImportDto, User>();

        // Product
        this.CreateMap<ProductsImportDto, Product>();

        this.CreateMap<Product, ProductsRangeDto>()
      .ForMember(dest => dest.BuyerName,
                  opt => opt.MapFrom(src =>$"{src.Buyer.FirstName} {src.Buyer.LastName}"));

        this.CreateMap<Product, SoldProductDto>();

        // Category
        this.CreateMap<CategoryInportDto, Category>();

        this.CreateMap<CategoryProductInportDto, CategoryProduct>();
    }
}
