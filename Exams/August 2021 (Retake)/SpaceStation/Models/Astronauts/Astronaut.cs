using System;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags.Contracts;
using SpaceStation.Utilities.Messages;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private double oxygen;
        
        protected Astronaut(string name, double oxygen)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(ExceptionMessages.InvalidAstronautName);

            this.Name = name;
            this.oxygen = oxygen;
        }
        
        public string Name { get; }

        public double Oxygen
        {
            get { return this.oxygen; }
            protected set
            {
                if (value < 0) throw new ArgumentException(ExceptionMessages.InvalidOxygen);
                this.oxygen = value;
            }
        }
        
        public bool CanBreath => this.Oxygen > 0;
        public IBag Bag { get; }
        
        public virtual void Breath()
        {
            if ((this.Oxygen - 10) < 0) this.Oxygen = 0;
            this.Oxygen -= 10;
        }
    }
}