using System;

namespace MilitaryElite.Models.Contracts.Missions
{
    public class Mission : IMission
    {
        public Mission(string codeName, string state)
        {
            if (state == "inProgress" || state == "Finished") State = state;
            else throw new ArgumentException();

            CodeName = codeName;
        }

        public string CodeName { get; set; }
        public string State { get; set; }

        public override string ToString() => $"Code Name: {this.CodeName} State: {this.State}";
    }
}