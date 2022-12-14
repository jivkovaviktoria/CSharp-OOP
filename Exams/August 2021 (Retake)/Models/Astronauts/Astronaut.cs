using System;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using SpaceStation.Models.Bags.Contracts;
using SpaceStation.Utilities.Messages;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private double oxygen;
        
        protected Astronaut(string name, double oxygen)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(ExceptionMessages.InvalidAstronautName);

            this.Name = name;
            this.oxygen = oxygen;
            this.Bag = new Backpack();
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
            else this.Oxygen -= 10;
        }
    }
}