using System.Collections.Generic;
using System.Text;
using MilitaryElite.Models.Contracts;

namespace MilitaryElite.Models.Soldiers.PrivateSoldiers
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary, List<Soldier> privates) : base(id, firstName, lastName, salary)
        {
            this.Privates = privates;
        }
        public List<Soldier> Privates { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}");
            sb.AppendLine($"Privates:");

            foreach (var pr in this.Privates)
                sb.AppendLine(pr.ToString());

            return sb.ToString().Trim();
        }
    }
}