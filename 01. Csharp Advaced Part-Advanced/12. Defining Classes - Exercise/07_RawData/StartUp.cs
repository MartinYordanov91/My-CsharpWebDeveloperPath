namespace DefiningClasses;

public class StartUp
{
    static void Main(string[] args)
    {
        List<Car> cars = new List<Car>();
        int countOfCars = int.Parse(Console.ReadLine());

        for (int i = 0; i < countOfCars; i++)
        {
            string[] carParameters = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Car car = new Car
                (
                    carParameters[0],                  /// model
                    int.Parse(carParameters[1]),       /// speed
                    int.Parse(carParameters[2]),       /// power
                    int.Parse(carParameters[3]),       /// weight
                    carParameters[4],                  /// type
                    double.Parse(carParameters[5]),    /// pressure
                    int.Parse(carParameters[6]),       /// age
                    double.Parse(carParameters[7]),    /// pressure
                    int.Parse(carParameters[8]),       /// age
                    double.Parse(carParameters[9]),    /// pressure
                    int.Parse(carParameters[10]),      /// age
                    double.Parse(carParameters[11]),   /// pressure
                    int.Parse(carParameters[12])       /// age
                );

            cars.Add(car);
        }

        string cargoType = Console.ReadLine();
        List<Car> filteredCar = new List<Car>();

        if (cargoType == "fragile")
        {
            filteredCar = cars
                .Where
                     (
                         x => x.Cargo.Type == "fragile" &&
                         x.Tires.Any(x => x.Pressure < 1)
                     )
                .ToList();
        }
        else if (cargoType == "flammable")
        {
            filteredCar = cars
                .Where
                    (
                        x => x.Cargo.Type == "flammable" &&
                        x.Engine.Power > 250
                    )
                .ToList();
        }

        Console.WriteLine(string.Join(Environment.NewLine , filteredCar));
    }
}
