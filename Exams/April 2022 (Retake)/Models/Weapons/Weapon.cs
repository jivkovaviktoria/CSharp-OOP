namespace Heroes.Models.Weapons
{
    using System;
    using Contracts;

    public abstract class Weapon : IWeapon
    {
        protected Weapon(string name, int durability)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Weapon type cannot be null or empty.");
            if (durability < 0) throw new ArgumentException("Durability cannot be below 0.");

            this.Name = name;
            this.Durability = durability;
        } 
        public string Name { get; }
        public int Durability { get; }
        
        public abstract int DoDamage();
    }
}