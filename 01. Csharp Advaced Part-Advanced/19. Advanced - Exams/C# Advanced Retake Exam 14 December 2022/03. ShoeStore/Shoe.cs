namespace ShoeStore
{
    public class Shoe
    {
        private string material;
        private double size;
        private string type;
        private string brand;

        public Shoe(string brand, string type, double size, string material)
        {
            Brand = brand;
            Type = type;
            Size = size;
            Material = material;
        }

        public string Brand
        {
            get => brand;
            private set { brand = value; }
        }

        public string Type
        {
            get => type;
            private set { type = value; }
        }

        public double Size
        {
            get => size;
            private set { size = value; }
        }

        public string Material
        {
            get => material;
            private set { material = value; }
        }

        public override string ToString()
            => $"Size {size}, {material} {brand} {type} shoe.";
    }
}
