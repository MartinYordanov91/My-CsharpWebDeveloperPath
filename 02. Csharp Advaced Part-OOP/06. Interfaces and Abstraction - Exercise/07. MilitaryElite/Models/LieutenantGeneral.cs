using MilitaryElite.Models;

namespace MilitaryElite.Models
{
    using Interface;
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary , IReadOnlyCollection<IPrivate> privates)
            : base(id, firstName, lastName, salary)
        {
            Privates = privates;
        }
        public IReadOnlyCollection<IPrivate> Privates { get; private set; }

        public override string ToString()
           => $"{base.ToString()}{Environment.NewLine}Privates:{Environment.NewLine}  {string.Join(Environment.NewLine + "  ", Privates)}".TrimEnd();
    }
}



