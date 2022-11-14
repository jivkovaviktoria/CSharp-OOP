namespace Heroes.Models.Heroes
{
    using System;
    using Contracts;

    public abstract class Hero : IHero
    {
        protected Hero(string name, int health, int armour)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Hero name cannot be null or empty.");
            if (health < 0) throw new ArgumentException("Hero health cannot be below 0.");
            if (armour < 0) throw new ArgumentException("Hero armour cannot be below 0.");

            this.Name = name;
            this.Health = health;
            this.Armour = armour;
        }

        public string Name { get; }
        public int Health { get; private set; }
        public int Armour { get; private set; }
        public IWeapon Weapon { get; private set; }

        public bool IsAlive => this.Health > 0;


        public void TakeDamage(int points)
        {
            this.Armour -= points;
            if (this.Armour < 0)
            {
                this.Health += this.Armour;
                this.Armour = 0;
                
                if (this.Health < 0) this.Health = 0;
            }
        }

        public void AddWeapon(IWeapon weapon)
        {
            if (weapon == null) throw new ArgumentException("Weapon cannot be null.");
            this.Weapon = weapon;
        }
    }
}