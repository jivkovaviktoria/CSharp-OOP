using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;

namespace CarRacing.Models.Racers
{
    public class StreetRacer : Racer
    {
        public StreetRacer(string username, ICar car) : base(username, "aggressive", 10, car)
        {
        }

        public override void Race()
        {
            base.Race();
            this.DrivingExperience += 5;
        }
    }
}