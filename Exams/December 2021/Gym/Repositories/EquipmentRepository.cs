using Gym.Models.Equipment;
using Gym.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Repositories
{
    public abstract class EquipmentRepository<IEquipment> : IRepository<IEquipment>
    {
        private List<IEquipment> items = new List<IEquipment>();
        public IReadOnlyCollection<IEquipment> Models => this.items.AsReadOnly();

        public void Add(IEquipment model)
        {
            this.items.Add(model);
        }

        public IEquipment FindByType(string type)
        {
            return this.items.FirstOrDefault(x => x.GetType().Name == type);
        }

        public bool Remove(IEquipment model)
        {
            if(this.items.Contains(model))
            {
                this.items.Remove(model);
                return true;
            }

            return false;
        }
    }
}
