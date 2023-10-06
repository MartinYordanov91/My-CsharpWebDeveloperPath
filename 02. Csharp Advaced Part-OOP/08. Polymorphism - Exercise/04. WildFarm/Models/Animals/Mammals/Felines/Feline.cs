namespace WildFarm.Models.Animals.Mammals.Felines
{
    public abstract class Feline : Mammal
    {
        protected Feline(string name, double weight,  string livingRegion, string breed)
            : base(name, weight,  livingRegion)
        {
            Breed = breed;
        }

        public string Breed { get; set; }
    }
}
