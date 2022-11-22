using System.Collections.Generic;
using System.Linq;
using SpaceStation.IO.Contracts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;

namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private readonly List<IAstronaut> models = new List<IAstronaut>();
        public IReadOnlyCollection<IAstronaut> Models => this.models.AsReadOnly();

        public void Add(IAstronaut model) => this.models.Add(model);

        public bool Remove(IAstronaut model) => this.models.Remove(model);

        public IAstronaut FindByName(string name) => this.models.FirstOrDefault(x => x.Name == name);
    }
}