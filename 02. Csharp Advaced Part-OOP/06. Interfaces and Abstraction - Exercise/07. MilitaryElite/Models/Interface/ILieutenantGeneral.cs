namespace MilitaryElite.Models.Interface
{
    public interface ILieutenantGeneral : IPrivate
    {
        IReadOnlyCollection<IPrivate> Privates { get;}
    }
}
