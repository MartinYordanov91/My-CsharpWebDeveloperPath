using SimpleSnake.GameObjects.Food.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SimpleSnake.GameObjects.Food
{
    public abstract class Food : Point , IFood
    {
        private Wall wall;
        private Random random;
        private char foodSymbol;

        protected Food(Wall wall, char foodSymbol, int point)
            : base(wall.LeftX, wall.TopY)
        {
            this.wall = wall;
            FoodPosition = point;
            this.foodSymbol = foodSymbol;
            random = new Random();
        }

        public int FoodPosition { get; private set; }

        public void SetRandomPosition(Queue<Point> snakeElement)
        {
            LeftX = random.Next(2, wall.LeftX - 2);
            TopY = random.Next(2, wall.TopY - 2);

            bool isPointOfSnakeElement = snakeElement
                .Any(x => x.LeftX == LeftX && x.TopY == TopY);

            while (isPointOfSnakeElement)
            {
                LeftX = random.Next(2, wall.LeftX - 2);
                TopY = random.Next(2, wall.TopY - 2);

                isPointOfSnakeElement = snakeElement
                     .Any(x => x.LeftX == LeftX && x.TopY == TopY);
            }

           // Console.BackgroundColor = ConsoleColor.Green;
            Draw(this.foodSymbol);
           // Console.BackgroundColor = ConsoleColor.White;
        }

        public bool IsFoodPoint(Point snake)
            => snake.TopY == this.TopY && snake.LeftX == this.LeftX;


    }
}
