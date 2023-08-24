namespace GenericCountMethodDoubles
{
    public class StartUp
    {
        public static void Main()
        {
           Box<double> box = new Box<double>();
            int num = int.Parse(Console.ReadLine());

            for (int i = 0; i < num; i++)
            {
                double number = double.Parse(Console.ReadLine());
                box.Add(number);
            }

            double item = double.Parse(Console.ReadLine());
            Console.WriteLine(box.Count(item));

        }
      
    }
}