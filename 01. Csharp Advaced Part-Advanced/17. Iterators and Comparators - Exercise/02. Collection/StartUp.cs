namespace ListyIterator
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<string> create = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .ToList();
            ListyIterator<string> listy = new(create);

            string comand = string.Empty;
            while ((comand = Console.ReadLine())!="END")
            {
                switch (comand)
                {
                    case "Move":
                        Console.WriteLine(listy.Move());
                        break;
                    case "Print":
                        try
                        {
                            listy.Print();
                        }
                        catch (Exception ex) 
                        {

                            Console.WriteLine(ex.Message);
                        }
                        
                        break;
                    case "HasNext":
                        Console.WriteLine(listy.HasNext());
                        break;
                    case "PrintAll":
                        foreach (var item in listy)
                        {
                            Console.Write($"{item} ");
                        }
                        Console.WriteLine();
                        break;
                }
            }

        }
    }
}