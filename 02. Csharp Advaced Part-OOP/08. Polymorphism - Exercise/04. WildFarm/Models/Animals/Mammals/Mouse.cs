using WildFarm.Models.Food;

namespace WildFarm.Models.Animals.Mammals
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion)
            : base(name, weight,  livingRegion)
        {
        }

        protected override ICollection<Type> PreferentFood 
            => new List<Type>() { typeof(Fruit), typeof(Vegetable) }.AsReadOnly();

        protected override double WeightMultiplier
            => 0.10;

        public override string Sound()
            => "Squeak";

        public override string ToString()
            => base.ToString() + $"{Weight}, {LivingRegion}, {FoodEaten}]";
    }
}
