namespace Raiding.Factoryes.Interface
{
    using Raiding.Models;
    public interface IBaseHeroFactoryes
    {
        BaseHero CreateHero(string heroType, string heroName);
    }
}
