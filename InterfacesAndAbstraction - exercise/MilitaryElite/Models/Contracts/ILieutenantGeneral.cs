using System.Collections.Generic;
using MilitaryElite.Models.Soldiers;

namespace MilitaryElite.Models.Contracts
{
    public interface ILieutenantGeneral
    {
        public List<Soldier> Privates { get; set; }
    }
}