namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            StringBuilder stringBuilder = new StringBuilder();
            string[] text = File.ReadAllLines(inputFilePath);
            for (int i = 0; i < text.Length; i++)
            {
                int countLeters = text[i].Count(c => char.IsLetter(c));
                int countPunctuation = text[i].Count(c => char.IsPunctuation(c));
                stringBuilder.AppendLine($"Line {i+1}: {text[i]} ({countLeters})({countPunctuation})");
            }

            File.WriteAllText(outputFilePath,stringBuilder.ToString());
        }
    }
}
