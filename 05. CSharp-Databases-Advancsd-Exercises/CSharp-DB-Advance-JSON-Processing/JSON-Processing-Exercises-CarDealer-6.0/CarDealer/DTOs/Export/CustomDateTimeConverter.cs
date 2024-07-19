using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

public class CustomDateTimeConverter : IsoDateTimeConverter
{
    public CustomDateTimeConverter()
    {
        base.DateTimeFormat = "dd/MM/yyyy";
    }
}
