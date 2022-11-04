namespace Gym.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Gym.Models.Equipment.Contracts;
    using Gym.Repositories.Contracts;

    public class EquipmentRepository : IRepository<IEquipment>
    {
        private readonly List<IEquipment> models = new List<IEquipment>();
        public IReadOnlyCollection<IEquipment> Models => this.models.AsReadOnly();

        public void Add(IEquipment model)
        {
            this.models.Add(model);
        }

        public IEquipment FindByType(string type)
        {
            return this.models.FirstOrDefault(x => x.GetType().Name == type);
        }

        public bool Remove(IEquipment model)
        {
            return this.models.Remove(model);
        }
    }
}
