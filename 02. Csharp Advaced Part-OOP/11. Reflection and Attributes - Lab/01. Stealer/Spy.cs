using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className,params string[] fildsNames)
        {
            Type type = Type.GetType(className);// взимам си името или самият клас
            FieldInfo[] classFieldsInfo = type.GetFields((BindingFlags)60);// взимам абсолютно всики филдове без значение какви са 
            StringBuilder sb = new();
            object classInstance = Activator.CreateInstance(type, new object[] { }); // правя инстанция на класа

            sb.AppendLine($"Class under investigation: {className}");

            foreach (FieldInfo field in classFieldsInfo.Where(x=>fildsNames.Contains(x.Name))) // взимам само филдовете които искам 
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().Trim();
        }
    }
}
