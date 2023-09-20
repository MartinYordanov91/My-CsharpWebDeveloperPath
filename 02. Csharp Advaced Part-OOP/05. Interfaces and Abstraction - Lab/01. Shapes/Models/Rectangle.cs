﻿using Shapes.Models.inteface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Models
{
    public class Rectangle : IDrawable
    {
        private int width;
        private int height;

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int Width
        {
            get => width;
            private set { width = value; }
        }

        public int Height
        {
            get => height;
            private set { height = value; }
        }

        public void Draw()
        {
            DrawLine(Width, '*','*');
            for (int i = 1; i < Height; ++i)
            {
                DrawLine(Width, '*', ' ');
            }
            DrawLine(Width, '*', '*');
        }
        private void DrawLine(int width, char end, char mid)
        {
            Console.Write(end);
            for (int i = 1; i < width -1; ++i)
            {
                Console.Write(mid);
            }
            Console.WriteLine(end);
        }
    }
}
