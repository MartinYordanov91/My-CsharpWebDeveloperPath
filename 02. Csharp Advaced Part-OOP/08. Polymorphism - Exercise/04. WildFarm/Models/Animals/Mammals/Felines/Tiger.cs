using WildFarm.Models.Food;

namespace WildFarm.Models.Animals.Mammals.Felines
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight,  string livingRegion, string breed)
            : base(name, weight, livingRegion, breed)
        {
        }

        protected override ICollection<Type> PreferentFood 
            => new List<Type>() { typeof(Meat) }.AsReadOnly();

        protected override double WeightMultiplier 
            => 1.00;

        public override string Sound() 
            => "ROAR!!!";

        public override string ToString()
            => base.ToString() + $"{Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
    }
}
