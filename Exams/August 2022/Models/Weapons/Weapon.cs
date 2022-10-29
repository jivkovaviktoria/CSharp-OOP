namespace PlanetWars.Models.Weapons
{
    using System;
    using PlanetWars.Models.Weapons.Contracts;
    using PlanetWars.Utilities.Messages;

    public abstract class Weapon : IWeapon
    {
        protected Weapon(double price, int destructionLevel)
        {
            if (destructionLevel < 1) throw new ArgumentException(ExceptionMessages.TooLowDestructionLevel);
            if (destructionLevel > 10) throw new ArgumentException(ExceptionMessages.TooHighDestructionLevel);
            
            this.Price = price;
            this.DestructionLevel = destructionLevel;
        }

        public double Price { get; }
        public int DestructionLevel { get; }
    }
}