namespace WildFarm.Models.Animals.Birds
{ 
    using WildFarm.Models.Animal;

    public abstract class Bird : Animal
    {
        protected Bird(string name, double weight, double wingSize) 
            : base(name, weight)
        {
            WingSize = wingSize;
        }

        public double WingSize { get; private set; }
    }
}
