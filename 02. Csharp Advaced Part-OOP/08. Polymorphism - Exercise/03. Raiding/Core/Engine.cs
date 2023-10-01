namespace Raiding.Core
{
    using Interface;
    using Raiding.Models;

    internal class Engine : IEngine
    {
        private List<BaseHero> baseHeroes = new List<BaseHero>();
        public Engine (List<BaseHero> baseHeroes)
        {
            this.baseHeroes = baseHeroes;
        }

        public void Run()
        {
            int bossPwer = int.Parse(Console.ReadLine());
            int heroesPower = 0;

            foreach (var baseHero in baseHeroes)
            {
                Console.WriteLine(baseHero.CastAbility());
                heroesPower += baseHero.Power;
            }

            if(bossPwer <= heroesPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
