using System.Text;

namespace ShoeStore
{
    public class ShoeStore
    {
        private string name;
        private int storageCapacity;
        private List<Shoe> shoes;

        public ShoeStore(string name, int storageCapacity)
        {
            Name = name;
            StorageCapacity = storageCapacity;
            Shoes = new List<Shoe>();
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int StorageCapacity
        {
            get { return storageCapacity; }
            set { storageCapacity = value; }
        }

        public int Count
        {
            get => shoes.Count;
        }

        public List<Shoe> Shoes
        {
            get { return shoes; }
            set { shoes = value; }
        }

        public string AddShoe(Shoe shoe)
        {
            if (storageCapacity > Count)
            {
                this.shoes.Add(shoe);
                return $"Successfully added {shoe.Type} {shoe.Material} pair of shoes to the store.";
            }
            return "No more space in the storage room.";
        }
        public int RemoveShoes(string material)
        {
            // maybe have problem
            int startcount = Count;
            this.shoes = shoes.Where(x => x.Material != material).ToList();
            int endCound = shoes.Count;
            return startcount - endCound;
        }

        public List<Shoe> GetShoesByType(string type)
        {
            List<Shoe> result = shoes.Where(x => x.Type == type.ToLower()).ToList();
            return result;
        }

        public Shoe GetShoeBySize(double size)
            => shoes.FirstOrDefault(n => n.Size == size);

        public string StockList(double size, string type)
        {
            List<Shoe> result = shoes.Where(x => x.Type == type && x.Size == size).ToList();

            StringBuilder sb = new StringBuilder();

            if (result.Any())
            {
                sb.AppendLine($"Stock list for size {size} - {type} shoes:");

                foreach (var item in result)
                {
                    sb.AppendLine(item.ToString());
                    
                }
                return sb.ToString().Trim();
            }
            sb.AppendLine("No matches found!");
            return sb.ToString().Trim();
        }
    }
}

