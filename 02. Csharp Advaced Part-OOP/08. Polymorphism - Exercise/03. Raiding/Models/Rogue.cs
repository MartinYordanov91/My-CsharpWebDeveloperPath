namespace Raiding.Models
{
    public class Rogue : BaseHero
    {
        private const int roguePower = 80;
        public Rogue(string name) 
            : base(name)
        {
        }

        public override int Power 
            => roguePower;

        public override string CastAbility()
            => base.CastAbility() + $"hit for {Power} damage";
    }
}
