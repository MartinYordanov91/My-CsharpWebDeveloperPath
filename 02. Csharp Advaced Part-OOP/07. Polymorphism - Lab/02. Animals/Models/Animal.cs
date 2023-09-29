namespace Animalss.Models
{
    public abstract class Animal
    {
        private string name;
        private string favouriteFood;

        public Animal(string name, string favouriteFood)
        {
            this.name = name;
            this.favouriteFood = favouriteFood;
        }

       public abstract string ExplainSelf();

        public override string ToString()
            => $"I am {name} and my fovourite food is {favouriteFood}";

    }
}
