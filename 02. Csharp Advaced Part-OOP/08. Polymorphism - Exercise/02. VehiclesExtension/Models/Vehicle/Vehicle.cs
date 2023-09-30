namespace Vehicles.Models.Vehicle
{
    using Models.Interface;
    public abstract class Vehicle : IVehicle
    {
        protected double tankCapacity;
        protected double fuelQuantity;
        protected double fuelConsumption;

        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        public double TankCapacity
        {
            get => tankCapacity;
            private set
            {
                tankCapacity = value;
            }
        }
        public double FuelQuantity
        {
            get => fuelQuantity;
            private set
            {
                if (value > tankCapacity)
                {
                    value = 0;
                }
                    fuelQuantity = value;
            }
        }
        public double FuelConsumption
        {
            get => fuelConsumption;
            private set
            {
                fuelConsumption = value;
            }
        }


        public virtual string Drive(double distance)
        {
            double needetFuel = distance * fuelConsumption;

            if (needetFuel > fuelQuantity)
            {
                return $"{GetType().Name} needs refueling";
            }
            fuelQuantity -= needetFuel;
            return $"{GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new OverflowException($"Fuel must be a positive number");
            }
            if (liters + fuelQuantity > tankCapacity)
            {
                throw new OverflowException($"Cannot fit {liters} fuel in the tank");
            }
            FuelQuantity += liters;
        }

        public override string ToString()
            => $"{GetType().Name}: {fuelQuantity:f2}";
    }
}
