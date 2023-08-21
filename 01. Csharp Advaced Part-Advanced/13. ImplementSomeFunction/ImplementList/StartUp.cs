namespace CustomList
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CustomList list = new CustomList();

            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);
            list.Add(7);
            list.Add(8);
            list.Add(9);
            list.RemoveAt(2);
            list.RemoveAt(2);
            list.RemoveAt(2);
            list.RemoveAt(2);
            list.RemoveAt(2);
            list.RemoveAt(0);
            list.RemoveAt(0);
            list.InsertAt(1, 111);
            Console.WriteLine(list.Contains(9));
            Console.WriteLine(list.Contains(99));
            list.Swap(0, 2);
            list.Reverse();
            ;
        }
    }
}