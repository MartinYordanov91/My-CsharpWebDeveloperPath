namespace CollectionHierarchy.Models.Interface
{
    internal interface IMyList<T> : IAddRemoveCollection<T>
    {
        int Used { get; }
    }
}
