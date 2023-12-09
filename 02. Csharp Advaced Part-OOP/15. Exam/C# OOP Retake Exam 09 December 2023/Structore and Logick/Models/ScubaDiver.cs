namespace NauticalCatchChallenge.Models
{
    public class ScubaDiver : Diver
    {
        private const int OxygenLevel = 540;
        public ScubaDiver(string name) 
            : base(name, OxygenLevel)
        {

        }

        public override void Miss(int TimeToCatch)
        {
            base.OxygenLevel -= (int)Math.Round(TimeToCatch * 0.6, MidpointRounding.AwayFromZero);
        }

        public override void RenewOxy()
        {
            base.OxygenLevel = 540;
        }
    }
}
