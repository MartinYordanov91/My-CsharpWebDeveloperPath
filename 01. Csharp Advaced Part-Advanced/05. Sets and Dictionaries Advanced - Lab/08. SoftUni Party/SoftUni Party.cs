namespace _08._SoftUni_Party
{
    using System;
    internal class Program
    {
        static void Main(string[] args)
        {
            string comand = string.Empty;
            HashSet<string> listReservation = new();

            while ((comand = Console.ReadLine()) != "PARTY")
            {
                listReservation.Add(comand);
            }

            while ((comand = Console.ReadLine()) != "END")
            {
                listReservation.Remove(comand);
            }
            Console.WriteLine(listReservation.Count);
            if (listReservation.Any())
            {
                foreach (string item in listReservation.OrderByDescending(n => char.IsDigit(n[0])))
                {
                    Console.WriteLine(item);
                }
            }

        }
    }
}