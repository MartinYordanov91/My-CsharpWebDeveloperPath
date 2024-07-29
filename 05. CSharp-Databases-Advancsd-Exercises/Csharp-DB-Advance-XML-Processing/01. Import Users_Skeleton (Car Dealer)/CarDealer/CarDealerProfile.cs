using AutoMapper;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            //suppliers 

            this.CreateMap<SupplierInportDto, Supplier>();

            this.CreateMap<Supplier, ExportLocalSuppliersDto>()
                .ForMember(des => des.PartsCount, opt => opt.MapFrom(s => s.Parts.Count));

            // parts
            this.CreateMap<PartInportDto, Part>();

            // cars
            this.CreateMap<CarImportDto, Car>()
           .ForSourceMember(s => s.Parts, opt => opt.DoNotValidate());

            this.CreateMap<Car, ExportCarWithDistanceDto>();
            this.CreateMap<Car, ExportBmvCarDto>();
            this.CreateMap<Car, SealCarExportDto>();

            // customers

            this.CreateMap<CustomerImportDto, Customer>()
                .ForMember(des => des.BirthDate, opt => opt.MapFrom(sor => DateTime.Parse(sor.BirthDate)));

            // sales

            this.CreateMap<SaleImportDto, Sale>();
        }
    }
}
