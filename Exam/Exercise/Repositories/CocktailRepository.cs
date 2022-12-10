using System.Collections.Generic;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Repositories.Contracts;

namespace ChristmasPastryShop.Repositories
{
    public class CocktailRepository : IRepository<ICocktail>
    {
        private readonly List<ICocktail> models = new List<ICocktail>();
        public IReadOnlyCollection<ICocktail> Models => this.models.AsReadOnly();
        public void AddModel(ICocktail model) => this.models.Add(model);
    }
}