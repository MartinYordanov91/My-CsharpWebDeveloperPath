namespace PlayCatch
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int countExeptions = 0;
            int[] intArray = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            while (countExeptions != 3)
            {
                string[] tokens = Console.ReadLine().Split();
                string comand = tokens[0];

                try
                {
                    if (comand == "Replace")
                    {
                        string index = tokens[1];
                        string elemnt = tokens[2];
                        int indexInt = FormatCorecly(index);
                        int elementInt = FormatCorecly(elemnt);

                        if (ArrayRange(intArray, indexInt))
                        {
                            intArray[indexInt] = elementInt;
                        }

                    }
                    else if (comand == "Print")
                    {
                        string startIndex = tokens[1];
                        string endIndex = tokens[2];
                        int start = FormatCorecly(startIndex);
                        int end = FormatCorecly(endIndex);

                        if (ArrayRange(intArray, start) && ArrayRange(intArray, end))
                        {
                            Console.WriteLine(string.Join(", ", intArray.Range(start, end)));
                        }
                    }
                    else if (comand == "Show")
                    {
                        string index = tokens[1];
                        int indexElement = FormatCorecly(index);
                        if(ArrayRange(intArray , indexElement))
                        {
                            Console.WriteLine(intArray[indexElement]);
                        }
                    }

                }
                catch (FormatException ex)
                {
                    countExeptions++;
                    Console.WriteLine(ex.Message);
                }
                catch (OverflowException ex)
                {
                    countExeptions++;
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine(string.Join(", ", intArray));
        }

        public static int FormatCorecly(string numberMybe)
        {
            bool isNumber = int.TryParse(numberMybe, out int number);

            if (!isNumber)
            {
                throw new FormatException("The variable is not in the correct format!");
            }
            return number;
        }

        public static bool ArrayRange(int[] array, int index)
        {
            if (index < 0 || array.Length <= index)
            {
                throw new OverflowException("The index does not exist!");
            }
            return true;
        }
    }
    public static class Extension
    {
        public static int[] Range(this int[] array, int start, int end)
        {
            List<int> list = array.ToList();
            return list.GetRange(start, end - start+1).ToArray();
        }
    }
}