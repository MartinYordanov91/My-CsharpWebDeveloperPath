using Vehicles.Factories.Interface;
using Vehicles.Models.Vehicle;

namespace Vehicles.Factories
{
    public class VehicleFactories : IVehicleFactories
    {
        public Vehicle CreateVehhicle(string type, double quantity, double consumption , double tankCapacity)
        {
            Vehicle vehicle;

            if (type == "Car") { vehicle = new Car(quantity, consumption , tankCapacity); }

            else if (type == "Truck") { vehicle = new Truck(quantity, consumption, tankCapacity); }

            else if (type == "Bus") { vehicle = new Bus(quantity, consumption, tankCapacity); }

            else { throw new ArgumentException("Invalid Type"); }

            return vehicle;
        }
    }
}
