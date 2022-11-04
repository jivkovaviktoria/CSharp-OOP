using System;
using ExplicitInterfaces.Models;
using ExplicitInterfaces.Models.Contracts;

namespace ExplicitInterfaces
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            while (input != "End")
            {
                var tokens = input.Split();
                string name = tokens[0], country = tokens[1], age = tokens[2];

                IPerson citizenPerson = new Citizen(name, country, int.Parse(age));
                IResident residentPerson = new Citizen(name, country, int.Parse(age));

                citizenPerson.GetName();
                residentPerson.GetName();
                
                input = Console.ReadLine();
            }
        }
    }
}