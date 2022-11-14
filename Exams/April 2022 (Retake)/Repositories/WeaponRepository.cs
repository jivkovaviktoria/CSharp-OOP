namespace Heroes.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Heroes.Models.Contracts;
    using Heroes.Repositories.Contracts;

    public class WeaponRepository : IRepository<IWeapon>
    {
        private List<IWeapon> models = new List<IWeapon>();
        public IReadOnlyCollection<IWeapon> Models => this.models.AsReadOnly();

        public void Add(IWeapon model) => this.models.Add(model);

        public bool Remove(IWeapon model) => this.models.Remove(model);

        public IWeapon FindByName(string name) => this.models.FirstOrDefault(x => x.Name == name);
    }
}