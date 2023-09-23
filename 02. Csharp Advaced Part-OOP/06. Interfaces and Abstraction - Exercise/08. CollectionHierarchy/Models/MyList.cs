
namespace CollectionHierarchy.Models
{
    using Interface;
    public class MyList<T> : IMyList<T>
    {
        private readonly IList<T> colection;

        public MyList()
        {
            this.colection = new List<T>();
        }
        public int Used
            => colection.Count;

        public int Add(T item)
        {
            colection.Insert(0, item);
            return 0;
        }

        public T Remove()
        {
           T item = colection.FirstOrDefault();

            if(item!= null)
            {
                colection.Remove(item);
            }
            return item;
        }
    }
}
