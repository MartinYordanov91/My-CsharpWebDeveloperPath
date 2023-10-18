namespace BaristaContest
{
    public class StartUp
    {
        public const string cortado = "Cortado";//  50 
        public const string espresso = "Espresso";//  75 
        public const string capuccino = "Capuccino";//    100
        public const string americano = "Americano";//    150
        public const string latte = "Latte";//          200

        public static void Main(string[] args)
        {
            Dictionary<string, int> drinks = new Dictionary<string, int>();

            int[] coffeSequence = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            int[] milckSequence = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Queue<int> coffe = new Queue<int>();

            foreach (int cof in coffeSequence)
            {
                coffe.Enqueue(cof);
            }

            Stack<int> milck = new Stack<int>();

            foreach (var mik in milckSequence)
            {
                milck.Push(mik);
            }

            while (milck.Any() && coffe.Any())
            {
                int coffeQuantity = coffe.Dequeue();
                int milckQuantity = milck.Pop();
                int mililiters = coffeQuantity + milckQuantity;
                if(mililiters == 50) 
                { ChecInstance(drinks, cortado);continue; }
                else if (mililiters == 75) 
                { ChecInstance(drinks, espresso); continue; }
                else if (mililiters == 100) 
                { ChecInstance(drinks, capuccino); continue; }
                else if (mililiters == 150) 
                { ChecInstance(drinks, americano); continue; }
                else if (mililiters == 200) 
                { ChecInstance(drinks, latte); continue; }

                milck.Push(milckQuantity - 5);
            }
            
            if(milck.Any() || coffe.Any())
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
            }
            else
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
            }

            if (coffe.Any())
            {
                Console.WriteLine($"Coffee left: {string.Join(", " , coffe)}");
            }
            else
            {
                Console.WriteLine("Coffee left: none");
            }

            if (milck.Any())
            {
                Console.WriteLine($"Milk left: {string.Join(", " , milck)}");
            }
            else
            {
                Console.WriteLine("Milk left: none");
            }

            foreach (var drink in drinks.OrderBy(x=>x.Value).ThenByDescending(x=>x.Key))
            {
                Console.WriteLine($"{drink.Key}: {drink.Value}");
            }
        }

        public static void ChecInstance(Dictionary<string, int> drinks, string drink)
        {
            if (drinks.ContainsKey(drink) == false)
            {
                drinks[drink] = 0;
            }

            drinks[drink]++;
        }
    }
}