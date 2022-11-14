namespace Heroes.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Heroes.Models.Contracts;
    using Heroes.Repositories.Contracts;

    public class HeroRepository : IRepository<IHero>
    {
        private List<IHero> models = new List<IHero>();
        public IReadOnlyCollection<IHero> Models => this.models.AsReadOnly();

        public void Add(IHero model) => this.models.Add(model);

        public bool Remove(IHero model) => this.models.Remove(model);

        public IHero FindByName(string name) => this.models.FirstOrDefault(x => x.Name == name);
    }
}