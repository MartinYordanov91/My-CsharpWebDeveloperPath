using WildFarm.Models.Food;

namespace WildFarm.Models.Animals.Mammals
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion)
            : base(name, weight,  livingRegion)
        {
        }

        protected override ICollection<Type> PreferentFood 
            => new List<Type>() { typeof(Meat) }.AsReadOnly();

        protected override double WeightMultiplier 
            => 0.40;

        public override string Sound()
            => "Woof!";

        public override string ToString()
            => base.ToString() + $"{Weight}, {LivingRegion}, {FoodEaten}]";
    }
}
