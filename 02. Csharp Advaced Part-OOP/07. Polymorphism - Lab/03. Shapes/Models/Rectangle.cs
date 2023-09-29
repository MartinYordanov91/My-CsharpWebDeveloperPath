namespace Shapes.Models
{
    public class Rectangle : Shape
    {
        private int height;
        private int width;

        public Rectangle(int height, int width)
        {
            this.height = height;
            this.width = width;
        }

        public override double CalculateArea()
            => height * width;

        public override double CalculatePerimeter()
            => (height + width) * 2;
    }
}
