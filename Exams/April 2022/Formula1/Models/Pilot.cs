using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public class Pilot : IPilot
    {
        private IFormulaOneCar car;
        public Pilot(string fullName)
        {
            if (string.IsNullOrEmpty(fullName) || fullName.Length < 5) throw new ArgumentException(string.Format(ExceptionMessages.InvalidPilot, fullName));
            this.FullName = fullName;
        }

        public string FullName { get; }


        public IFormulaOneCar Car
        {
            get { return this.car; }
            private set
            {
                if (value == null)
                    throw new NullReferenceException(ExceptionMessages.InvalidCarForPilot);

                this.car = value;
            }
        }

        public int NumberOfWins { get; private set; }

        public bool CanRace { get; private set; }

        public void AddCar(IFormulaOneCar car)
        {
            this.Car = car;
            this.CanRace = true;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }

        public override string ToString() => $"Pilot {this.FullName} has {this.NumberOfWins} wins.";
    }
    
}
