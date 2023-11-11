using System.Collections.Generic;

namespace SimpleSnake.GameObjects.Food.Interface
{
    public interface IFood
    {
        int FoodPosition { get; }
        void SetRandomPosition(Queue<Point> snakeElement);
        bool IsFoodPoint(Point snake);
    }
}
