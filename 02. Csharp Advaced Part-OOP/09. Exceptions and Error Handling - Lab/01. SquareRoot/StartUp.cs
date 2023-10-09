namespace SquareRoot
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());

            try
            {
                if(number < 0)
                {
                    throw new ArgumentException("Invalid number.");
                }

                Console.WriteLine(Math.Sqrt(number));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Goodbye.");
        }
    }
}