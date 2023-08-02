namespace _01._Odd_Lines
{
    using System;
    using System.IO;
    internal class OddLines
    {
        static void Main()
        {
            using StreamReader sr = new StreamReader(@"..\..\..\Files\input.txt");
            using StreamWriter sw = new StreamWriter(@"..\..\..\Files\output.txt");
            int count = 0;

            while (!sr.EndOfStream)
            {
                string curenLine = sr.ReadLine();
                if (count % 2 == 1)
                {
                    Console.WriteLine(curenLine);
                    sw.WriteLine(curenLine);
                }
                count++;
            }
        }
    }
}