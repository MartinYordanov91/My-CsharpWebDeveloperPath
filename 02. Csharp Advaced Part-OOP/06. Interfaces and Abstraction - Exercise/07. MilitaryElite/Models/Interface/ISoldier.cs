namespace MilitaryElite.Models.Interface
{
    using System;
    public interface ISoldier
    {
        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
    }
}
