namespace _04._Even_Times
{
    using System;
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            Dictionary<int, int> set = new();

            for (int i = 0; i < num; i++)
            {
                int inputNum = int.Parse(Console.ReadLine());
                if (set.ContainsKey(inputNum) == false)
                {
                    set[inputNum] = 0;
                }
                set[inputNum]++;
            }

            Console.WriteLine(set.FirstOrDefault(x => x.Value % 2 == 0).Key);

        }
    }
}