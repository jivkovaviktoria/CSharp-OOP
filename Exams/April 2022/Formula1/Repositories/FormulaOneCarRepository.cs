using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Repositories
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private List<IFormulaOneCar> models = new List<IFormulaOneCar>();
        public IReadOnlyCollection<IFormulaOneCar> Models => this.models.AsReadOnly();

        public void Add(IFormulaOneCar model)
        {
            this.models.Add(model);
        }

        public IFormulaOneCar FindByName(string name)
        {
            return this.models.Find(x => x.Model == name);
        }

        public bool Remove(IFormulaOneCar model)
        {
            return this.models.Remove(model);
        }
    }
}
