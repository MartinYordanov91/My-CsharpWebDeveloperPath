using System;
using System.Collections.Generic;
using System.Linq;

namespace TilesMaster
{
    public class StartUp
    {

        public static void Main(string[] args)
        {
            string sink = "Sink";
            string oven = "Oven";
            string countertop = "Countertop";
            string wall = "Wall";
            string floor = "Floor";

            Dictionary<string, int> colection = new Dictionary<string, int>();
            Stack<int> white = new Stack<int>();
            Queue<int> grey = new Queue<int>();

            int[] sequenceWhite = Console.ReadLine()
                .Split().Select(int.Parse).ToArray();

            int[] sequenceGrey = Console.ReadLine()
                .Split().Select(int.Parse).ToArray();

            foreach (int w in sequenceWhite)
            {
                white.Push(w);
            }

            foreach (int g in sequenceGrey)
            {
                grey.Enqueue(g);
            }

            while (white.Any() && grey.Any())
            {
                int curentWhite = white.Pop();
                int curentGrey = grey.Dequeue();

                if (curentWhite != curentGrey)
                {
                    white.Push(curentWhite / 2);
                    grey.Enqueue(curentGrey);

                    continue;
                }

                int sum = curentGrey + curentWhite;
                if (sum == 40) { ImplementObj(colection, sink); }
                else if (sum == 50) { ImplementObj(colection, oven); }
                else if (sum == 60) { ImplementObj(colection, countertop); }
                else if (sum == 70) { ImplementObj(colection, wall); }
                else { ImplementObj(colection, floor); }
            }



            Console.WriteLine(white.Any()
                ? $"White tiles left: {string.Join(", ", white)}"
                : "White tiles left: none");

            Console.WriteLine(grey.Any()
                    ? $"Grey tiles left: {string.Join(", ", grey)}"
                    : "Grey tiles left: none");
            // Variant 1
            //foreach (var item in colection.OrderByDescending(x => x.Value).ThenBy(v => v.Key))
            //{
            //    Console.WriteLine($"{item.Key}: {item.Value}");
            //}

            //variant 2
            Console.WriteLine(string.Join(Environment.NewLine , colection.OrderByDescending(x => x.Value).ThenBy(v => v.Key).Select(k => k.Key +": "+ k.Value)));
        }
        public static void ImplementObj(Dictionary<string, int> colection, string item)
        {
            if (!colection.ContainsKey(item))
            {
                colection[item] = 0;
            }

            colection[item]++;
        }
    }
}
