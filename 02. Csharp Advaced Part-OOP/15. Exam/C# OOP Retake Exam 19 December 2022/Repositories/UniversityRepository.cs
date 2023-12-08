namespace UniversityCompetition.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Models.Contracts;
    using Contracts;

    public class UniversityRepository : IRepository<IUniversity>, IRepository
    {
        private List<IUniversity> models;
        public UniversityRepository()
        {
            models = new List<IUniversity>();
        }
        public IReadOnlyCollection<IUniversity> Models 
            => models.AsReadOnly();

        public void AddModel(IUniversity model)
        {
            this.models.Add(model);
        }

        public IUniversity FindById(int id)
        {
            return this.models.FirstOrDefault(x => x.Id == id);
        }

        public IUniversity FindByName(string name)
        {
            return this.models.FirstOrDefault(x => x.Name == name);
        }
    }
}
