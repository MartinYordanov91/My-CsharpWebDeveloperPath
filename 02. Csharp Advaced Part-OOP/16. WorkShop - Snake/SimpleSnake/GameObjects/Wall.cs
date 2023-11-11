using System;
using System.Security.Cryptography;

namespace SimpleSnake.GameObjects
{
    public class Wall : Point
    {
        private const char Symbol = '\u25A0';
        //private const char Symbol = '\u263a';
        //private const char Symbol = '\u263b';
        //private const char Symbol = '\u263c';



        public Wall(int leftX, int topY)
            : base(leftX, topY)
        {
            InitializeWallBorders();
        }

        private void SetHorizontalLine(int topY)
        {
            for (int leftx = 0; leftx < this.LeftX; leftx++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                this.Draw(leftx, topY, Symbol);
                Console.BackgroundColor = ConsoleColor.White;
            }
        }

        private void SetVerticalLine(int leftX)
        {
            for (int topY = 0; topY < this.TopY; topY++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                this.Draw(leftX, topY, Symbol);
                Console.BackgroundColor = ConsoleColor.White;
            }
        }

        private void InitializeWallBorders()
        {
            SetHorizontalLine(0);
            SetHorizontalLine(this.TopY);

            SetVerticalLine(0);
            SetVerticalLine(this.LeftX - 1);
        }

        public bool IsPointOfWall(Point snake)
            => snake.TopY == 0 ||
               snake.LeftX == 0 ||
               snake.LeftX == this.LeftX - 1 ||
               snake.TopY == this.TopY;
    }
}
