using System.Collections.Generic;
using Easter.Models.Bunnies.Contracts;
using Easter.Repositories.Contracts;

namespace Easter.Repositories
{
    public class BunnyRepository : IRepository<IBunny>
    {
        private readonly List<IBunny> models = new List<IBunny>();
        public IReadOnlyCollection<IBunny> Models => this.models.AsReadOnly();

        public void Add(IBunny model) => this.models.Add(model);

        public bool Remove(IBunny model) => this.models.Remove(model);

        public IBunny FindByName(string name) => this.models.Find(x => x.Name == name);
    }
}