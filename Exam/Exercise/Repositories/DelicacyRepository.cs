using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories.Contracts;

namespace ChristmasPastryShop.Repositories
{
    public class DelicacyRepository : IRepository<IDelicacy>
    {
        private readonly List<IDelicacy> models = new List<IDelicacy>();
        public IReadOnlyCollection<IDelicacy> Models => this.models.AsReadOnly();

        public void AddModel(IDelicacy model) => this.models.Add(model);
    }
}