using Vehicles.Models.Vehicle;

namespace Vehicles.Factories.Interface
{
    public interface IVehicleFactories
    {
        Vehicle CreateVehhicle(string type, double quantity, double consumption , double tankCapacity);
    }
}
