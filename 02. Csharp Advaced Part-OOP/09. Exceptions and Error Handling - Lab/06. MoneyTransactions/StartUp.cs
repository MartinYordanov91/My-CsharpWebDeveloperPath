namespace MoneyTransactions
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Dictionary<int, decimal> accounts = new Dictionary<int, decimal>();
            string[] tokens = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries);

            foreach (string token in tokens)
            {
                string[] acc = token.Split('-');
                int accnumber = int.Parse(acc[0]);
                decimal accBalance = decimal.Parse(acc[1]);
                accounts[accnumber] = accBalance;
            }

            string comand = string.Empty;

            while ((comand = Console.ReadLine()) != "End")
            {
                string[] comandArg = comand.Split();
                string operation = comandArg[0];
                int accNumber = int.Parse(comandArg[1]);
                decimal sum = decimal.Parse(comandArg[2]);

                try
                {
                    if (operation != "Deposit" && operation != "Withdraw")
                    {
                        throw new InvalidOperationException("Invalid command!");
                    }

                    if (!accounts.ContainsKey(accNumber))
                    {
                        throw new ArgumentException("Invalid account!");
                    }

                    if (operation == "Withdraw")
                    {
                        if (accounts[accNumber] < sum)
                        {
                            throw new FormatException("Insufficient balance!");
                        }
                        accounts[accNumber] -= sum;
                    }
                    else if (operation == "Deposit")
                    {
                        accounts[accNumber] += sum;
                    }
                    Console.WriteLine($"Account {accNumber} has new balance: {accounts[accNumber]:f2}");
                    Console.WriteLine("Enter another command");

                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Enter another command");
                }
                catch (FormatException a)
                {
                    Console.WriteLine(a.Message);
                    Console.WriteLine("Enter another command");

                }
                catch (InvalidOperationException i)
                {
                    Console.WriteLine(i.Message);
                    Console.WriteLine("Enter another command");

                }

            }
        }
    }
}