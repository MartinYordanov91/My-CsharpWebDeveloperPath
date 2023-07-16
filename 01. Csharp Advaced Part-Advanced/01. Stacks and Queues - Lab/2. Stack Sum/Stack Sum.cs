namespace _2._Stack_Sum
{
    using System;
    using System.Text;

    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            Stack<int> stack = new();
            foreach (int i in list)
            {
                stack.Push(i);
            }

            string curentInput = string.Empty;
            while ((curentInput = (Console.ReadLine()).ToLower()) != "end")
            {
                string[] comandARG = curentInput.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string comand = comandARG[0];
                if (comand == "add")
                {
                    int intFirst = int.Parse(comandARG[1]);
                    int intSecond = int.Parse(comandARG[2]);
                    stack.Push(intFirst);
                    stack.Push(intSecond);
                }
                else if (comand == "remove")
                {
                    int nNumbers = int.Parse(comandARG[1]);
                    if (stack.Count > nNumbers)
                    {
                        for (int i = 0; i < nNumbers; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }

        //public static string ToLLower(string curentInput)
        //{
        //    char[] chars = curentInput.ToCharArray();
        //    StringBuilder sb = new();
        //    for (int i = 0; i < chars.Length; i++)
        //    {

        //        sb.Append(char.ToLower(chars[i]));
        //    }
        //    return sb.ToString();
        //}
    }
}