namespace Vehicles.Models.Interface
{
    public interface IVehicle
    {
        double FuelQuantity { get; }
        double FuelConsumption { get; }
        string Drive(double distance);
        abstract void Refuel(double liters);
    }
}
