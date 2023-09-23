
namespace MilitaryElite.Models.Interface
{
    using MilitaryElite.Enums;
    public interface IMissions
    {
        string CodeName { get; }
        State State { get; }

        void CompleteMission();
    }
}
