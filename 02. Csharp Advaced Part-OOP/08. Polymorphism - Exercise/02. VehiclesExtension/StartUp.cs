using Vehicles.Core;
using Vehicles.Core.Interface;
using Vehicles.Factories;
using Vehicles.Factories.Interface;
using Vehicles.Models.Vehicle;

namespace Vehicles
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] carArg = Console.ReadLine()
                .Split();
            string[] truckArg = Console.ReadLine()
                .Split();
            string[] busArg = Console.ReadLine()
                .Split();

            IVehicleFactories factories = new VehicleFactories();

            Vehicle car = factories.CreateVehhicle(carArg[0], double.Parse(carArg[1]), double.Parse(carArg[2]), double.Parse(carArg[3]));
            Vehicle truck = factories.CreateVehhicle(truckArg[0], double.Parse(truckArg[1]), double.Parse(truckArg[2]), double.Parse(truckArg[3]));
            Vehicle bus = factories.CreateVehhicle(busArg[0], double.Parse(busArg[1]), double.Parse(busArg[2]), double.Parse(busArg[3]));

            IEngine engine = new Engine(car, truck, bus);
            engine.Run();
        }
    }
}