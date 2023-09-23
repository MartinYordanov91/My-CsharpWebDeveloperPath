namespace MilitaryElite.Models.Interface
{
    using MilitaryElite.Enums;

    public interface ISpecialisedSoldier : IPrivate
    {
        Corps Crops { get; }
    }
}
