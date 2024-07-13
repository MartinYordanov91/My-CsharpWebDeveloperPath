using AutoMapper;
using AutoMapper.QueryableExtensions;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop;

public class StartUp
{
    public static void Main()
    {
        var dbContext = new ProductShopContext();

        //Solve 08
        //var path = "../../../Results/users-and-products.json";
        //var json = GetUsersWithProducts(dbContext);
        //File.WriteAllText(path, json);


        //Solve 07
        //var path = "../../../Results/categories-by-products.json";
        //var json = GetCategoriesByProductsCount(dbContext);
        //File.WriteAllText(path, json);

        //Solve 06
        //var path = "../../../Results/users-sold-products.json";
        //var json = GetSoldProducts(dbContext);
        //File.WriteAllText(path, json);

        //Solve 05
        //var path = "../../../Results/products-in-range.json";
        //var json = GetProductsInRange(dbContext);
        //File.WriteAllText(path, json);

        //Solve 04
        //var Json = File.ReadAllText("../../../Datasets/categories-products.json");
        //Console.WriteLine(ImportCategoryProducts(dbContext, Json));


        //Solve 03
        //var categoryJson = File.ReadAllText("../../../Datasets/categories.json");
        //Console.WriteLine(ImportCategories(dbContext, categoryJson));


        //Solve 02
        //var productsJson = File.ReadAllText("../../../Datasets/products.json");
        //Console.WriteLine(ImportProducts(dbContext, productsJson));


        //Solve 01
        //string userJson = File.ReadAllText("../../../Datasets/users.json");
        //Console.WriteLine(ImportUsers(dbContext , userJson));

    }

    // Solve 01 Import Users
    public static string ImportUsers(ProductShopContext context, string inputJson)
    {
        IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ProductShopProfile>();
        }));

        var userDtos = JsonConvert.DeserializeObject<importUserDto[]>(inputJson);

        ICollection<User> users = new HashSet<User>();

        foreach (var userDto in userDtos!)
        {
            var user = mapper.Map<User>(userDto);
            users.Add(user);
        }

        context.Users.AddRange(users);
        context.SaveChanges();

        return $"Successfully imported {users.Count}";
    }


    // Solve 2 Import Products
    public static string ImportProducts(ProductShopContext context, string inputJson)
    {
        IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ProductShopProfile>();
        }));

        importProductDto[] pDtos =
            JsonConvert.DeserializeObject<importProductDto[]>(inputJson);

        ICollection<Product> Validproducts = new HashSet<Product>();

        foreach (importProductDto pDto in pDtos)
        {
            // JUDGE NOT LIKE

            //if(context.Users.Any(u => u.Id == pDto.SellerId))
            //{
            //    continue;
            //}

            Product product = mapper.Map<Product>(pDto);
            Validproducts.Add(product);
        }

        context.Products.AddRange(Validproducts);
        context.SaveChanges();

        return $"Successfully imported {Validproducts.Count}";
    }

    // Solve 03 Import Categories
    public static string ImportCategories(ProductShopContext context, string inputJson)
    {
        IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ProductShopProfile>();
        }));

        importCategoryDto[] catDtos =
            JsonConvert.DeserializeObject<importCategoryDto[]>(inputJson);

        ICollection<Category> validCategory = new HashSet<Category>();

        foreach (importCategoryDto catDto in catDtos)
        {
            if (string.IsNullOrEmpty(catDto.Name))
            {
                continue;
            }

            Category category = mapper.Map<Category>(catDto);
            validCategory.Add(category);
        }

        context.Categories.AddRange(validCategory);
        context.SaveChanges();

        return $"Successfully imported {validCategory.Count}";
    }

    // Solve 04 Import Categories and Products
    public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
    {
        IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<ProductShopProfile>();
        }));

        importCategoryProductDto[] cpDtos =
            JsonConvert.DeserializeObject<importCategoryProductDto[]>(inputJson);

        HashSet<CategoryProduct> categoryProducts = cpDtos
            .Select(dto => mapper.Map<CategoryProduct>(dto))
            .ToHashSet();

        context.CategoriesProducts.AddRange(categoryProducts);
        context.SaveChanges();

        return $"Successfully imported {categoryProducts.Count}";
    }

    // Solve 05 Export Products in Range
    public static string GetProductsInRange(ProductShopContext context)
    {
        IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new ProductShopProfile());
        }));

        var productInRange = context.Products
            .Where(p => p.Price >= 500
                     && p.Price <= 1000)
            .OrderBy(p => p.Price)
            .ProjectTo<ExportProductInRange>(mapper.ConfigurationProvider)
            .ToList();

        return JsonConvert.SerializeObject(productInRange, Formatting.Indented);
    }

    // Solve 06 Export Sold Products
    public static string GetSoldProducts(ProductShopContext context)
    {
        IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new ProductShopProfile());
        }));

        var usersSoldProducts = context.Users
            .Where(x => x.ProductsSold.Any(c => c.BuyerId != null))
            .OrderBy(x => x.LastName)
            .ThenBy(x => x.FirstName)
            .ProjectTo<ExportUserDto>(mapper.ConfigurationProvider)
            .ToList();

        return JsonConvert.SerializeObject(usersSoldProducts, Formatting.Indented);
    }

    // Solve 07 Export Categories by Products Count
    public static string GetCategoriesByProductsCount(ProductShopContext context)
    {
        IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new ProductShopProfile());
        }));

        var categoriesProductsInfo = context.Categories
            .OrderByDescending(c => c.CategoriesProducts.Count())
            .ProjectTo<ExportCategoryProductsInfoDto>(mapper.ConfigurationProvider)
            .ToList();

        return JsonConvert.SerializeObject(categoriesProductsInfo, Formatting.Indented);
    }

    // Solve 08 Export Users and Products
    public static string GetUsersWithProducts(ProductShopContext context)
    {
        IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new ProductShopProfile());
        }));

        var userProducts = context.Users.
            Where(x => x.ProductsSold.Any(x => x.BuyerId != null))
            .OrderByDescending(x => x.ProductsSold.Count(x => x.BuyerId!=null))
            .ProjectTo< ExportUserProductInfoDto>(mapper.ConfigurationProvider)
            .ToList();

        var resultJson = new ExportUserListDto
        {
            UsersCount = userProducts.Count,
            Users = userProducts
        };


        return JsonConvert.SerializeObject(resultJson, Formatting.Indented);
    }
}