using SimpleSnake.GameObjects.Food.Interface;
using System;

namespace SimpleSnake.GameObjects.Food
{
    public class FoodHash : Food, IFood
    {
        // private const char FoodSymbol = '\u263c';
        private const char FoodSymbol = '\u263b';
        private const int Point = 3;
        public FoodHash(Wall wall)
            : base(wall, FoodSymbol, Point)
        {
        }
    }
}
