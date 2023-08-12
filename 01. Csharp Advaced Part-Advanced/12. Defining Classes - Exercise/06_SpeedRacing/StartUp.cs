namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int countOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfCars; i++)
            {
                string[] carArg = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = carArg[0];
                double FuelAmount = double.Parse(carArg[1]);
                double FuelConsumptionPerKilometer = double.Parse(carArg[2]);

                if (cars.Any(c => c.Model == model)) { continue; }

                Car car = new Car(model, FuelAmount, FuelConsumptionPerKilometer);
                cars.Add(car);
            }

            string comand = string.Empty;
            while ((comand = Console.ReadLine()) != "End")
            {
                string[] comandArg = comand
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = comandArg[1];
                int amountOfKm = int.Parse(comandArg[2]);
                cars.First(m => m.Model == model).Drive(amountOfKm);

            }

            Console.WriteLine( string.Join(Environment.NewLine , cars));
        }
    }
}