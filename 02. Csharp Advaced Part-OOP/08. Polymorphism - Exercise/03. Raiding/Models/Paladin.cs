namespace Raiding.Models
{
    public class Paladin : BaseHero
    {
        private const int paladinPower = 100;
        public Paladin(string name)
            : base(name)
        {
        }

        public override int Power
            => paladinPower;

        public override string CastAbility()
          => base.CastAbility() + $"healed for {Power}";
    }
}
