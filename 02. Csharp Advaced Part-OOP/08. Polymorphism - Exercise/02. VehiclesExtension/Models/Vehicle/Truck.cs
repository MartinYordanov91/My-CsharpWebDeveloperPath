namespace Vehicles.Models.Vehicle
{
    public class Truck : Vehicle
    {
        private const double conditionersConsum = 1.6;
        private const double getFuelRefiling = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption, double tankCapasity)
            : base(fuelQuantity, fuelConsumption + conditionersConsum, tankCapasity)
        {
        }

        public override void Refuel(double liters)
        {

            if (liters <= 0)
            {
                throw new OverflowException($"Fuel must be a positive number");
            }


            if ((liters * getFuelRefiling) + fuelQuantity > tankCapacity)
            {
                throw new OverflowException($"Cannot fit {liters} fuel in the tank");
            }

            fuelQuantity += liters * getFuelRefiling;
        }
    }
}
