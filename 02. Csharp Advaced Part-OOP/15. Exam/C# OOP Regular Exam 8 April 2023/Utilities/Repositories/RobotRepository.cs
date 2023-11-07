using RobotService.Models.Contracts;
using RobotService.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace RobotService.Repositories
{
    public class RobotRepository : IRepository<IRobot>
    {
        private readonly List<IRobot> repositoryes;
        public RobotRepository()
        {
            repositoryes = new List<IRobot>();
        }

        public void AddNew(IRobot model)
            => repositoryes.Add(model);

        public IRobot FindByStandard(int interfaceStandard)
            => repositoryes.FirstOrDefault(x => x.InterfaceStandards.Any(x=>x == interfaceStandard));

        public IReadOnlyCollection<IRobot> Models()
            => repositoryes.AsReadOnly();

        public bool RemoveByName(string typeName)
            => repositoryes.Remove(repositoryes.FirstOrDefault(x => x.Model == typeName));
    }
}
