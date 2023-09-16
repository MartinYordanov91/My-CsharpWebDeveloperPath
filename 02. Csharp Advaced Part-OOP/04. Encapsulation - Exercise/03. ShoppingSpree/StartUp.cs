using ShoppingSpree.Models;

namespace ShoppingSpree
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Person> persons = new();
            List<Product> products = new();

            try
            {

                string[] personsInfo = Console.ReadLine()
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);

                foreach (string personInfo in personsInfo)
                {
                    string[] info = personInfo.Split("=", StringSplitOptions.RemoveEmptyEntries);

                    Person person = new(info[0], int.Parse(info[1]));
                    persons.Add(person);
                }

                string[] productsInfo = Console.ReadLine()
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);

                foreach (string productInfo in productsInfo)
                {
                    string[] info = productInfo.Split("=", StringSplitOptions.RemoveEmptyEntries);

                    Product product = new(info[0], int.Parse(info[1]));
                    products.Add(product);
                }

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            string customersProduct = string.Empty;
            while ((customersProduct = Console.ReadLine()) != "END")
            {
                string[] customersProductArg = customersProduct
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Person person = persons.FirstOrDefault(x => x.Name == customersProductArg[0]);
                Product product = products.FirstOrDefault(x => x.Name == customersProductArg[1]);
                person.AddInBag(product);

            }
            if (persons.Any())
                Console.WriteLine(string.Join(Environment.NewLine, persons));
        }
    }
}