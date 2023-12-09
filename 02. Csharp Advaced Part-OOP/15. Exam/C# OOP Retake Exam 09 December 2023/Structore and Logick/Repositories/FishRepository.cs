namespace NauticalCatchChallenge.Repositories
{
    using Contracts;
    using NauticalCatchChallenge.Models.Contracts;
    using System.Collections.Generic;

    public class FishRepository : IRepository<IFish>
    {
        private List<IFish> models;
        public FishRepository()
        {
            models = new List<IFish>();
        }

        public IReadOnlyCollection<IFish> Models
            => models.AsReadOnly();

        public void AddModel(IFish model)
        {
            models.Add(model);
        }

        public IFish GetModel(string name)
        {
            return models.FirstOrDefault(x => x.Name == name);
        }
    }
}
