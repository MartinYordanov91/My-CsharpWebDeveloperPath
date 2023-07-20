namespace _07._Truck_Tour
{
    using System;
    internal class Program
    {
        static void Main(string[] args)
        {
            int traks = int.Parse(Console.ReadLine());
            Queue<int[]> petrollstation = new();
            int index = 0;

            for (int i = 0; i < traks; i++)
            {
                petrollstation.Enqueue(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            }

            while (true)
            {
                int curentPetrol = 0;

                foreach (var item in petrollstation)
                {
                    int Petrol = item[0];
                    int distance = item[1];
                    curentPetrol += Petrol;
                    curentPetrol -= distance;

                    if (curentPetrol < 0)
                    {
                        int[] queueReplace = petrollstation.Dequeue();
                        petrollstation.Enqueue(queueReplace);
                        index++;
                        break;
                    }
                }

                if (curentPetrol >= 0)
                {
                    Console.WriteLine( index);
                    break;
                }
            }
        }
    }
}