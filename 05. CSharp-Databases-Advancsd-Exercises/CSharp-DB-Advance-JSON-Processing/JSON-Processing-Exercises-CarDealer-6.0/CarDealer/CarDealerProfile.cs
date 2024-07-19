using AutoMapper;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;

namespace CarDealer;

public class CarDealerProfile : Profile
{
    public CarDealerProfile()
    {
        // Supplier
        this.CreateMap<ImportSuppliersDto, Supplier>();

        this.CreateMap<Supplier, ExportLocalSuppliersNotImportenDto>()
            .ForMember(des => des.PartsCount, opt => opt.MapFrom(s => s.Parts.Count()));

        // Parts
        this.CreateMap<ImportPartsDto, Part>();

        this.CreateMap<Part, ExportPartNamePriceDto>()
            .ForMember(des => des.Price, opt => opt.MapFrom(s => s.Price.ToString("f2")));

        // Car
        this.CreateMap<importCarDto, Car>()
            .ForMember(des => des.PartsCars , opt => opt.Ignore());

        this.CreateMap<Car, ExportCarMakeToyotaDto>();

        this.CreateMap<Car, ExportCarObjPropDto>();

        

        // Customer
        this.CreateMap<ImportCustomerDto, Customer>();
        this.CreateMap<Customer, ExportOrderedCustomerDto>();

        // Sale
        this.CreateMap<ImportSaleDto, Sale>();
    }
}
