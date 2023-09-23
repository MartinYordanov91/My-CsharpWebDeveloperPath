namespace CollectionHierarchy.Models
{
    using Interface;
    public class AddCollection<T> : IAddCollection<T>
    {
        private readonly ICollection<T> collection;

        public AddCollection()
        {
           collection = new List<T>();
        }

        public int Add(T item)
        {
            collection.Add(item);
            return collection.Count -1;
        }
    }
}
