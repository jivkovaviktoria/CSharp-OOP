namespace PlanetWars.Repositories
{
    using System.Collections.Generic;
    using PlanetWars.Repositories.Contracts;

    public abstract class BaseRepository<T> : IRepository<T>
    {
        private List<T> items = new List<T>();

        public IReadOnlyCollection<T> Models => this.items.AsReadOnly();
        
        public void AddItem(T model)
        {
            this.items.Add(model);
        }

        public T FindByName(string name)
        {
            return this.items.Find(x => this.GetName(x) == name);
        }

        public bool RemoveItem(string name)
        {
            var item = this.FindByName(name);
            if (item == null) return false;
            
            this.items.Remove(item);
            return true;
        }

        protected virtual string GetName(T item) => item.GetType().Name;
    }
}