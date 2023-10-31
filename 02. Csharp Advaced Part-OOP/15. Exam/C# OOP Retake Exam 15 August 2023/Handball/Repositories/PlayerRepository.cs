using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Handball.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private List<IPlayer> players;
        public PlayerRepository()
        {
            players = new List<IPlayer>();
        }
        public IReadOnlyCollection<IPlayer> Models
            => players.AsReadOnly();
        public void AddModel(IPlayer player)
        {
            players.Add(player);
        }

        public bool ExistsModel(string name)
            => players.Any(x => x.Name == name);

        public IPlayer GetModel(string name)
            => players.FirstOrDefault(x => x.Name == name);

        public bool RemoveModel(string name)
            => players.Remove(players.FirstOrDefault(n => n.Name == name));
    }
}
