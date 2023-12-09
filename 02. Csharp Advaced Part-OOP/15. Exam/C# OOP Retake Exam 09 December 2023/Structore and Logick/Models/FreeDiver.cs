namespace NauticalCatchChallenge.Models
{
    public class FreeDiver : Diver
    {
        private const int OxygenLevel = 120;
        public FreeDiver(string name)
            : base(name, OxygenLevel)
        {
        }

        public override void Miss(int TimeToCatch)
        {
            base.OxygenLevel -= (int)Math.Round(TimeToCatch * 0.6, MidpointRounding.AwayFromZero);
        }

        public override void RenewOxy()
        {
            base.OxygenLevel = 120;
        }
    }
}
