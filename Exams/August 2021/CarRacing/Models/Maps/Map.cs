using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
                return OutputMessages.RaceCannotBeCompleted;

            if (!racerOne.IsAvailable())
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            if (!racerTwo.IsAvailable())
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);


            racerOne.Race();
            racerTwo.Race();

            //Chance of winning
            double firstRacerChance = racerOne.Car.HorsePower * racerOne.DrivingExperience;
            
            if (racerOne.RacingBehavior == "strict") firstRacerChance *= 1.2;
            else if (racerOne.RacingBehavior == "aggressive") firstRacerChance *= 1.1;
            

            double secondRacerChance = racerTwo.Car.HorsePower * racerTwo.DrivingExperience;
            
            if (racerTwo.RacingBehavior == "strict") secondRacerChance *= 1.2;
            else if (racerTwo.RacingBehavior == "aggressive") secondRacerChance *= 1.1;
            
            IRacer winner;
            if (firstRacerChance > secondRacerChance) winner = racerOne;
            else winner = racerTwo;

            return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, winner.Username);
        }
    }
}