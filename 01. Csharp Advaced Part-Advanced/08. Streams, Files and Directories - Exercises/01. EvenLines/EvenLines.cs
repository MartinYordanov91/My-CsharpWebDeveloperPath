namespace EvenLines
{
    using System.IO;
    using System;
    using System.Threading;
    using System.Text;
    using System.Linq;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            StringBuilder outpput = new StringBuilder();
            StreamReader inputStreamReader = new StreamReader(inputFilePath);
            int counter = 0;
            while (inputStreamReader.EndOfStream == false)
            {
                char[] simvols = new char[] { '-', ',', '.', '!', '?' };
                StringBuilder curentline = new StringBuilder();
                counter++;
                string line = inputStreamReader.ReadLine();
                if (counter % 2 == 1)
                {
                    foreach (char c in line)
                    {
                        if (simvols.Contains(c))
                        {
                            curentline.Append('@');
                        }
                        else
                        {
                            curentline.Append(c);
                        }
                    }

                    string[] words = curentline.ToString().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    Array.Reverse(words);
                    outpput.AppendLine(string.Join(" " , words));
                }
            }
           return outpput.ToString();
        }
    }
}
