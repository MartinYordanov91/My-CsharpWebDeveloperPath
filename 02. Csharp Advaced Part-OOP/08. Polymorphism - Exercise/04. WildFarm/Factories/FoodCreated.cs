
namespace WildFarm.Factories
{
    using Models.Food;
    public class FoodFactorial
    {
        public Food FoodCreate(string type, int quantity)
        {
            Food food = null;

            if (type == "Vegetable")
            {
                food = new Vegetable(quantity);
            }
            else if (type == "Fruit")
            {
                food = new Fruit(quantity);
            }
            else if (type == "Meat")
            {
                food = new Meat(quantity);
            }
            else if (type == "Seeds")
            {
                food = new Seeds(quantity);
            }

            return food;
        }
    }
}
