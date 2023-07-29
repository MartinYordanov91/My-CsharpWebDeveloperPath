namespace _07._Parking_Lot
{
    using System;
    internal class Program
    {
        static void Main(string[] args)
        {
            string comand = string.Empty;
            HashSet<string> carList = new();

            while ((comand = Console.ReadLine())!= "END")
            {
                string[] comandArg = comand.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string direction = comandArg[0];
                string carNumber = comandArg[1];

                if(direction == "IN")
                {
                    carList.Add(carNumber);
                }
                else
                {
                    carList.Remove(carNumber);
                }
            }
            if (carList.Any())
            {
                foreach (var item in carList)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}