namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();
            int countOfEngine = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfEngine; i++)
            {
                string[] engineArg = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = engineArg[0];
                int power = int.Parse(engineArg[1]);

                if (engineArg.Length == 2)
                {
                    Engine engine = new Engine(model, power);
                    engines.Add(engine);
                }
                else if (engineArg.Length == 3)
                {
                    if (int.TryParse(engineArg[2], out int displacement))
                    {
                        Engine engine = new Engine(model, power, displacement);
                        engines.Add(engine);
                    }
                    else
                    {
                        string Efficiency = engineArg[2];
                        Engine engine = new Engine(model, power, Efficiency);
                        engines.Add(engine);
                    }

                }
                else if (engineArg.Length == 4)
                {
                    int displacement = int.Parse(engineArg[2]);
                    string Efficiency = engineArg[3];
                    Engine engine = new Engine(model, power, displacement, Efficiency);
                    engines.Add(engine);
                }
            }

            int countOfCar = int.Parse(Console.ReadLine());

            for (int n = 0; n < countOfCar; n++)
            {
                string[] carArg = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = carArg[0];
                // if (engines.Any(x => x.Model == carArg[1]) == false) { continue; }
                Engine engine = engines.First(x => x.Model == carArg[1]);
                if (carArg.Length == 2)
                {
                    Car car = new Car(model, engine);
                    cars.Add(car);
                }
                else if (carArg.Length == 3)
                {
                    if (int.TryParse(carArg[2], out int weight))
                    {
                        Car car = new Car(model, engine, weight);
                        cars.Add(car);
                    }
                    else
                    {
                        string color = carArg[2];
                        Car car = new Car(model, engine, color);
                        cars.Add(car);
                    }
                }
                else if (carArg.Length == 4)
                {
                    int weight = int.Parse(carArg[2]);
                    string color = carArg[3];
                    Car car = new Car(model, engine, weight, color);
                    cars.Add(car);
                }

            }

            Console.WriteLine(string.Join(Environment.NewLine , cars));
        }
    }
}