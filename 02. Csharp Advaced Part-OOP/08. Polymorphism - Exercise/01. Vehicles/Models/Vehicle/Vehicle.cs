namespace Vehicles.Models.Vehicle
{
    using Models.Interface;
    public abstract class Vehicle : IVehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public abstract double ConditionersConsum { get; }
        public double FuelQuantity { get; private set; }
        public double FuelConsumption { get; private set; }

        public string Drive(double distance)
        {
            double needetFuel = distance * (ConditionersConsum + FuelConsumption);

            if (needetFuel > FuelQuantity)
            {
                return $"{GetType().Name} needs refueling";
            }
            FuelQuantity -= needetFuel;
            return $"{GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double liters)
            => FuelQuantity += liters;
        
        public override string ToString()
            => $"{GetType().Name}: {FuelQuantity:f2}";
    }
}
