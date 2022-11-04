using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public class Race : IRace
    {
        private List<IPilot> pilots;
        public Race(string raceName, int numberOfLaps)
        {
            if (string.IsNullOrWhiteSpace(raceName) || raceName.Length < 5)
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidRaceName, raceName));
            if (numberOfLaps < 1) throw new ArgumentException(string.Format(ExceptionMessages.InvalidLapNumbers, numberOfLaps));

            this.RaceName = raceName;
            this.NumberOfLaps = numberOfLaps;
            this.pilots = new List<IPilot>();
            this.TookPlace = false;
        }
        public string RaceName { get; }

        public int NumberOfLaps { get; }

        public bool TookPlace { get; set; }

        public ICollection<IPilot> Pilots { get { return this.pilots.AsReadOnly(); } }



        public void AddPilot(IPilot pilot)
        {
            this.pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            var tookPlace = this.TookPlace == true ? "Yes" : "No";

            var sb = new StringBuilder();
            sb.AppendLine($"The {this.RaceName} race has:");
            sb.AppendLine($"Participants: {this.pilots.Count}");
            sb.AppendLine($"Number of laps: {this.NumberOfLaps}");
            sb.Append($"Took place: {tookPlace}");

            return sb.ToString().Trim();
        }
    }
}
