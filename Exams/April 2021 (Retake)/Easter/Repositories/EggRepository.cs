using System.Collections.Generic;
using Easter.Models.Eggs.Contracts;
using Easter.Repositories.Contracts;

namespace Easter.Repositories
{
    public class EggRepository : IRepository<IEgg>
    {
        private readonly List<IEgg> models = new List<IEgg>();
        public IReadOnlyCollection<IEgg> Models => this.models.AsReadOnly();

        public void Add(IEgg model) => this.models.Add(model);

        public bool Remove(IEgg model) => this.models.Remove(model);

        public IEgg FindByName(string name) => this.models.Find(x => x.Name == name);
    }
}