namespace Stack
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CustomStack<int> integers = new();

            string comand = string.Empty;
            while ((comand = Console.ReadLine()) != "END")
            {
                string[] tocans = comand
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                if (tocans[0] == "Push")
                {
                    int[] ints = tocans.Skip(1).Select(int.Parse).ToArray();
                    foreach (int i in ints)
                    {
                        integers.Push(i);
                    }
                }
                else if (tocans[0] == "Pop")
                {
                    try
                    {
                        integers.Pop();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }
            }

            for (int i = 0; i < 2; i++)
            {
                foreach (var item in integers)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}