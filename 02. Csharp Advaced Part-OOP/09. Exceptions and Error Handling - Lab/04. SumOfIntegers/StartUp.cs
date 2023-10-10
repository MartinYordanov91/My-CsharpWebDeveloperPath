using System.Xml.Linq;

namespace SumOfIntegers
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string[] inputItems = Console.ReadLine().Split();
            long sum = 0;

            for (int i = 0; i < inputItems.Length; i++)
            {
                string item = inputItems[i];

                bool isInteger = int.TryParse(item, out int intForSum);
                bool isLonger = long.TryParse(item, out long longForResult);

                if (isInteger)
                {
                    sum += intForSum;
                    Console.WriteLine($"Element '{item}' processed - current sum: {sum}");
                    continue;
                }

                try
                {
                    if (isLonger)
                    {
                        throw new OverflowException($"The element '{longForResult}' is out of range!");
                    }
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine(ex.Message);

                }

                try
                {
                    if (!isLonger)
                    {
                        throw new FormatException($"The element '{item}' is in wrong format!");
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine($"Element '{item}' processed - current sum: {sum}");
            }

            Console.WriteLine($"The total sum of all integers is: {sum}");
        }
    }
}