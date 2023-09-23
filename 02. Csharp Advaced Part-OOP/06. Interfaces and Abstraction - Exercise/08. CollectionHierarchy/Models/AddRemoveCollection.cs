namespace CollectionHierarchy.Models
{
    using Interface;
    internal class AddRemoveCollection<T> : IAddRemoveCollection<T>
    {
        private readonly IList<T> collection;

        public AddRemoveCollection()
        {
            collection = new List<T>();
        }

        public int Add(T item)
        {
            collection.Insert(0, item);
            return 0;
        }

        public T Remove()
        {
            T element = collection.LastOrDefault();

            if (element != null)
            {
                collection.Remove(element);
            }

            return element;
        }
    }
}
