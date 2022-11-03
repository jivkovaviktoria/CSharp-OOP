namespace MilitaryElite.Models.Contracts.Repairs
{
    public class Repair : IRepairable
    {
        public Repair(string partName, int hoursWorked)
        {
            PartName = partName;
            HoursWorked = hoursWorked;
        }

        public string PartName { get; set; }
        public int HoursWorked { get; set; }

        public override string ToString() => $"Part Name: {this.PartName} Hours Worked: {this.HoursWorked}";
    }
}