using System;
using System.Collections.Generic;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Utilities.Messages;

namespace Easter.Models.Bunnies
{
    public abstract class Bunny : IBunny
    {
        private int energy;
        
        protected Bunny(string name, int energy)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(ExceptionMessages.InvalidBunnyName);
            this.energy = energy;
            this.Dyes = new List<IDye>();
        }
        
        public string Name { get; }

        public int Energy
        {
            get { return this.energy; }
            protected set
            {
                if (value < 0) this.energy = 0;
                else this.energy = value;
            }
        }
        public ICollection<IDye> Dyes { get; }

        public virtual void Work() => this.Energy -= 10;

        public void AddDye(IDye dye) => this.Dyes.Add(dye);
    }
}