using System.Collections.Generic;
using System.Text;
using MilitaryElite.Models.Contracts;
using MilitaryElite.Models.Contracts.Missions;

namespace MilitaryElite.Models.Soldiers.PrivateSoldiers.SpecialisedSoldiers
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(string id, string firstName, string lastName, decimal salary, string corps, string[] missionsData) : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = new List<Mission>();
            
            for (int i = 0; i < missionsData.Length; i += 2)
            {
                var codeName = missionsData[i];
                var state = missionsData[i + 1];

                if (state == "inProgress" || state == "Finished")
                    this.Missions.Add(new Mission(codeName, state));
            }
        }

        public List<Mission> Missions { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}");
            sb.AppendLine($"Corps: {this.Corps}");
            sb.AppendLine("Missions:");

            foreach (var ms in this.Missions)
                sb.AppendLine(ms.ToString());

            return sb.ToString().Trim();
        }
    }
}