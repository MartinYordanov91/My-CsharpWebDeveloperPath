namespace MilitaryElite.Models.Interface
{
    public interface ICommando : ISpecialisedSoldier
    {
        IReadOnlyCollection<IMissions> Missions { get; }
    }
}
