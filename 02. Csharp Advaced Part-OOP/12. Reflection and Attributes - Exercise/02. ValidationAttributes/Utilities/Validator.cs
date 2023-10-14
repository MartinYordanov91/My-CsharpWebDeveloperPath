namespace ValidationAttributes.Utilities
{
    using System;
    using System.Linq;
    using System.Reflection;
    using ValidationAttributes.Utilities.Attributs;

    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type objType = obj.GetType();
            PropertyInfo[] props = objType
                .GetProperties()
                .Where(p => p.CustomAttributes
                .Any(ca => typeof(MyValidationAttribute).IsAssignableFrom(ca.AttributeType)))
                .ToArray();

            foreach (PropertyInfo validationpropm in props)
            {
                object[] custemAttributes = validationpropm
                    .GetCustomAttributes()
                    .Where(ca => typeof(MyValidationAttribute).IsAssignableFrom(ca.GetType()))
                    .ToArray();

                object propValue = validationpropm.GetValue(obj);

                foreach (object custemAttribute in custemAttributes)
                {
                    MethodInfo isValidMethod = custemAttribute.GetType()
                        .GetMethods(BindingFlags.Instance | BindingFlags.Public)
                        .FirstOrDefault(mi => mi.Name == "IsValid");

                    if (isValidMethod == null)
                    {
                        throw new InvalidOperationException("Your custom attribute does have \"IsValid\" method");
                    }

                    bool result = (bool)isValidMethod
                        .Invoke(custemAttribute, new object[] { propValue });

                    if (!result)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
