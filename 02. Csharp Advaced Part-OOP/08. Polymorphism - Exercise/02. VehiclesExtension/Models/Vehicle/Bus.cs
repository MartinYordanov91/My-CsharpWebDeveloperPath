namespace Vehicles.Models.Vehicle
{
    public class Bus : Vehicle
    {
        private const double conditionersConsum = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapasity) 
            : base(fuelQuantity, fuelConsumption, tankCapasity)
        {
        }

        public override string Drive(double distance)
        {
            string output = string.Empty;
            base.fuelConsumption += conditionersConsum;
            output = base.Drive(distance);
            base.fuelConsumption -= conditionersConsum;
            return output;
        }

        public string DriveEmty(double distance)
            => base.Drive(distance);
    }
}
