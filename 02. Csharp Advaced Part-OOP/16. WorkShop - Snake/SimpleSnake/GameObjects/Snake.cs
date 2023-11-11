using SimpleSnake.GameObjects.Food;
using SimpleSnake.GameObjects.Food.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {
        private const char snakeSymbol = '\u263b';
        private const char emtySpace = ' ';
        //private const char Symbol = '\u263c';

        private Wall wall;
        private Queue<Point> snakeElements;
        private List<IFood> foods;

        private int nextLeftX;
        private int nextTopY;
        private int foodIndex;
        
        public Snake(Wall wall)
        {
            this.wall = wall;
            snakeElements = new Queue<Point>();
            foods = new List<IFood>();
 
            foodIndex = RandomFoodNumber;

            this.CetFoods();
            this.CreateSnake();
            this.createFoods();
        }
        public int FoodPoint { get; set; }

        public int CurentFoodPoint
            => foods[foodIndex].FoodPosition;

        private int RandomFoodNumber =>
            new Random().Next(0 , foods.Count);
        
        private void CreateSnake()
        {
            for (int topY = 1; topY <= 9; topY++)
            {
                snakeElements.Enqueue(new Point(2, topY));
            }
        }

        private void CetFoods()
        {
            foods.Add(new FoodAsterisk(wall));
            foods.Add(new FoodDollar(wall));
            foods.Add(new FoodHash(wall));
        }

        private void GetNextPoint(Point direction, Point snakeHead)
        {
            nextLeftX = snakeHead.LeftX + direction.LeftX;
            nextTopY = snakeHead.TopY + direction.TopY;
        }

        public bool IsMoving(Point direction)
        {
            Point curentSnakeHead = snakeElements.Last();

            GetNextPoint(direction, curentSnakeHead);

            bool isPointOfSnake = snakeElements
                .Any(x =>  x.LeftX == nextLeftX && x.TopY == nextTopY);

            if (isPointOfSnake)
            {
                return false;
            }

            Point newSnakeHead = new Point(nextLeftX, nextTopY);

            if (wall.IsPointOfWall(newSnakeHead))
            {
                return false;
            }

            snakeElements.Enqueue(newSnakeHead);
            newSnakeHead.Draw(snakeSymbol);

            if (foods[foodIndex].IsFoodPoint(newSnakeHead))
            {
                Eat(direction, curentSnakeHead);
            }

            Point snakeTail = snakeElements.Dequeue();
            snakeTail.Draw(emtySpace);
            return true;
        }
        private void Eat(Point direction, Point curentSnakeHead)
        {
            int lengt = foods[foodIndex].FoodPosition;

            
            for (int i = 0; i < lengt; i++)
            {
                snakeElements.Enqueue(new Point(nextLeftX, nextTopY));
                GetNextPoint(direction, curentSnakeHead);
            }
            FoodPoint += lengt;
           createFoods();
        }
        private void createFoods()
        {
            foodIndex = RandomFoodNumber;
            foods[foodIndex].SetRandomPosition(snakeElements);
        }
    }
}
