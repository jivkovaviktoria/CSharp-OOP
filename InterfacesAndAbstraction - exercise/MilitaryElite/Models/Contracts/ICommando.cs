using System.Collections.Generic;
using MilitaryElite.Models.Contracts.Missions;

namespace MilitaryElite.Models.Contracts
{
    public interface ICommando
    {
        public List<Mission> Missions { get; set; }
    }
}