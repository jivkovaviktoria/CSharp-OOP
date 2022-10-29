namespace PlanetWars.Models.MilitaryUnits
{
    using System;
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Utilities.Messages;

    public class MilitaryUnit : IMilitaryUnit
    {
        public MilitaryUnit(double cost)
        {
            this.Cost = cost;
        }
        
        public double Cost { get; }
        public int EnduranceLevel { get; private set; } = 1;
        
        public void IncreaseEndurance()
        {
            if (this.EnduranceLevel == 20) throw new ArgumentException(ExceptionMessages.EnduranceLevelExceeded);
            this.EnduranceLevel++;
        }
    }
}