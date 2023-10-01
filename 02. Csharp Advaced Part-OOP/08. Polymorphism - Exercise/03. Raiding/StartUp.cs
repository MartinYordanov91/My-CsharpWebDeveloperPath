using Raiding.Core;
using Raiding.Core.Interface;
using Raiding.Factoryes;
using Raiding.Models;

namespace Raiding
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int rols = int.Parse(Console.ReadLine());
            List<BaseHero> baseHeroes = new List<BaseHero>();
            BaseHeroFactoryes baseHeroFactory = new BaseHeroFactoryes();

            while (baseHeroes.Count != rols) 
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();
                try
                {
                    baseHeroes.Add(baseHeroFactory.CreateHero(heroType, heroName));
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            IEngine engine = new Engine(baseHeroes);
            engine.Run();
        }
    }
}