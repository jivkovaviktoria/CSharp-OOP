using System.Collections.Generic;
using System.Text;
using MilitaryElite.Models.Contracts;
using MilitaryElite.Models.Contracts.Repairs;

namespace MilitaryElite.Models.Soldiers.PrivateSoldiers.SpecialisedSoldiers
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(string id, string firstName, string lastName, decimal salary, string corps, List<Repair> repairs) : base(id, firstName, lastName, salary, corps)
        {
            this.Repairs = repairs;
        }

        public List<Repair> Repairs { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}");
            sb.AppendLine($"Corps: {this.Corps}");
            sb.AppendLine("Repairs:");

            foreach (var rp in this.Repairs)
                sb.AppendLine(rp.ToString());

            return sb.ToString().Trim();
        }
    }
}