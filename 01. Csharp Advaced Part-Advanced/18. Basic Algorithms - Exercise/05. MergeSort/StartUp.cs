namespace MergeSort
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<int> ints = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToList();

            ints = Sort(ints);

            Console.WriteLine(string.Join(" " ,ints));

            List<int> Sort(List<int> list)
            {
                if (list.Count <= 1)
                {
                    return list;
                }

                List<int> left = new();
                List<int> right = new();

                for (int i = 0; i < list.Count; i++)
                {
                    if (i < list.Count / 2)
                    {
                        left.Add(list[i]);
                    }
                    else
                    {
                        right.Add(list[i]);
                    }
                }

                List<int> leftArray = Sort(left);
                List<int> rightArray = Sort(right);

                return MargenSortList(leftArray, rightArray);
            }

            List<int> MargenSortList(List<int> left, List<int> right)
            {
                List<int> margetList = new();

                while (left.Count + right.Count != 0)
                {
                    if (left.Count == 0)
                    {
                        margetList.Add(right[0]);
                        right.RemoveAt(0);
                        continue;
                    }

                    if (right.Count == 0)
                    {
                        margetList.Add(left[0]);
                        left.RemoveAt(0);
                        continue;
                    }

                    if (left[0] > right[0])
                    {
                        margetList.Add(right[0]);
                        right.RemoveAt(0);
                    }
                    else
                    {
                        margetList.Add(left[0]);
                        left.RemoveAt(0);
                    }
                }

                return margetList;
            }
        }

    }

}