namespace Gym.Models.Athletes
{
    using System;
    using Gym.Utilities.Messages;

    public class Boxer : Athlete
    {
        private const int InitialStamina = 60;
        
        public Boxer(string fullName, string motivation, int numberOfMedals) : base(fullName, motivation, numberOfMedals, InitialStamina)
        {
        }

        public override void Exercise()
        {
            if (this.Stamina + 15 > 100)
            {
                this.Stamina = 100;
                throw new ArgumentException(ExceptionMessages.InvalidStamina);
            }
            
            this.Stamina += 15;
        }
    }
}
