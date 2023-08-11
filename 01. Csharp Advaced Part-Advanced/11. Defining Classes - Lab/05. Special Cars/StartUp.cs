namespace CarManufacturer;
public class StartUp
{
    static void Main()
    {
        List<List<Tire>> tiresSets = new List<List<Tire>>();
        List<Engine> engineSets = new List<Engine>();
        List<Car> carColections = new List<Car>();

        string argoment = string.Empty;
        while ((argoment = Console.ReadLine()) != "No more tires")
        {
            string[] curentArg = argoment.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            List<Tire> curentSet = new List<Tire>();
            for (int i = 0; i < curentArg.Length; i += 2)
            {
                int year = int.Parse(curentArg[i]);
                double pressure = double.Parse(curentArg[i + 1]);
                curentSet.Add(new Tire(year, pressure));
            }
            tiresSets.Add(curentSet);
        }

        argoment = string.Empty;
        while ((argoment = Console.ReadLine()) != "Engines done")
        {
            string[] curentArg = argoment.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int horsePower = int.Parse(curentArg[0]);
            double cubicCapacity = double.Parse(curentArg[1]);

            Engine curentEngine = new Engine(horsePower, cubicCapacity);
            engineSets.Add(curentEngine);
        }


        argoment = string.Empty;
        while ((argoment = Console.ReadLine()) != "Show special")
        {
            string[] curentArg = argoment.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string make = curentArg[0];
            string model = curentArg[1];
            int year = int.Parse(curentArg[2]);
            double fuelQuantity = double.Parse(curentArg[3]);
            double fuelConsumption = double.Parse(curentArg[4]);
            Engine neadEngine = engineSets[int.Parse(curentArg[5])];
            Tire[] neadTires = tiresSets[int.Parse(curentArg[6])].ToArray();

            Car curentCar = new Car(make, model, year, fuelQuantity, fuelConsumption, neadEngine, neadTires);
            carColections.Add(curentCar);
        }

        List<Car> specialCars = carColections
                .FindAll(c => c.Year >= 2017
                           && c.Engine.HorsePower > 330
                           && c.Tires.Select(t => t.Pressure).Sum() >= 9
                           && c.Tires.Select(t => t.Pressure).Sum() <= 10);

        foreach (var car in specialCars)
        {
            car.Drive(20);
            Console.WriteLine(car);
        }

    }
}