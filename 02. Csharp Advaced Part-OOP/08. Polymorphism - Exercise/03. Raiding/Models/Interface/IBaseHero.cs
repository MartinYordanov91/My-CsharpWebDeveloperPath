namespace Raiding.Models.Interface
{
    public interface IBaseHero
    {
        string Name { get; }
        int Power { get; }
        string CastAbility();
    }
}
