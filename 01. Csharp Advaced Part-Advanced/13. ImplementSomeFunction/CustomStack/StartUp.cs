namespace CustomStack
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CustomStack customStack = new CustomStack();

            customStack.Push(1);
            customStack.Push(2);
            customStack.Push(3);
            customStack.Push(4);
            customStack.Push(5);
            Console.WriteLine(customStack.Pop());
            Console.WriteLine(customStack.Peek());
            Console.WriteLine(customStack.Peek());
            Console.WriteLine(customStack.Pop());
            customStack.ForEach(x => Console.Write(x + " "));
        }
    }
}