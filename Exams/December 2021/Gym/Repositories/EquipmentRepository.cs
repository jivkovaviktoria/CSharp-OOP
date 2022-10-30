using Gym.Models.Equipment;
using Gym.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Repositories
{
    public class EquipmentRepository : IRepository
    {
        private List<Equipment> items = new List<Equipment>();
        public IReadOnlyCollection<Equipment> Models => this.items.AsReadOnly();

        public void Add(Equipment model)
        {
            this.items.Add(model);
        }

        public Equipment FindByType(string type)
        {
            return this.items.FirstOrDefault(x => x.GetType().Name == type);
        }

        public bool Remove(Equipment model)
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
