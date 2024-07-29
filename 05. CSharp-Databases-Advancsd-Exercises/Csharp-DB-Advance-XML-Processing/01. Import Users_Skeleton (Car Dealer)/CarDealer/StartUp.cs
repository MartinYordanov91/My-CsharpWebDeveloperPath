using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Castle.Core.Resource;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer;

public class StartUp
{
    public static void Main()
    {
        var dbContext = new CarDealerContext();
        File.WriteAllText("../../../Results/sales-discounts.xml", GetSalesWithAppliedDiscount(dbContext));


    }

    // Solve 9. Import Suppliers
    public static string ImportSuppliers(CarDealerContext context, string inputXml)
    {
        var dtos = DeserializateXml<SupplierInportDto[]>(inputXml, "Suppliers");

        var suppliers = dtos.Select(x => AutoMap().Map<Supplier>(x)).ToArray();

        context.Suppliers.AddRange(suppliers);
        context.SaveChanges();

        return $"Successfully imported {suppliers.Length}";
    }

    // Solve 10. Import Parts

    public static string ImportParts(CarDealerContext context, string inputXml)
    {
        var suppliersId = context.Suppliers.Select(x => x.Id).ToList();
        var Dtos = DeserializateXml<PartInportDto[]>(inputXml, "Parts");

        var parts = Dtos
            .Where(x => suppliersId.Contains(x.SupplierId))
            .Select(x => AutoMap().Map<Part>(x))
            .ToList();

        context.Parts.AddRange(parts);
        context.SaveChanges();

        return $"Successfully imported {parts.Count}";
    }

    // Solve 11. Import Cars

    public static string ImportCars(CarDealerContext context, string inputXml)
    {
        var partsId = context.Parts.Select(x => x.Id).ToList();
        var dtos = DeserializateXml<CarImportDto[]>(inputXml, "Cars").ToArray();

        var cars = dtos.Select(dto =>
        {
            var car = AutoMap().Map<Car>(dto);

            car.PartsCars = dto.Parts
                .DistinctBy(p => p.Id)
                .Where(p => partsId.Contains(p.Id))
                .Select(p => new PartCar { PartId = p.Id })
                .ToHashSet();

            return car;
        }).ToList();

        context.Cars.AddRange(cars);
        context.SaveChanges();

        return $"Successfully imported {cars.Count}";
    }

    // Solve 12. Import Customers
    public static string ImportCustomers(CarDealerContext context, string inputXml)
    {
        var dtos = DeserializateXml<CustomerImportDto[]>(inputXml, "Customers");

        var customers = dtos
            .Select(dto => AutoMap().Map<Customer>(dto))
            .ToList();

        context.Customers.AddRange(customers);
        context.SaveChanges();

        return $"Successfully imported {customers.Count}";
    }

    //Solve 13. Import Sales

    public static string ImportSales(CarDealerContext context, string inputXml)
    {
        var cars = context.Cars.Select(c => c.Id).ToArray();
        var dtos = DeserializateXml<SaleImportDto[]>(inputXml, "Sales");
        var sales = dtos
            .Where(s => cars.Contains(s.CarId))
            .Select(s => AutoMap().Map<Sale>(s))
            .ToList();

        context.Sales.AddRange(sales);
        context.SaveChanges();

        return $"Successfully imported {sales.Count}";
    }

    // solve 14. Export Cars With Distance
    public static string GetCarsWithDistance(CarDealerContext context)
    {
        var carsWitDistance = context.Cars
            .Where(c => c.TraveledDistance > 2_000_000)
            .OrderBy(c => c.Make)
            .ThenBy(c => c.Model)
            .Take(10)
            .ProjectTo<ExportCarWithDistanceDto>(AutoMap().ConfigurationProvider)
            .ToArray();

        return SerializateXml<ExportCarWithDistanceDto[]>(carsWitDistance, "cars");
    }

    // Solve 15. Export Cars From Make BMW
    public static string GetCarsFromMakeBmw(CarDealerContext context)
    {
        var bmvCars = context.Cars
            .Where(x => x.Make.ToUpper() == "BMW")
            .OrderBy(x => x.Model)
            .ThenByDescending(x => x.TraveledDistance)
            .ProjectTo<ExportBmvCarDto>(AutoMap().ConfigurationProvider)
            .ToArray();

        return SerializateXml<ExportBmvCarDto[]>(bmvCars, "cars");
    }

