namespace CustomQueue
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CustomQueue customQueue = new CustomQueue();

            customQueue.Enqueue(1);
            customQueue.Enqueue(2);
            customQueue.Enqueue(3);
            customQueue.Enqueue(4);
            customQueue.Enqueue(5);
            Console.WriteLine(customQueue.Dequeue()) ;
            Console.WriteLine(customQueue.Peek()) ;
            Console.WriteLine(customQueue.Peek()) ;
            Console.WriteLine(customQueue.Dequeue()) ;
            customQueue.ForEach(x => Console.Write(x + " "));
            Console.WriteLine();
            Console.WriteLine(customQueue.Clear());
        }
    }
}