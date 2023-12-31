﻿namespace Raiding.Models
{
    public class Druid : BaseHero
    {
        private const int druidPower = 80;
        public Druid(string name)
            : base(name)
        {
        }

        public override int Power
            => druidPower;

        public override string CastAbility()
            => base.CastAbility() + $"healed for {Power}";
    }
}
