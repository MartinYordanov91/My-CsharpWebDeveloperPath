using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Newtonsoft.Json;
using System.Diagnostics;
using System.IO;

namespace CarDealer;

public class StartUp
{
    public static void Main()
    {
        var db = new CarDealerContext();

        //// Solve 09
        //var jsonPhat09 = File.ReadAllText("../../../Datasets/suppliers.json");
        //Console.WriteLine(ImportSuppliers(db, jsonPhat09));


        //// Solve 10
        //var jsonPhat10 = File.ReadAllText("../../../Datasets/parts.json");
        //Console.WriteLine(ImportParts(db, jsonPhat10));


        //// Solve 11
        //var jsonPhat11 = File.ReadAllText("../../../Datasets/cars.json");
        //Console.WriteLine(ImportCars(db, jsonPhat11));


        //// Solve 12
        //var jsonPhat12 = File.ReadAllText("../../../Datasets/customers.json");
        //Console.WriteLine(ImportCustomers(db, jsonPhat12));

        // Solve 13
        //var jsonPhat13 = File.ReadAllText("../../../Datasets/sales.json");
        //Console.WriteLine(ImportSales(db, jsonPhat13));

        // Solve 14
        //File.WriteAllText("../../../Results/ordered-customers.json", GetOrderedCustomers(db));

        //// Solve 15
        //File.WriteAllText("../../../Results/toyota-cars.json", GetCarsFromMakeToyota(db));

        //// Solve 16
        //File.WriteAllText("../../../Results/local-suppliers.json", GetLocalSuppliers(db));

        //// Solve 17
        //File.WriteAllText("../../../Results/cars-and-parts.json", GetCarsWithTheirListOfParts(db));


        //// Solve 18
        //File.WriteAllText("../../../Results/customers-total-sales.json", GetTotalSalesByCustomer(db));


        // Solve 19
        File.WriteAllText("../../../Results/sales-discounts.json", GetSalesWithAppliedDiscount(db));
    }

