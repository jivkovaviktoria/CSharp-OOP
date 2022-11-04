using System;
using System.Collections.Generic;
using System.Text;
using Gym.Models.Athletes.Contracts;
using Gym.Utilities.Messages;

namespace Gym.Models.Athletes
{
    public abstract class Athlete : IAthlete
    {
        protected Athlete(string fullName, string motivation, int numberOfMedals, int stamina)
        {
            if (string.IsNullOrEmpty(fullName)) throw new ArgumentException(ExceptionMessages.InvalidAthleteName);
            if (string.IsNullOrEmpty(motivation)) throw new ArgumentException(ExceptionMessages.InvalidAthleteMotivation);
            if (numberOfMedals < 0) throw new ArgumentException(ExceptionMessages.InvalidAthleteMedals);

            this.FullName = fullName;
            this.Motivation = motivation;
            this.NumberOfMedals = numberOfMedals;
            this.Stamina = stamina;
        }

        public string FullName { get; }
        public string Motivation { get; }
        public int Stamina { get; protected set; }
        public int NumberOfMedals { get; }

        public abstract void Exercise();
    }
}
