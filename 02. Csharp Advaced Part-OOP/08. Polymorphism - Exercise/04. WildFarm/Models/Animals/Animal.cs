
namespace WildFarm.Models.Animal
{
    using Interface;
    using WildFarm.Models.Food;

    public abstract class Animal : IAnimal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
          
        }

        public string Name { get; private set; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }

        protected abstract double WeightMultiplier { get; }
        protected abstract ICollection<Type> PreferentFood { get; }
        public abstract string Sound();
        public void Eat(Food type)
        {
            if (PreferentFood.Contains(type.GetType()) == false)
            {
                throw new ArgumentException($"{GetType().Name} does not eat {type.GetType().Name}!");
            }

            this.FoodEaten += type.Quantity;
            Weight += type.Quantity * WeightMultiplier;
        }

        public override string ToString()
            => $"{GetType().Name} [{Name}, ";
    }
}
