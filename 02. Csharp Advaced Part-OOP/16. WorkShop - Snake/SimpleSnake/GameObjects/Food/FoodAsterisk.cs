using SimpleSnake.GameObjects.Food.Interface;

namespace SimpleSnake.GameObjects.Food
{
    public class FoodAsterisk : Food, IFood
    {
        private const char FoodSymbol = '\u263b';
        //private const char FoodSymbol = '*';
        private const int Point = 1;

        public FoodAsterisk(Wall wall) 
            : base(wall, FoodSymbol, Point)
        {
            
        }
    }
}
