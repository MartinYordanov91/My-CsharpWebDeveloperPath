using Cadastre.Data;
using Cadastre.Data.Enumerations;
using Cadastre.DataProcessor.ExportDtos;
using Newtonsoft.Json;
using System.Text;
using System.Xml.Serialization;

namespace Cadastre.DataProcessor;

public class Serializer
{
    public static string ExportPropertiesWithOwners(CadastreContext dbContext)
    {
        DateTime date = new DateTime(2000, 1, 1);

        var proparties = dbContext.Properties
            .Where(x => x.DateOfAcquisition >= date)
             .OrderByDescending(x => x.DateOfAcquisition)
            .ThenBy(x => x.PropertyIdentifier)
            .Select(x => new
            {
                PropertyIdentifier = x.PropertyIdentifier,
                Area = x.Area,
                Address = x.Address,
                DateOfAcquisition = x.DateOfAcquisition.ToString("dd/MM/yyyy"),
                Owners = x.PropertiesCitizens.Select(v => new
                {
                    LastName = v.Citizen.LastName,
                    MaritalStatus = v.Citizen.MaritalStatus.ToString(),
                })
                .OrderBy(x => x.LastName)
                .ToArray()
            })
            .ToArray();

        return JsonConvert.SerializeObject(proparties, Formatting.Indented);
    }

    public static string ExportFilteredPropertiesWithDistrict(CadastreContext dbContext)
    {
        var proparties = dbContext.Properties
            .Where(x => x.Area >= 100)
            .OrderByDescending(x => x.Area)
            .ThenBy(x => x.DateOfAcquisition)
            .Select(x => new ExportPropartiesWeatPostcodeDto()
            {
                PostalCode = x.District.PostalCode,
                PropertyIdentifier = x.PropertyIdentifier,
                Area = x.Area,
                DateOfAcquisition = x.DateOfAcquisition.ToString("dd/MM/yyyy")
            })
            .ToArray();

        return SerializateXml<ExportPropartiesWeatPostcodeDto[]>(proparties, "Properties");
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


