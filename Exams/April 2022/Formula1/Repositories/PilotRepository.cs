using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Repositories
{
    public class PilotRepository : IRepository<IPilot>
    {
        private List<IPilot> models = new List<IPilot>();
        public IReadOnlyCollection<IPilot> Models => this.models.AsReadOnly();

        public void Add(IPilot model)
        {
            this.models.Add(model);
        }

        public IPilot FindByName(string name)
        {
            return this.models.Find(x => x.FullName == name);
        }

        public bool Remove(IPilot model)
        {
            return this.models.Remove(model);
        }
    }
}
