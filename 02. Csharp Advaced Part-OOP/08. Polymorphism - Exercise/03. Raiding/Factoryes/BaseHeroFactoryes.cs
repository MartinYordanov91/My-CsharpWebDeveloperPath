using Raiding.Factoryes.Interface;
using Raiding.Models;
using Raiding.Models.Interface;

namespace Raiding.Factoryes
{
    public class BaseHeroFactoryes : IBaseHeroFactoryes
    {
        public BaseHero CreateHero(string heroType, string heroName)
        {
            BaseHero baseHeroes;

            if (heroType == "Druid")
            {
                baseHeroes = new Druid(heroName);
            }
            else if (heroType == "Paladin")
            {
                baseHeroes = new Paladin(heroName);
            }
            else if (heroType == "Rogue")
            {
                baseHeroes = new Rogue(heroName);
            }
            else if (heroType == "Warrior")
            {
                baseHeroes = new Warrior(heroName);
            }
            else
            {
                throw new ArgumentException("Invalid hero!");
            }
           
            return baseHeroes;
        }
    }
}
