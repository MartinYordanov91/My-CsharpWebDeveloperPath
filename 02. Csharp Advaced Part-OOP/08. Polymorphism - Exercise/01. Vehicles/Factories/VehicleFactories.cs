using Vehicles.Factories.Interface;
using Vehicles.Models.Vehicle;

namespace Vehicles.Factories
{
    public class VehicleFactories : IVehicleFactories
    {
        public Vehicle CreateVehhicle(string type, double quantity, double consumption)
        {
            Vehicle vehicle;

            if (type == "Car") { vehicle = new Car(quantity, consumption); }

            else if (type == "Truck") { vehicle = new Truck(quantity, consumption); }

            else { throw new ArgumentException("Invalid Type"); }

            return vehicle;
        }
    }
}
