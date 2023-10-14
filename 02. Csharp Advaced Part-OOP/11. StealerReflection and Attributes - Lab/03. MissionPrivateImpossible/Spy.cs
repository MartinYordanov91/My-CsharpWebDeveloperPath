using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fildsNames)
        {
            Type type = Type.GetType(className);// взимам си името или самият клас
            FieldInfo[] classFieldsInfo = type.GetFields((BindingFlags)60);// взимам абсолютно всики филдове без значение какви са 
            StringBuilder sb = new();
            object classInstance = Activator.CreateInstance(type, new object[] { }); // правя инстанция на класа

            sb.AppendLine($"Class under investigation: {className}");

            foreach (FieldInfo field in classFieldsInfo.Where(x => fildsNames.Contains(x.Name))) // взимам само филдовете които искам 
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().Trim();
        }
        public string AnalyzeAccessModifiers(string className)
        {
            StringBuilder sb = new();

            Type type = Type.GetType("Stealer." + className);

            FieldInfo[] fieldNotPrivate = type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);

            foreach (FieldInfo field in fieldNotPrivate)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }

            MethodInfo[] methodsNotPublic = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (MethodInfo methodInfo in methodsNotPublic.Where(x => x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{methodInfo.Name} have to be public!");
            }

            MethodInfo[] methodNotPrivate = type.GetMethods(BindingFlags.Instance|BindingFlags.Public);

            foreach (MethodInfo methodInfo in methodNotPrivate.Where(x=>x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{methodInfo.Name} have to be private!");
            }

            return sb.ToString().Trim();
        }
        public string RevealPrivateMethods(string className)
        {
            StringBuilder sb = new();
            Type type = Type.GetType(className);
            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {type.BaseType.Name}");

            MethodInfo[] methodInfosPivate = type.GetMethods(BindingFlags.Instance | BindingFlags.Static| BindingFlags.NonPublic);

            foreach (MethodInfo item in methodInfosPivate)
            {
                sb.AppendLine(item.Name);
            }

            return sb.ToString().Trim();
        }
    }
}
