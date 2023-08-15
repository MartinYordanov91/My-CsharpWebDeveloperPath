namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            string comand = string.Empty;

            while ((comand = Console.ReadLine()) != "Tournament")
            {
                string[] infoArg = comand
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string trainerName = infoArg[0];
                string pokemonName = infoArg[1];
                string element = infoArg[2];
                int healt = int.Parse(infoArg[3]);

                Pokemon pokemon = new Pokemon(pokemonName, element, healt);

                if (trainers.Any(x => x.Name == trainerName) == false)
                {
                    Trainer trainer = new Trainer(trainerName);
                    trainer.Pokemons.Add(pokemon);
                    trainers.Add(trainer);
                }
                else
                {
                    Trainer trainer = trainers.First(x => x.Name == trainerName);
                    trainer.Pokemons.Add(pokemon);
                }

            }

            while ((comand = Console.ReadLine()) != "End")
            {
                foreach (var traner in trainers)
                {
                    if (traner.Pokemons.Any(x => x.Element == comand))
                    {
                        traner.Badges++;
                    }
                    else
                    {
                        traner.Pokemons.ForEach(x => x.Health -= 10);
                    }

                    while (traner.Pokemons.Any(x => x.Health <= 0))
                    {
                        Pokemon death = traner.Pokemons.First(x => x.Health <= 0);
                        traner.Pokemons.Remove(death);
                    }
                }
            }

            foreach (var trainer in trainers.OrderByDescending(x =>x.Badges))
            {
                Console.WriteLine(trainer);
            }
        }
    }
}