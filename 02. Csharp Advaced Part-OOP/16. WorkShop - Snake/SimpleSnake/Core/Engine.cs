using System;
using System.Diagnostics;
using System.Threading;
using SimpleSnake.Core.Interface;
using SimpleSnake.Enums;
using SimpleSnake.GameObjects;
using SimpleSnake.GameObjects.Food;

namespace SimpleSnake.Core
{
    public class Engine : IEngine
    {
        private Wall wall;
        private Snake snake;
        private Direction direction;
        private double sleepTime;
        private Point[] pointsDirections;
        private DateTime stopwatch;

        public Engine(Wall wall, Snake snake)
        {
            this.wall = wall;
            this.snake = snake;
            sleepTime = 100;
            pointsDirections = new Point[4];
            stopwatch = DateTime.Now;
        }

        public void Run()
        {
            CreateDirections();

            while (true)
            {
                ShowScore();
                ShowCurentTime();
                TimePLayet();
                CurentPoint();

                if (Console.KeyAvailable)
                {
                    GetNextDirection();
                }

                bool isMolving = snake.IsMoving(pointsDirections[(int)direction]);

                if (!isMolving)
                {
                    AskUserForRestart();
                }

                sleepTime -= 0.01;

                Thread.Sleep((int)sleepTime);
            }
        }

        private void CreateDirections()
        {
            pointsDirections[0] = new Point(1, 0);
            pointsDirections[1] = new Point(-1, 0);
            pointsDirections[2] = new Point(0, 1);
            pointsDirections[3] = new Point(0, -1);
        }

        private void GetNextDirection()
        {
            ConsoleKeyInfo userInput = Console.ReadKey();

            if (userInput.Key == ConsoleKey.LeftArrow)
            {
                if (direction != Direction.Right)
                {
                    direction = Direction.Left;
                }
            }
            else if (userInput.Key == ConsoleKey.RightArrow)
            {
                if (direction != Direction.Left)
                {
                    direction = Direction.Right;
                }
            }
            else if (userInput.Key == ConsoleKey.UpArrow)
            {
                if (direction != Direction.Down)
                {
                    direction = Direction.Up;
                }
            }
            else if (userInput.Key == ConsoleKey.DownArrow)
            {
                if (direction != Direction.Up)
                {
                    direction = Direction.Down;
                }
            }

            Console.CursorVisible = false;
        }

        private void AskUserForRestart()
        {
            int leftX = wall.LeftX + 10;
            int topy = 10;
            Console.SetCursorPosition(30, 15);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Game Over!");
            Console.ForegroundColor = ConsoleColor.Black;

            Console.SetCursorPosition(leftX, topy);
            Console.Write("Would you like to continue? y/n");
            string input = Console.ReadLine();

            if (input == "y")
            {
                Console.Clear();
                StartUp.Main();
            }
            else
            {
                StopGame();
            }
        }

        private void StopGame()
        {
            Console.SetCursorPosition(25, 16);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write("Be Better Next Time!");
            Console.ForegroundColor = ConsoleColor.Black;
            Environment.Exit(0);
        }

        private void ShowScore()
        {
            Console.SetCursorPosition(wall.LeftX + 5, 2);
            Console.Write($"Score: {snake.FoodPoint}");
        }
        private void CurentPoint()
        {
            Console.SetCursorPosition(wall.LeftX + 30, 2);
            Console.Write($"Curent Head Point: {snake.CurentFoodPoint}");
        }

        private void ShowCurentTime()
        {
            DateTime dateTime = DateTime.Now;

            Console.SetCursorPosition(wall.LeftX + 30, 5);
            Console.Write($"Time: {dateTime.Hour}:{dateTime.Minute}:{dateTime.Second}");
        }

        private void TimePLayet()
        {
            TimeSpan dateTime = DateTime.Now - stopwatch;
            string customFormat = @"hh\:mm\:ss";
            string customTime =dateTime.ToString(customFormat);
            Console.SetCursorPosition(wall.LeftX + 5, 5);
            Console.Write($"Play from: {customTime}");
        }


    }
}
