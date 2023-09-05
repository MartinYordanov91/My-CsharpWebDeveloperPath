namespace MonsterExtermination
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] mopnstersArmor = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[] heroDamage = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Queue<int> queueArmor = new(mopnstersArmor);
            Stack<int> stackDamage = new(heroDamage);
            int monsterCiled = 0;

            while (queueArmor.Any() && stackDamage.Any())
            {
                if (stackDamage.Peek() >= queueArmor.Peek())
                {
                    monsterCiled++;
                    int damage = stackDamage.Pop();

                    if (stackDamage.Any())
                    {
                        int nextDamage = stackDamage.Pop() + (damage - queueArmor.Dequeue());
                        stackDamage.Push(nextDamage);
                        continue;
                    }

                    if (damage - queueArmor.Peek() != 0)
                    {
                        stackDamage.Push(damage - queueArmor.Dequeue());
                        continue;
                    }
                    else queueArmor.Dequeue();

                }
                else
                {
                    int curentArmor = queueArmor.Dequeue() - stackDamage.Pop();
                    queueArmor.Enqueue(curentArmor);
                    
                }
            }

            if (queueArmor.Any() == false)
            {
                Console.WriteLine("All monsters have been killed!");
            }

            if (stackDamage.Any() == false)
            {
                Console.WriteLine("The soldier has been defeated.");
            }

            Console.WriteLine($"Total monsters killed: {monsterCiled}");
        }
    }
}