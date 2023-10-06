namespace WildFarm.Factories
{
    using Models.Animal;
    using WildFarm.Models.Animals.Birds;
    using WildFarm.Models.Animals.Mammals;
    using WildFarm.Models.Animals.Mammals.Felines;

    internal class AnimalFactorial
    {
        public Animal AnimalCreate(string type, string name, double weight, string wingOrLiving, string bread = null)
        {
            Animal animal = null;
            if (type == "Owl")
            {
                animal = new Owl(name, weight, double.Parse(wingOrLiving));
            }
            else if (type == "Hen")
            {
                animal = new Hen(name, weight, double.Parse(wingOrLiving));
            }
            else if (type == "Mouse")
            {
                animal = new Mouse(name, weight, wingOrLiving);
            }
            else if (type == "Dog")
            {
                animal = new Dog(name, weight, wingOrLiving);
            }
            else if (type == "Cat")
            {
                animal = new Cat(name, weight, wingOrLiving , bread);
            }
            else if (type == "Tiger")
            {
                animal = new Tiger(name, weight, wingOrLiving, bread);
            }

            return animal;
        }
    }
}
