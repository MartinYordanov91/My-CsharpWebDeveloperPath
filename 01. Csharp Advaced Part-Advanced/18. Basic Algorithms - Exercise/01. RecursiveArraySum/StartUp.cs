using System.Net;

namespace RecursiveArraySum
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] arrayForSum = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int sum = RecursionSum(arrayForSum, 0);
            Console.WriteLine(sum);


        }

        private static int RecursionSum(int[] ints, int index)
        {

            if (ints.Length - 1 == index)
            {
                return ints[index];
            }

            int num = ints[index++];

            return num + RecursionSum(ints, index);
        }
    }
}