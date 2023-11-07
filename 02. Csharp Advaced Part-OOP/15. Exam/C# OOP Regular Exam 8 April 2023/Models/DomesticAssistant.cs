namespace RobotService.Models
{
    public class DomesticAssistant : Robot
    {
        private const int BatteryCapacity = 20_000;
        private const int ConversionCapacityIndex = 2_000;
        public DomesticAssistant(string model)
            : base(model, BatteryCapacity, ConversionCapacityIndex)
        {

        }
    }
}
