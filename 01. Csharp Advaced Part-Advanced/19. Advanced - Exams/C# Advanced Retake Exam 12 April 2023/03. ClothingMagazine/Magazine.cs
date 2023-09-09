using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ClothesMagazine
{
    public class Magazine
    {
        public Magazine(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            Clothes = new();
        }

        public string Type { get; set; }
        public int Capacity { get; set; }
        public List<Cloth> Clothes { get; set; }

        public int GetClothCount (){  return Clothes.Count; }

        public void AddCloth(Cloth cloth)
        {
            if (this.Clothes.Count < this.Capacity)
            {
                Clothes.Add(cloth);
            }
        }

        public bool RemoveCloth(string color)
        {
            if (Clothes.Any(x => x.Color == color))
            {
                Clothes.Remove(Clothes.FirstOrDefault(x => x.Color == color));
                return true;
            }
            return false;
        }
        public Cloth GetSmallestCloth()
        {
            Cloth minValue = Clothes.MinBy(x => x.Size);
            return minValue;
        }
        public Cloth GetCloth(string color)
        {
            return Clothes.FirstOrDefault(x => x.Color == color);
        }
        public string Report()
        {
            StringBuilder sb = new();
            sb.AppendLine($"{this.Type} magazine contains:");

            foreach (var cloth in Clothes.OrderBy(x =>x.Size))
            {
                sb.AppendLine(cloth.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}
