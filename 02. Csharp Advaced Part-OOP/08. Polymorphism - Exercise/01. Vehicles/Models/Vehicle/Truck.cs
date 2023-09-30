namespace Vehicles.Models.Vehicle
{
    public class Truck : Vehicle
    {
        private const double conditionersConsum = 1.6;
        private const double getFuelRefiling = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
        {
        }

        public override double ConditionersConsum
            => conditionersConsum;
        public override void Refuel(double liters)
            => base.Refuel(liters * getFuelRefiling);
    }
}
