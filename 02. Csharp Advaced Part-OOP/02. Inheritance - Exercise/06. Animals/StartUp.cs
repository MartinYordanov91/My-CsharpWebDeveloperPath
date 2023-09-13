namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string animalType = string.Empty;
            while ((animalType = Console.ReadLine()) != "Beast!")
            {
                string[] components = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    switch (animalType)
                    {
                        case "Dog":
                            Dog dog = new(components[0], int.Parse(components[1]), components[2]);
                            PrintAnimal(animalType, dog);
                            break;
                        case "Cat":
                            Cat cat = new(components[0], int.Parse(components[1]), components[2]);
                            PrintAnimal(animalType, cat);
                            break;
                        case "Frog":
                            Frog frog = new(components[0], int.Parse(components[1]), components[2]);
                            PrintAnimal(animalType, frog);
                            break;
                        case "Kittens":
                            Kitten kittens = new(components[0], int.Parse(components[1]));
                            PrintAnimal(animalType, kittens);
                            break;
                        case "Tomcat":
                            Tomcat tomcat = new(components[0], int.Parse(components[1]));
                            PrintAnimal(animalType, tomcat);
                            break;

                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public static void PrintAnimal<T>(string animalType, T animal)
        {
            Console.WriteLine(animalType);
            Console.WriteLine(animal.ToString());
        }
    }
}