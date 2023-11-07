namespace RobotService.Models
{
    public class IndustrialAssistant : Robot
    {
        private const int BatteryCapacity = 40_000;
        private const int ConversionCapacityIndex = 5_000;
        public IndustrialAssistant(string model) 
            : base(model, BatteryCapacity, ConversionCapacityIndex)
        {
        }
    }
}
