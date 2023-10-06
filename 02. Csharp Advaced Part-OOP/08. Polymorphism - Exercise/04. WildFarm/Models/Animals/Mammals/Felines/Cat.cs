using WildFarm.Models.Food;

namespace WildFarm.Models.Animals.Mammals.Felines
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed)
            : base(name, weight,  livingRegion, breed)
        {
        }

        protected override ICollection<Type> PreferentFood 
            => new List<Type>() { typeof(Meat) , typeof(Vegetable) }.AsReadOnly();

        protected override double WeightMultiplier 
            => 0.30;

        public override string Sound()
            => "Meow";

        public override string ToString()
            => base.ToString() + $"{Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
    }
}
