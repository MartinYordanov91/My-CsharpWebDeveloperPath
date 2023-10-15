using System.Runtime.CompilerServices;

namespace ApocalypsePreparation
{
    public class StartUp
    {
        private const int PatchItem = 30;
        private const int BandageItem = 40;
        private const int MedKitItem = 100;

        private const string PatchMed = "Patch";
        private const string BandageMed = "Bandage";
        private const string MedKitMed = "MedKit";

        public static void Main(string[] args)
        {
            Queue<int> textiles = new();
            Stack<int> medicaments = new();
            Dictionary<string, int> helingItemsAmount = new();
            int[] intTokens = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] intTokens2 = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < intTokens.Length; i++)
            {
                textiles.Enqueue(intTokens[i]);
            }

            for (int i = 0; i < intTokens2.Length; i++)
            {
                medicaments.Push(intTokens2[i]);
            }

            while (textiles.Count != 0 && medicaments.Count != 0)
            {
                int tex = textiles.Dequeue();
                int med = medicaments.Pop();

                if (tex + med == PatchItem)
                {
                    AddItem(helingItemsAmount, PatchMed);
                    continue;
                }

                if (tex + med == BandageItem)
                {
                    AddItem(helingItemsAmount, BandageMed);
                    continue;
                }

                if (tex + med == MedKitItem)
                {
                    AddItem(helingItemsAmount, MedKitMed);
                    continue;
                }

                if (tex + med < MedKitItem)
                {
                    med += 10;
                    medicaments.Push(med);
                    continue;
                }

                if (tex + med > MedKitItem)
                {
                    AddItem(helingItemsAmount, MedKitMed);
                    med += tex - 100;
                    med += medicaments.Pop();
                    medicaments.Push(med);
                    continue;
                }

            }

            if (textiles.Count == 0 && medicaments.Count == 0){Console.WriteLine("Textiles and medicaments are both empty.");}
            else if (textiles.Count == 0) { Console.WriteLine("Textiles are empty."); }
            else if (medicaments.Count == 0) { Console.WriteLine("Medicaments are empty."); }

            foreach(var item in helingItemsAmount.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }

            if(medicaments.Count != 0) { Console.WriteLine($"Medicaments left: {string.Join(", " , medicaments)}"); }
            if(textiles.Count != 0) { Console.WriteLine($"Textiles left: {string.Join(", " , textiles)}"); }
        }
        public static void AddItem(Dictionary<string, int> items, string item)
        {
            if (items.ContainsKey(item) == false)
            {
                items[item] = 0;
            }
            items[item] += 1;
        }
    }
}