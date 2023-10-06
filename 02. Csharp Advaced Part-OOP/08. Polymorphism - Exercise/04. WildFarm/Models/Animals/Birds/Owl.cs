
namespace WildFarm.Models.Animals.Birds
{
    using Microsoft.VisualBasic;
    using WildFarm.Models.Food;
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize)
            : base(name, weight, wingSize)
        {
        }

        protected override ICollection<Type> PreferentFood 
            => new List<Type>() { typeof(Meat) }.AsReadOnly();

        protected override double WeightMultiplier 
            => 0.25;

        public override string Sound()
            => "Hoot Hoot";

        public override string ToString()
            => base.ToString() + $"{WingSize}, {Weight}, {FoodEaten}]";
    }
}
