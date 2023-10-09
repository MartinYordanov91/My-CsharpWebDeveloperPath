namespace EnterNumbers
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<int> list = new List<int>();

            while (list.Count != 10)
            {
                string input = Console.ReadLine();

                try
                {
                    bool isANumber = int.TryParse(input, out int number);

                    if (!isANumber)
                    {
                        throw new Exception("Invalid Number!");
                    }

                    if ((list.Count == 0 && number <= 1) || number >= 100)
                    {
                        throw new Exception("Your number is not in range 1 - 100!");
                    }

                    if (list.Count > 0 && list.Last() >= number || number >= 100)
                    {
                        throw new Exception($"Your number is not in range {list.Last()} - 100!");
                    }

                    list.Add(number);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(string.Join(", ", list));
        }
    }
}