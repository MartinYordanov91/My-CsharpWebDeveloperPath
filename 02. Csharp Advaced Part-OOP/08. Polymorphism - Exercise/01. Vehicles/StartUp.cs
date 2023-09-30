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

            IVehicleFactories factories = new VehicleFactories();

            Vehicle car = factories.CreateVehhicle(carArg[0] , double.Parse(carArg[1]) , double.Parse(carArg[2]));
            Vehicle truck = factories.CreateVehhicle(truckArg[0] , double.Parse(truckArg[1]) , double.Parse(truckArg[2]));

            IEngine engine = new Engine(car, truck);
            engine.Run();
        }
    }
}