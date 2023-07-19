namespace _8._Traffic_Jam
{
    using System;
    internal class Program
    {
        static void Main(string[] args)
        {
            int countCarsCanPassed = int.Parse(Console.ReadLine());
            Queue<string> vehicleQueue = new();
            int passedVehicle = 0;
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                if (input == "green")
                {
                    for (int i = 0; i < countCarsCanPassed; i++)
                    {
                        if (vehicleQueue.Count > 0)
                        {
                            passedVehicle++;
                            Console.WriteLine($"{vehicleQueue.Dequeue()} passed!");
                        }

                    }
                }
                else
                {
                    vehicleQueue.Enqueue(input);
                }
            }
            Console.WriteLine($"{passedVehicle} cars passed the crossroads.");
        }
    }
}