    //Solve 16. Export Local Suppliers
    public static string GetLocalSuppliers(CarDealerContext context)
    {
        var localSuppliers = context.Suppliers
            .Where(s => !s.IsImporter)
            .ProjectTo<ExportLocalSuppliersDto>(AutoMap().ConfigurationProvider)
            .ToArray();

        return SerializateXml<ExportLocalSuppliersDto[]>(localSuppliers, "suppliers");
    }

    // Solve 17. Export Cars With Their List Of Parts
    public static string GetCarsWithTheirListOfParts(CarDealerContext context)
    {
        var cartWithParts = context.Cars
            .Select(c => new ExportCarAndPartsDto()
            {
                Make = c.Make,
                Model = c.Model,
                TraveledDistance = c.TraveledDistance,
                Parts = c.PartsCars
                .Select(p => new ExportPartsNamePriceDto()
                {
                    Name = p.Part.Name,
                    Price = p.Part.Price,
                })
                .OrderByDescending(p => p.Price)
                .ToArray()
            })
            .OrderByDescending(c => c.TraveledDistance)
            .ThenBy(c => c.Model)
            .Take(5)
            .ToArray();

        return SerializateXml<ExportCarAndPartsDto[]>(cartWithParts, "cars");
    }

    // Solve 18. Export Total Sales by Customer
    public static string GetTotalSalesByCustomer(CarDealerContext context)
    {
        var customersWithBoughtCars = context.Customers
            .Where(c => c.Sales.Any())
            .Select(c => new
            {
                FullName = c.Name,
                BoughtCars = c.Sales.Count(),
                SalesInfo = c.Sales.Select(s => new
                {
                    Prices = c.IsYoungDriver
                            ? s.Car.PartsCars.Sum(p => Math.Round((double)p.Part.Price * 0.95, 2))
                            : s.Car.PartsCars.Sum(p => (double)p.Part.Price)


                }).ToArray(),

            })
            .ToArray()
            .OrderByDescending(x => x.SalesInfo.Sum(s => s.Prices))
            .Select(x => new customerWithBoughtCarDto
            {
                Name = x.FullName,
                BoughtCars = x.BoughtCars,
                SpendMoney = x.SalesInfo.Sum(p => p.Prices).ToString("f2")
            })
            .ToArray();

        return SerializateXml<customerWithBoughtCarDto[]>(customersWithBoughtCars, "customers");

    }

    // Solve 19. Export Sales with Applied Discount
    public static string GetSalesWithAppliedDiscount(CarDealerContext context)
    {
        var sales = context.Sales
        .Select(c => new
        {
            Car = c.Car,
            Discount = c.Discount,
            CustomerName = c.Customer.Name,
            Price = c.Car.PartsCars.Sum(p => p.Part.Price),
            PriceWithDiscount = c.Car.PartsCars.Sum(p => p.Part.Price) * (1 - (c.Discount / 100m))
        })
        .ToArray();

        var salesDtos = sales
            .Select(s => new SealInfoExportDto
            {
                Car = AutoMap().Map<SealCarExportDto>(s.Car),
                Discount = s.Discount,
                CustomerName = s.CustomerName,
                Price = s.Price,
                PriceWithDiscount = Math.Round((double)s.PriceWithDiscount,4)
            })
            .ToArray();

        return SerializateXml<SealInfoExportDto[]>(salesDtos, "sales");
    }



    // Help Func
    private static IMapper AutoMap()
    {
        return new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CarDealerProfile>();
        }));
    }

    private static T DeserializateXml<T>(string input, string root)
    {
        var serializater = new XmlSerializer(typeof(T), new XmlRootAttribute(root));

        using StringReader reeder = new StringReader(input);

        return (T)serializater.Deserialize(reeder)!;
    }

    private static string SerializateXml<T>(T obj, string root)
    {
        var sb = new StringBuilder();

        var serializate = new XmlSerializer(typeof(T), new XmlRootAttribute(root));
        var namespaceXml = new XmlSerializerNamespaces();
        namespaceXml.Add(string.Empty, string.Empty);

        using var writer = new StringWriter(sb);
        serializate.Serialize(writer, obj, namespaceXml);

        return sb.ToString().Trim();
    }
}