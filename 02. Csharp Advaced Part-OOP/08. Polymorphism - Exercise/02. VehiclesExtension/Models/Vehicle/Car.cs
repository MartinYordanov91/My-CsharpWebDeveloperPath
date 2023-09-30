namespace Vehicles.Models.Vehicle
{
    public class Car : Vehicle
    {
        private const double conditionersConsum = 0.9;

        public Car(double fuelQuantity, double fuelConsumption, double tankCapasity)
            : base(fuelQuantity, fuelConsumption + conditionersConsum, tankCapasity)
        {
        }

    }
}
