namespace Animals.Core
{
    using Animalss.Models;
    using Interface;
    public class Engine : IEngine
    {
        public void Run()
        {
            Animal cat = new Cat("Peter", "Whiskas");
            Animal dog = new Dog("George", "Meat");
            Console.WriteLine(cat.ExplainSelf());
            Console.WriteLine(dog.ExplainSelf());
        }
    }
}
