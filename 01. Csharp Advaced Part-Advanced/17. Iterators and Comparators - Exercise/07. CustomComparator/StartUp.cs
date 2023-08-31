namespace CustomComparator
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int[] ints = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Array.Sort(ints, new CustomComperator());

            Console.WriteLine(string.Join(" " , ints));
        }

        public class CustomComperator : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                if (x % 2 == 0 && y % 2 != 0)
                {
                    return -1;
                }

                if (x % 2 != 0 && y % 2 == 0)
                {
                    return 1;
                }
                return x.CompareTo(y);
            }
        }

    }
}