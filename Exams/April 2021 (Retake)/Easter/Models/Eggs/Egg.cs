using System;
using Easter.Models.Eggs.Contracts;
using Easter.Utilities.Messages;

namespace Easter.Models.Eggs
{
    public class Egg : IEgg
    {
        private int energyRequired;
        public Egg(string name, int energyRequired)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(ExceptionMessages.InvalidEggName);
            this.energyRequired = energyRequired;
        }
        public string Name { get; }

        public int EnergyRequired
        {
            get { return this.energyRequired; }
            private set
            {
                if (value < 0) this.energyRequired = 0;
                else this.energyRequired = value;
            }
        }

        public void GetColored() => this.EnergyRequired -= 10;

        public bool IsDone() => this.energyRequired == 0;
    }
}