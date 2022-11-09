﻿using System.Collections.Generic;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;

namespace AquaShop.Repositories
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private List<IDecoration> models = new List<IDecoration>();
        public IReadOnlyCollection<IDecoration> Models => this.models.AsReadOnly();

        public void Add(IDecoration model) => this.models.Add(model);

        public bool Remove(IDecoration model) => this.models.Remove(model);

        public IDecoration FindByType(string type) => this.models.Find(x => x.GetType().Name == type);
    }
}