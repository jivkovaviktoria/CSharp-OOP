using System;
using System.Threading.Channels;
using ExplicitInterfaces.Models.Contracts;

namespace ExplicitInterfaces.Models
{
    public class Citizen : ICitizen
    {
        public Citizen(string name, string country, int age)
        {
            Name = name;
            Country = country;
            Age = age;
        }

        public string Name { get; set; }
        public string Country { get; set; }
        public int Age { get; set; }

        void IPerson.GetName() => Console.WriteLine(this.Name);
        void IResident.GetName() => Console.WriteLine($"Mr/Ms/Mrs {this.Name}");
    }
}