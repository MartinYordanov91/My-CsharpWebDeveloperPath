namespace SumOfCoins
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<int> list = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();
            int targetSum = int.Parse(Console.ReadLine());

            try
            {
                Dictionary<int, int> selectionCoin = ChooseCoin(list, targetSum);

                Console.WriteLine($"Number of coins to take: {selectionCoin.Values.Sum()}");

                foreach (var select in selectionCoin)
                {
                    Console.WriteLine($"{select.Value} coin(s) with value {select.Key}");
                }
            }
            catch (InvalidOperationException ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        public static Dictionary<int, int> ChooseCoin(List<int> coins, int targetSum)
        {
            Dictionary<int, int> choosencCoin = new();
            coins = coins.OrderByDescending(x => x).ToList();

            while (targetSum != 0)
            {
                if (targetSum / coins.First() > 1)
                {
                    int value = targetSum / coins.First();
                    int key = coins.First();

                    if (choosencCoin.ContainsKey(key) == false)
                    {
                        choosencCoin[key] = 0;
                    }
                    choosencCoin[key] = value;
                    targetSum -= key * value;
                }

                foreach (int coin in coins)
                {
                    if (coin <= targetSum)
                    {
                        if (choosencCoin.ContainsKey(coin) == false)
                        {
                            choosencCoin[coin] = 0;
                        }
                        choosencCoin[coin]++;
                        targetSum -= coin;
                        break;
                    }
                }

                if (targetSum > 0 && coins.Last() > targetSum)
                {
                    throw new InvalidOperationException("Error");
                }
            }
            return choosencCoin;
        }
    }
}