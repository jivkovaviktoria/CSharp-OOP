using System.Collections.Generic;
using MilitaryElite.Models.Contracts.Repairs;
using MilitaryElite.Models.Soldiers;

namespace MilitaryElite.Models.Contracts
{
    public interface IEngineer
    {
        public List<Repair> Repairs { get; set; }
    }
}