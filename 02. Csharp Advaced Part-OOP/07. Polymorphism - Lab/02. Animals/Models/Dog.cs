namespace Animalss.Models
{
    public class Dog: Animal
    {
        public Dog(string name, string favouriteFood)
           : base(name, favouriteFood)
        {
        }

        public override string ExplainSelf()
            => $"{base.ToString()}{Environment.NewLine}DJAAF";
    }
}
