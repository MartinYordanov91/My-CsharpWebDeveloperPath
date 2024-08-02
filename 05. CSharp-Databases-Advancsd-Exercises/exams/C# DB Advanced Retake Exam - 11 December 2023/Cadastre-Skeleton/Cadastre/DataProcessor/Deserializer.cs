namespace Cadastre.DataProcessor
{
    using Cadastre.Data;
    using Cadastre.Data.Enumerations;
    using Cadastre.Data.Models;
    using Cadastre.DataProcessor.ImportDtos;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid Data!";
        private const string SuccessfullyImportedDistrict =
            "Successfully imported district - {0} with {1} properties.";
        private const string SuccessfullyImportedCitizen =
            "Succefully imported citizen - {0} {1} with {2} properties.";

        public static string ImportDistricts(CadastreContext dbContext, string xmlDocument)
        {
            var sb = new StringBuilder();
            var dtos = DeserializateXml<importDistrictDto[]>(xmlDocument, "Districts");

            foreach (var dto in dtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (dbContext.Districts.Any(x => x.Name == dto.Name))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var isvalidEnum = Enum.TryParse<Region>(dto.Region, out var RegionStatus);



                if (!isvalidEnum)
                {
                    continue;
                }
                var district = new District()
                {
                    Name = dto.Name,
                    PostalCode = dto.PostalCode,
                    Region = RegionStatus,
                };

              

                foreach (var prop in dto.Properties)
                {
                    if (!IsValid(prop))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (dbContext.Properties.Any(x => x.PropertyIdentifier == prop.PropertyIdentifier) ||
                        district.Properties.Any(x => x.PropertyIdentifier == prop.PropertyIdentifier) ||
                        dbContext.Properties.Any(x => x.Address == prop.Address) ||
                        district.Properties.Any(x => x.Address == prop.Address))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var isDate = DateTime.ParseExact(prop.DateOfAcquisition, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    var property = new Property()
                    {
                        PropertyIdentifier = prop.PropertyIdentifier,
                        Area = prop.Area,
                        Details = prop.Details,
                        Address = prop.Address,
                        DateOfAcquisition = isDate
                    };

                    district.Properties.Add(property);
                }

                    dbContext.Districts.Add(district);
                    sb.AppendLine(string.Format(SuccessfullyImportedDistrict, district.Name, district.Properties.Count()));
                
            }

            dbContext.SaveChanges();
            return sb.ToString().Trim();
        }


        public static string ImportCitizens(CadastreContext dbContext, string jsonDocument)
        {
            var sb = new StringBuilder();
            var dtos = JsonConvert.DeserializeObject<ImportCitizenDto[]>(jsonDocument);

            foreach (var dto in dtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var properties = new HashSet<PropertyCitizen>();

                foreach (var propartyId in dto.Properties.Distinct())
                {
                    if (!dbContext.Properties.Any(x => x.Id == propartyId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var property = new PropertyCitizen()
                    {
                        PropertyId = propartyId,
                    };

                    properties.Add(property);
                }

                var date = DateTime.ParseExact(dto.BirthDate,
                                "dd-MM-yyyy",
                                 CultureInfo.InvariantCulture);



                var isvalidEnum = Enum.TryParse<MaritalStatus>(dto.MaritalStatus, out var maritalStatus);


                if (!isvalidEnum)
                {
                    continue;
                }
                var citizen = new Citizen()
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    BirthDate = date,
                    MaritalStatus = maritalStatus,
                    PropertiesCitizens = properties
                };

                dbContext.Citizens.Add(citizen);
                sb.AppendLine(string.Format(SuccessfullyImportedCitizen, citizen.FirstName, citizen.LastName, citizen.PropertiesCitizens.Count()));
            }

            dbContext.SaveChanges();

            return sb.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }


        private static T DeserializateXml<T>(string input, string root)
        {
            var serializater = new XmlSerializer(typeof(T), new XmlRootAttribute(root));

            using StringReader reeder = new StringReader(input);

            return (T)serializater.Deserialize(reeder)!;
        }
    }
}
