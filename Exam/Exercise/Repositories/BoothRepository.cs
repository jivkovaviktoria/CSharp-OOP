using System.Collections.Generic;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Repositories.Contracts;

namespace ChristmasPastryShop.Repositories
{
    public class BoothRepository : IRepository<IBooth>
    {
        private readonly List<IBooth> models = new List<IBooth>();
        public IReadOnlyCollection<IBooth> Models => this.models.AsReadOnly();
        public void AddModel(IBooth model) => this.models.Add(model);
    }
}