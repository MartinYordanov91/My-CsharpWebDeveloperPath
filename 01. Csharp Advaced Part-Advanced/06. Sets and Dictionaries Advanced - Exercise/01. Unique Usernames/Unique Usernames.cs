namespace _01._Unique_Usernames
{
    using System;
    internal class Program
    {
        static void Main(string[] args)
        {

            HashSet<string> listNames = new();
            int number = int.Parse(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                string name = Console.ReadLine();
                listNames.Add(name);
            }


            foreach (string item in listNames)
            {
                Console.WriteLine(item);
            }

        }
    }
}