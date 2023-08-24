namespace GenericCountMethodString
{
    public class StartUp
    {
        public static void Main()
        {
            List<string> integers = new List<string>();
            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                string number = Console.ReadLine();
                integers.Add(number);
            }

            string indexses = Console.ReadLine();
            Console.WriteLine(Count<string>(integers, indexses));
            
        }
        static int Count<T>(List<T> list ,string text)
        {
            int count = 0;
            foreach (var item in list)
            {
                if (text.CompareTo(item) < 0)
                {
                    count++;
                }
            }
            return count;
        }
    }
}