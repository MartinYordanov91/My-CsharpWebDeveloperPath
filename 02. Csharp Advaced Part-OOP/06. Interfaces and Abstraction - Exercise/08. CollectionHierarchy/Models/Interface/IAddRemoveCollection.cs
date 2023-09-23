namespace CollectionHierarchy.Models.Interface
{
    public interface IAddRemoveCollection<T> : IAddCollection<T>
    {
        T Remove();
    }
}
