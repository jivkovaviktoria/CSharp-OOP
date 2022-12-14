namespace Gym.Models.Athletes
{
    using System;
    using Gym.Utilities.Messages;

    public class Weightlifter : Athlete
    {
        private const int InitialStamina = 50;

        public Weightlifter(string fullName, string motivation, int numberOfMedals) : base(fullName, motivation, numberOfMedals, InitialStamina)
        {
        }

        public override void Exercise()
        {
            if (this.Stamina + 10 > 100)
            {
                this.Stamina = 100;
                throw new ArgumentException(ExceptionMessages.InvalidStamina);
            }

            this.Stamina += 10;
        }
    }
}
