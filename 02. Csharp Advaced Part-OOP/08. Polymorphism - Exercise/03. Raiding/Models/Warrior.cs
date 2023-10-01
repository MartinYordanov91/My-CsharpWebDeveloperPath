namespace Raiding.Models
{
    public class Warrior : BaseHero
    {
        private const int warriorPower = 100;
        public Warrior(string name) 
            : base(name)
        {
        }

        public override int Power 
            => warriorPower;

        public override string CastAbility()
            => base.CastAbility() + $"hit for {Power} damage";
    }
}
