namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Person noArgoment = new Person();
            Person noNameArg = new Person(20);
            Person fullArg = new Person("Marto",20);
        }
    }
}