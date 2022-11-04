namespace MilitaryElite.Models.Contracts.Repairs
{
    public interface IRepairable
    {
        public string PartName { get; set; }
        public int HoursWorked { get; set; }
    }
}