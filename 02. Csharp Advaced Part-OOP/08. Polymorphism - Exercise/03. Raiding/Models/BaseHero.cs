namespace Raiding.Models
{
    using Interface;
    public abstract class BaseHero : IBaseHero
    {
        protected BaseHero(string name)
        {
            Name = name;
        }

        public string Name { get; protected set; }

        public abstract int Power { get; }

        public virtual string CastAbility()
            => $"{GetType().Name} - {Name} ";
        
    }
}
