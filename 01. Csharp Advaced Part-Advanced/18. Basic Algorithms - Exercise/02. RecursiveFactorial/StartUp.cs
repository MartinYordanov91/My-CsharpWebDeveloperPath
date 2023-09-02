namespace RecursiveFactorial
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int factorialNumber = int.Parse(Console.ReadLine());

            Console.WriteLine(CustomRecursiveFactorial(factorialNumber));
        }
        private static long CustomRecursiveFactorial(int value)
        {
            if (value <= 1)
            {
                return 1;
            }

            int number = value --;

            return number * CustomRecursiveFactorial(value);
        }
    }
}