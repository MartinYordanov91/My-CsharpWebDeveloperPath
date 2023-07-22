namespace _10._Crossroads
{
    using System;
    using System.Runtime.ConstrainedExecution;
    using System.Xml;

    internal class Program
    {
        static void Main(string[] args)
        {
            //Пътят, по който върви Сам, има една лента, където колите се редят на опашка,
            //докато светофарът светне зелено.
            //Когато стане, те започват да минават
            //един по един по време на зеления светофар и свободния прозорец
            //преди светлините на пресичащия път да светнат зелено.
            // По време на зелен светофар автомобилите ще влизат и излизат един по един от кръстовището.

            int lights = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());
            string programduration = string.Empty;
            Queue<string> carQueue = new();
            int passedCar = 0;
            int greenLight = 0;
            while ((programduration = Console.ReadLine()) != "END")
            {
                string inputArg = programduration;

                if (inputArg != "green")
                {
                    carQueue.Enqueue(inputArg);
                    continue;
                }
                else 
                {
                    greenLight = lights;

                    while (carQueue.Count > 0 && greenLight > 0)
                    {
                        if (carQueue.Peek().Length <= greenLight)
                        {
                            greenLight -= carQueue.Peek().Length;
                            carQueue.Dequeue();
                            passedCar++;
                            continue;
                        }

                        if (greenLight > 0 && greenLight + freeWindow >= carQueue.Peek().Length)
                        {
                            carQueue.Dequeue();
                            passedCar++;
                            break;
                        }

                        string curentCar = carQueue.Dequeue();
                        Queue<char> chars = new(curentCar);

                        for (int i = 0; i < greenLight+freeWindow; i++)
                        {
                            chars.Dequeue();
                        }

                        Console.WriteLine("A crash happened!");
                        Console.WriteLine($"{curentCar} was hit at {chars.Peek()}.");
                        return;
                    }
                }
            }
            if (programduration == "END")
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{passedCar} total cars passed the crossroads.");
            }
        }
    }
}