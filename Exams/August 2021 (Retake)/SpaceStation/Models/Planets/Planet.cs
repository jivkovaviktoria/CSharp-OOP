using System;
using System.Collections.Generic;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Utilities.Messages;

namespace SpaceStation.Models.Planets
{
    public class Planet : IPlanet
    {
        public Planet(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(ExceptionMessages.InvalidPlanetName);

            this.Name = name;
            this.Items = new List<string>();
        }
        public ICollection<string> Items { get; }
        public string Name { get; }
    }
}