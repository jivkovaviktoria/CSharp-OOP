using System;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;

namespace AquaShop.Models.Fish
{
    public abstract class Fish : IFish
    {
        protected Fish(string name, string species, int size, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(ExceptionMessages.InvalidFishName);
            if (string.IsNullOrWhiteSpace(species)) throw new ArgumentException(ExceptionMessages.InvalidFishSpecies);
            if (price <= 0) throw new ArgumentException(ExceptionMessages.InvalidFishPrice);

            this.Name = name;
            this.Species = species;
            this.Size = size;
            this.Price = price;
        }
        public string Name { get; }
        public string Species { get; }
        public int Size { get; protected set; }
        public decimal Price { get; }

        public abstract void Eat();
    }
}