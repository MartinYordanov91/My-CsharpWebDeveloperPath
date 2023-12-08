namespace UniversityCompetition.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Models.Contracts;
    using Contracts;

    public class StudentRepository : IRepository<IStudent>, IRepository
    {
        private List<IStudent> models;
        public StudentRepository()
        {
            models = new List<IStudent>();
        }

        public IReadOnlyCollection<IStudent> Models
            => models.AsReadOnly();

        public void AddModel(IStudent model)
        {
            this.models.Add(model);
        }

        public IStudent FindById(int id)
        {
            return this.models.FirstOrDefault(x => x.Id == id);
        }

        public IStudent FindByName(string name)
        {
            string first = name.Split().First().Trim();
            string second = name.Split().Last().Trim();

            return this.models.FirstOrDefault(x => x.FirstName == first && x.LastName == second);
        }
    }
}
