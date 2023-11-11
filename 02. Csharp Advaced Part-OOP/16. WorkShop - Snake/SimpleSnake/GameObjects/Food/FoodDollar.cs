using SimpleSnake.GameObjects.Food.Interface;

namespace SimpleSnake.GameObjects.Food
{
    public class FoodDollar : Food, IFood
    {
        // private const char FoodSymbol = '$';
        private const char FoodSymbol = '\u263b';
        private const int Point = 2;
        public FoodDollar(Wall wall)
            : base(wall, FoodSymbol, Point)
        {
        }
    }
}
