using MilitaryElite.Models.Contracts;

namespace MilitaryElite.Models.Soldiers
{
    public class Private : Soldier, IPrivate
    {
        public Private(string id, string firstName, string lastName, decimal salary) : base(id, firstName, lastName)
        {
            this.Salary = salary;
        }

        public decimal Salary { get; set; }

        public override string ToString() =>
            $"Name: {this.FirstName} {this.LastName} Id: {this.Id} Salary: {this.Salary:f2}";
    }

}