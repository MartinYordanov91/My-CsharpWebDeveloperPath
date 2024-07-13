using AutoMapper;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            // User
            this.CreateMap<importUserDto, User>();

            this.CreateMap<User, ExportUserProductInfoDto>()
                .ForMember(des => des.SoldProducts, opt => opt.MapFrom(scr => new ExportSoldProductsListDto
                {
                    Count = scr.ProductsSold.Count(x => x.BuyerId != null),
                    Products = scr.ProductsSold
                                .Where(x => x.BuyerId != null)
                                .Select(x => new ExportProductNamePriceDto
                                {
                                    ProductName = x.Name,
                                    Price = x.Price,

                                }).ToList()
                }));

            this.CreateMap<User, ExportUserDto>()
                 .ForMember(dest => dest.SoldProducts,
                  opt => opt.MapFrom(src => src.ProductsSold.Where(p => p.BuyerId != null).ToArray()));


            //Product
            this.CreateMap<importProductDto, Product>();

            this.CreateMap<Product, ExportProductNamePriceDto>()
                .ForMember(des => des.ProductName, opt => opt.MapFrom(s => s.Name));

            this.CreateMap<Product, ExportProductDto>()
                .ForMember(des => des.ProductName, opt => opt.MapFrom(s => s.Name))
                .ForMember(des => des.BuyerFirstName, opt => opt.MapFrom(s => s.Buyer.FirstName))
                .ForMember(des => des.BuyerLastName, opt => opt.MapFrom(s => s.Buyer.LastName));

            this.CreateMap<Product, ExportProductInRange>()
                .ForMember(des => des.ProductName, opt => opt.MapFrom(s => s.Name))
                .ForMember(des => des.Price, opt => opt.MapFrom(s => s.Price))
                .ForMember(des => des.SellerName, opt => opt.MapFrom(s => $"{s.Seller.FirstName} {s.Seller.LastName}"));

            //Category
            this.CreateMap<importCategoryDto, Category>();

            this.CreateMap<Category, ExportCategoryProductsInfoDto>()
                .ForMember(des => des.CategoryName, opt => opt.MapFrom(s => s.Name))
                .ForMember(des => des.ProductsCount, opt => opt.MapFrom(s => s.CategoriesProducts
                                                                              .Count()))
                .ForMember(des => des.AveragePrice, opt => opt.MapFrom(s => s.CategoriesProducts
                                                                            .Select(x => x.Product.Price)
                                                                            .Average()
                                                                            .ToString("f2")))
                 .ForMember(des => des.TotalRevenue, opt => opt.MapFrom(s => s.CategoriesProducts
                                                                            .Select(x => x.Product.Price)
                                                                            .Sum()));


            //CategoryProduct
            this.CreateMap<importCategoryProductDto, CategoryProduct>();
        }
    }
}
