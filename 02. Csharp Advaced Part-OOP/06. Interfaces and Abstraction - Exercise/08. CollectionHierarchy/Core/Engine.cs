
namespace CollectionHierarchy.Core
{
    using CollectionHierarchy.Models;
    using CollectionHierarchy.Models.Interface;
    using Interface;
    public class Engine : IEngine
    {
        private IAddCollection<string> addCollection;
        private IAddRemoveCollection<string> removeCollection;
        private IMyList<string> myList;

        public Engine()
        {
            addCollection = new AddCollection<string>();
            removeCollection = new AddRemoveCollection<string>();
            myList = new MyList<string>();
        }

        public void Run()
        {
            string[] randomWords = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int remulveItemsCnt = int.Parse(Console.ReadLine());



            AddInAnnyColection(addCollection , randomWords);
            AddInAnnyColection(removeCollection, randomWords);
            AddInAnnyColection(myList, randomWords);

            RemulveInAnnyColection(removeCollection , remulveItemsCnt);
            RemulveInAnnyColection(myList, remulveItemsCnt);

        }
        private void AddInAnnyColection(IAddCollection<string> colection ,string[] randomWords) 
        {
            foreach (var words in randomWords)
            {
                Console.Write(colection.Add(words) + " ");
            }
            Console.WriteLine();
        }
        private void RemulveInAnnyColection(IAddRemoveCollection<string> colection , int remulveItemsCnt)
        {
            for (int i = 0; i < remulveItemsCnt; i++)
            {
                Console.Write(colection.Remove() +" ");
            }
            Console.WriteLine();
        }
    }
}
