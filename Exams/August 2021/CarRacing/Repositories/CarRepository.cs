using System;
using System.Collections.Generic;
using CarRacing.IO.Contracts;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        private readonly List<ICar> models = new List<ICar>();
        public IReadOnlyCollection<ICar> Models => this.models.AsReadOnly();
        
        public void Add(ICar model)
        {
            if (model == null) throw new ArgumentException(ExceptionMessages.InvalidAddCarRepository);
            this.models.Add(model);
        }

        public bool Remove(ICar model) => this.models.Remove(model);

        public ICar FindBy(string property) => this.models.Find(x => x.VIN == property);
    }
}