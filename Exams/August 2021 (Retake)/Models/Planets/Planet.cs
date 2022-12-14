using System;
using System.Collections.Generic;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Utilities.Messages;

namespace SpaceStation.Models.Planets
{
    public class Planet : IPlanet
    {
        private List<string> items;
        public Planet(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(ExceptionMessages.InvalidPlanetName);

            this.Name = name;
            this.items = new List<string>();
        }

        public ICollection<string> Items => this.items;
        public string Name { get; }
    }
}