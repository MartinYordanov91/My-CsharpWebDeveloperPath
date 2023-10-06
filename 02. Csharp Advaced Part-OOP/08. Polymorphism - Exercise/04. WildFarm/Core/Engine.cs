namespace WildFarm.Core
{
    using Interface;
    using WildFarm.Factories;
    using WildFarm.Models.Animal;
    using WildFarm.Models.Food;

    public class Engine : IEngine
    {
        private AnimalFactorial animalFactorial = new AnimalFactorial();
        private FoodFactorial foodFactorial = new FoodFactorial();
        private List<Animal> animals = new List<Animal>();
        public void Run()
        {

            string comand = string.Empty;
            while ((comand = Console.ReadLine()) != "End")
            {
                string[] animalArg = comand.Split();
                string[] foodArg = Console.ReadLine().Split();

                string animalType = animalArg[0];
                string animalNAme = animalArg[1];
                double animalWeight = double.Parse(animalArg[2]);
                string animalWingOrLiving = animalArg[3];

                string foodType = foodArg[0];
                int foodQuantity = int.Parse(foodArg[1]);

                Animal animal = null;

                if (animalArg.Length == 4)
                {
                    animal = animalFactorial.AnimalCreate(animalType, animalNAme, animalWeight, animalWingOrLiving);
                }
                else
                {
                    animal = animalFactorial.AnimalCreate(animalType, animalNAme, animalWeight, animalWingOrLiving, animalArg[4]);
                }

                Console.WriteLine(animal.Sound());

                Food food = foodFactorial.FoodCreate(foodType, foodQuantity);
                try
                {
                    animals.Add(animal);
                    animal.Eat(food);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal);
            }
        }
    }
}
