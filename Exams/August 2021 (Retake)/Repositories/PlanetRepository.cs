using System.Collections.Generic;
using System.Linq;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories.Contracts;

namespace SpaceStation.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly List<IPlanet> models = new List<IPlanet>();
        public IReadOnlyCollection<IPlanet> Models => this.models.AsReadOnly();

        public void Add(IPlanet model) => this.models.Add(model);

        public bool Remove(IPlanet model) => this.models.Remove(model);

        public IPlanet FindByName(string name) => this.models.FirstOrDefault(x => x.Name == name);
    }
}