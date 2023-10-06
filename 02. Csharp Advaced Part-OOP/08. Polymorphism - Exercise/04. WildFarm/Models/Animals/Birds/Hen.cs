using WildFarm.Models.Food;

namespace WildFarm.Models.Animals.Birds
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize)
            : base(name, weight,  wingSize)
        {
        }

        protected override ICollection<Type> PreferentFood 
            => new List<Type>() { typeof(Meat), typeof(Fruit) , typeof(Seeds) , typeof(Vegetable) }.AsReadOnly();

        protected override double WeightMultiplier 
            => 0.35;

        public override string Sound()
            => "Cluck";

        public override string ToString()
            => base.ToString() + $"{WingSize}, {Weight}, {FoodEaten}]";
    }
}
