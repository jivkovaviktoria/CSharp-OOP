using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Utilities.Messages;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private AstronautRepository astronauts = new AstronautRepository();
        private PlanetRepository planets = new PlanetRepository();
        private HashSet<string> exploredPlanets = new HashSet<string>();
        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut;
            if (type == nameof(Biologist)) astronaut = new Biologist(astronautName);
            else if (type == nameof(Geodesist)) astronaut = new Geodesist(astronautName);
            else if (type == nameof(Meteorologist)) astronaut = new Meteorologist(astronautName);
            else throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            
            this.astronauts.Add(astronaut);
            return string.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            var planet = new Planet(planetName);
            foreach(var item in items) planet.Items.Add(item);
            
            this.planets.Add(planet);
            return string.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string RetireAstronaut(string astronautName)
        {
            var astronaut = this.astronauts.FindByName(astronautName);

            if (astronaut == null)
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));

            this.astronauts.Remove(astronaut);
            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }

        public string ExplorePlanet(string planetName)
        {
            var mission = new Mission();

            var astronauts = this.astronauts.Models.Where(x => x.Oxygen > 60).ToList();
            if (astronauts.Count < 1) throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            var planet = this.planets.FindByName(planetName);
            mission.Explore(planet, astronauts);
            var dead = astronauts.Count(x => x.CanBreath == false);

            this.exploredPlanets.Add(planet.Name);
            return string.Format(OutputMessages.PlanetExplored, planetName, dead);
        }

        public string Report()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.exploredPlanets.Count()} planets were explored!");
            sb.Append("Astronauts info:");
            
            foreach (var x in this.astronauts.Models)
            {
                sb.AppendLine();
                sb.AppendLine($"Name: {x.Name}");
                sb.AppendLine($"Oxygen: {x.Oxygen}");

                if(x.Bag.Items.Count > 0) sb.Append($"Bag items: {string.Join(", ", x.Bag.Items)}");
                else sb.Append("Bag items: none");
            }

            return sb.ToString().TrimEnd();
        }
    }
}