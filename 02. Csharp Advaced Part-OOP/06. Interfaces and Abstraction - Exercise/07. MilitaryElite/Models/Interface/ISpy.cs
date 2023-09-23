namespace MilitaryElite.Models.Interface
{
    using System;
    public interface ISpy : ISoldier
    {
        int CodeNumber { get; }
    }
}
