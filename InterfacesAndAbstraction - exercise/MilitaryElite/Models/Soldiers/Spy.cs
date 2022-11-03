using System.Text;
using MilitaryElite.Models.Contracts;

namespace MilitaryElite.Models.Soldiers
{
    public class Spy : Soldier, ISpy
    {
        public Spy(string id, string firstName, string lastName, int codeNumber) : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }

        public int CodeNumber { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {this.FirstName} {this.LastName} Id: {this.Id}");
            sb.Append($"Code Number: {this.CodeNumber}");

            return sb.ToString().Trim();
        }
    }
}