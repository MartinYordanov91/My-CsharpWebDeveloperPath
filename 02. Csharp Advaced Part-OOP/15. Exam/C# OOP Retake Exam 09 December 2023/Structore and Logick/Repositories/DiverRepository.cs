namespace NauticalCatchChallenge.Repositories
{
    using Contracts;
    using NauticalCatchChallenge.Models.Contracts;
    using System.Collections.Generic;

    public class DiverRepository : IRepository<IDiver>
    {
        private List<IDiver> models;
        public DiverRepository()
        {
            models = new List<IDiver>();
        }
        public IReadOnlyCollection<IDiver> Models 
            => models.AsReadOnly();

        public void AddModel(IDiver model)
        {
            models.Add(model);
        }

        public IDiver GetModel(string name)
        {
            return models.FirstOrDefault(x => x.Name == name);
        }
    }
}
