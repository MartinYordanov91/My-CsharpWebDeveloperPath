namespace ExplicitInterfaces.Models.Interface
{
    public interface IResident
    {
        string Name { get; }
        string Country { get; }
        string GetName();
    }
}

