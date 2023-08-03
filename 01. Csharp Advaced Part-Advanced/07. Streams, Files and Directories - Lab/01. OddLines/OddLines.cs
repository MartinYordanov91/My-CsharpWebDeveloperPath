namespace OddLines
{
    using System;
    using System.IO;
    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";
            ExtractOddLines(inputFilePath, outputFilePath);
        }
        public static void ExtractOddLines(string inputFilePath, string
       outputFilePath)
        {
            using StreamReader sr = new StreamReader(inputFilePath);
            using StreamWriter sw = new StreamWriter(outputFilePath);
            int count = 0;

            while (!sr.EndOfStream)
            {
                string curenLine = sr.ReadLine();
                if (count % 2 == 1)
                {
                    sw.WriteLine(curenLine);
                }
                count++;
            }
        }
    }
}