    // Solve 09 Import Suppliers
    public static string ImportSuppliers(CarDealerContext context, string inputJson)
    {
        IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CarDealerProfile>();
        }));

        var dtos = JsonConvert.DeserializeObject<ImportSuppliersDto[]>(inputJson);

        ICollection<Supplier> suppliers = new HashSet<Supplier>();

        foreach (var dto in dtos)
        {
            var supplier = mapper.Map<Supplier>(dto);
            suppliers.Add(supplier);
        }

        context.Suppliers.AddRange(suppliers);
        context.SaveChanges();

        return $"Successfully imported {suppliers.Count}.";
    }

    // Solve 10 Import Parts
    public static string ImportParts(CarDealerContext context, string inputJson)
    {
        IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CarDealerProfile>();
        }));

        var dtos = JsonConvert.DeserializeObject<ImportPartsDto[]>(inputJson);

        ICollection<Part> validParts = new HashSet<Part>();

        foreach (var dto in dtos)
        {
            if (!context.Suppliers.Any(x => x.Id == dto.SupplierId))
            {
                continue;
            }

            var part = mapper.Map<Part>(dto);
            validParts.Add(part);
        }
        context.Parts.AddRange(validParts);
        context.SaveChanges();

        return $"Successfully imported {validParts.Count}.";
    }

    // Solve 11 Import Cars
    public static string ImportCars(CarDealerContext context, string inputJson)
    {
        IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CarDealerProfile>();
        }));

        var dtos = JsonConvert.DeserializeObject<importCarDto[]>(inputJson);

        ICollection<Car> cars = new HashSet<Car>();

        foreach (var dto in dtos)
        {
            var car = mapper.Map<Car>(dto);

            foreach (var partId in dto.PartsId.Distinct())
            {
                var part = context.Parts.Find(partId);

                if (part != null)
                {
                    var partCar = new PartCar
                    {
                        PartId = partId,
                        Part = part,
                        Car = car
                    };

                    car.PartsCars.Add(partCar);
                }
            }

            cars.Add(car);
        }

        context.Cars.AddRange(cars);
        context.SaveChanges();

        return $"Successfully imported {cars.Count}.";
    }

    // Solve 12 Import Customers
    public static string ImportCustomers(CarDealerContext context, string inputJson)
    {
        IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CarDealerProfile>();
        }));

        var dtos = JsonConvert.DeserializeObject<ImportCustomerDto[]>(inputJson);
        ICollection<Customer> customers = new HashSet<Customer>();

        foreach (var dto in dtos)
        {
            var customer = mapper.Map<Customer>(dto);
            customers.Add(customer);
        }

        context.Customers.AddRange(customers);
        context.SaveChanges();

        return $"Successfully imported {customers.Count}.";
    }

    // Solve 13 Import Sales
    public static string ImportSales(CarDealerContext context, string inputJson)
    {
        IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CarDealerProfile>();
        }));

        var dtos = JsonConvert.DeserializeObject<ImportSaleDto[]>(inputJson);
        ICollection<Sale> sales = new HashSet<Sale>();

        foreach (var dto in dtos)
        {
            var sale = mapper.Map<Sale>(dto);
            sales.Add(sale);
        }

        context.Sales.AddRange(sales);
        context.SaveChanges();

        return $"Successfully imported {sales.Count}.";
    }

    // Solve 14 Export Ordered Customers
    public static string GetOrderedCustomers(CarDealerContext context)
    {
        IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CarDealerProfile>();
        }));

        var customers = context.Customers
            .OrderBy(c => c.BirthDate)
            .ThenBy(c => c.IsYoungDriver)
            .ProjectTo<ExportOrderedCustomerDto>(mapper.ConfigurationProvider)
            .ToArray();

        return JsonConvert.SerializeObject(customers, Formatting.Indented);
    }

    // Solve 15  Export Cars from Make Toyota
    public static string GetCarsFromMakeToyota(CarDealerContext context)
    {
        IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CarDealerProfile>();
        }));

        var toyotaCars = context.Cars
            .Where(x => x.Make == "Toyota")
            .OrderBy(x => x.Model)
            .ThenByDescending(x => x.TraveledDistance)
            .ProjectTo<ExportCarMakeToyotaDto>(mapper.ConfigurationProvider)
            .ToList();

        return JsonConvert.SerializeObject(toyotaCars, Formatting.Indented);
    }

    // Solve 16 Export Local Suppliers
    public static string GetLocalSuppliers(CarDealerContext context)
    {
        IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CarDealerProfile>();
        }));

        var localSuppliers = context.Suppliers
            .Where(x => x.IsImporter == false)
            .ProjectTo<ExportLocalSuppliersNotImportenDto>(mapper.ConfigurationProvider)
            .ToList();

        return JsonConvert.SerializeObject(localSuppliers, Formatting.Indented);
    }

    // Solve 17 Export Cars with Their List of Parts
    public static string GetCarsWithTheirListOfParts(CarDealerContext context)
    {
        IMapper mapper = new Mapper(new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CarDealerProfile>();
        }));

        var allCars = context.Cars.ToList();
        //var jsonResultFromDto = new HashSet<ExportCarObjDto>();


        //foreach (var car in allCars)
        //{
        //    var carDto = new ExportCarObjDto
        //    {
        //        Car = mapper.Map<ExportCarObjPropDto>(car),
        //        Parts = car.PartsCars.Select(x => mapper.Map<ExportPartNamePriceDto>(x.Part)).Distinct().ToList(),
        //    };

        //    jsonResultFromDto.Add(carDto);
        //}

        var carss = context.Cars
            .Select(x => new
            {
                car = new
                {
                    Make = x.Make,
                    Model = x.Model,
                    TraveledDistance = x.TraveledDistance
                },
                parts = x.PartsCars.Select(i => new
                {
                    Name = i.Part.Name,
                    Price = i.Part.Price.ToString("f2"),
                })
            })
            .ToList();

        return JsonConvert.SerializeObject(carss, Formatting.Indented);
    }

    // Solve 18 Export Total Sales by Customer
    public static string GetTotalSalesByCustomer(CarDealerContext context)
    {
        var customerSales = context.Customers
               .Where(c => c.Sales.Any())
               .Select(c => new
               {
                   fullName = c.Name,
                   boughtCars = c.Sales.Count(),
                   salePrices = c.Sales.SelectMany(x => x.Car.PartsCars.Select(x => x.Part.Price))
               })
               .ToArray();

        var totalSalesByCustomer = customerSales.Select(t => new
        {
            t.fullName,
            t.boughtCars,
            spentMoney = t.salePrices.Sum()
        })
        .OrderByDescending(t => t.spentMoney)
        .ThenByDescending(t => t.boughtCars)
        .ToArray();

        return JsonConvert.SerializeObject(totalSalesByCustomer, Formatting.Indented);
    }

    // Solve 19 Export Sales with Applied Discount
    public static string GetSalesWithAppliedDiscount(CarDealerContext context)
    {
        var firstTenSeals = context.Sales
            .Take(10)
            .Select(x => new
            {
                car = new {
                    Make = x.Car.Make,
                    Model = x.Car.Model,
                    TraveledDistance = x.Car.TraveledDistance,
                },
                customerName = x.Customer.Name,
                discount = x.Discount.ToString("f2"),
                price = x.Car.PartsCars.Sum(c => c.Part.Price).ToString("f2"),
                priceWithDiscount = (x.Car.PartsCars.Sum(c => c.Part.Price) * (1 - (x.Discount / 100))).ToString("f2")
            })
            .ToList();

        return JsonConvert.SerializeObject(firstTenSeals , Formatting.Indented);
    }
}