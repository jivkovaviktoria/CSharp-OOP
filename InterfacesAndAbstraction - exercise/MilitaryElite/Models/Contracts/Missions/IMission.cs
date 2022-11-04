namespace MilitaryElite.Models.Contracts.Missions
{
    public interface IMission
    {
        public string CodeName { get; set; }
        public string State { get; set; }
    }
}