namespace PlanetWars.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using PlanetWars.Core.Contracts;
    using PlanetWars.Models.MilitaryUnits;
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Models.Planets;
    using PlanetWars.Models.Planets.Contracts;
    using PlanetWars.Models.Weapons;
    using PlanetWars.Models.Weapons.Contracts;
    using PlanetWars.Repositories;
    using PlanetWars.Utilities.Messages;

    public class Controller : IController
    {
        private readonly PlanetRepository planets = new PlanetRepository();
        
        public string CreatePlanet(string name, double budget)
        {
            var existingPlanet = this.planets.FindByName(name);
            if (existingPlanet != null) return string.Format(OutputMessages.ExistingPlanet, name);

            var planet = new Planet(name, budget);
            this.planets.AddItem(planet);
            return string.Format(OutputMessages.NewPlanet, name);
        }

        public string AddUnit(string unitTypeName, string planetName)
        {
            var existingPlanet = this.planets.FindByName(planetName);
            if (existingPlanet == null) throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));

            IMilitaryUnit unit;
            if (unitTypeName == nameof(AnonymousImpactUnit)) unit = new AnonymousImpactUnit();
            else if (unitTypeName == nameof(SpaceForces)) unit = new SpaceForces();
            else if (unitTypeName == nameof(StormTroopers)) unit = new StormTroopers();
            else throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, unitTypeName));

            var existingUnit = existingPlanet.Army.FirstOrDefault(x => x.GetType().Name == unitTypeName);
            if (existingUnit != null) throw new InvalidOperationException(string.Format(ExceptionMessages.UnitAlreadyAdded, unitTypeName, planetName));
            
            existingPlanet.Spend(unit.Cost);
            existingPlanet.AddUnit(unit);
            return string.Format(OutputMessages.UnitAdded, unitTypeName, planetName);
        }

        public string AddWeapon(string planetName, string weaponTypeName, int destructionLevel)
        {
            var existingPlanet = this.planets.FindByName(planetName);
            if (existingPlanet == null) throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));

            IWeapon weapon;
            if (weaponTypeName == nameof(BioChemicalWeapon)) weapon = new BioChemicalWeapon(destructionLevel);
            else if (weaponTypeName == nameof(NuclearWeapon)) weapon = new NuclearWeapon(destructionLevel);
            else if (weaponTypeName == nameof(SpaceMissiles)) weapon = new SpaceMissiles(destructionLevel);
            else throw new InvalidOperationException(string.Format(ExceptionMessages.ItemNotAvailable, weaponTypeName));

            var existingWeapon = existingPlanet.Weapons.FirstOrDefault(x => x.GetType().Name == weaponTypeName);
            if (existingWeapon != null) throw new InvalidOperationException(string.Format(ExceptionMessages.WeaponAlreadyAdded, weaponTypeName, planetName));
            
            existingPlanet.Spend(weapon.Price);
            existingPlanet.AddWeapon(weapon);
            return string.Format(OutputMessages.WeaponAdded, planetName, weaponTypeName);
        }

        public string SpecializeForces(string planetName)
        {
            var existingPlanet = this.planets.FindByName(planetName);
            if (existingPlanet == null) throw new InvalidOperationException(string.Format(ExceptionMessages.UnexistingPlanet, planetName));

            if (existingPlanet.Army.Count == 0) throw new InvalidOperationException(ExceptionMessages.NoUnitsFound);
            
            existingPlanet.TrainArmy();
            existingPlanet.Spend(1.25);

            return string.Format(OutputMessages.ForcesUpgraded, planetName);
        }

        public string SpaceCombat(string planetOne, string planetTwo)
        {
            var firstPlanet = this.planets.FindByName(planetOne);
            var secondPlanet = this.planets.FindByName(planetTwo);

            IPlanet winner, loser;
            if (firstPlanet.MilitaryPower == secondPlanet.MilitaryPower)
            {
                bool firstOwnsNuclear = firstPlanet.Weapons.Any(x => x.GetType().Name == nameof(NuclearWeapon));
                bool secondOwnsNuclear = secondPlanet.Weapons.Any(x => x.GetType().Name == nameof(NuclearWeapon));

                if (firstOwnsNuclear == secondOwnsNuclear)
                {
                    firstPlanet.Spend(firstPlanet.Budget / 2);
                    secondPlanet.Spend(secondPlanet.Budget / 2);
                    return OutputMessages.NoWinner;
                }

                if (firstOwnsNuclear)
                {
                    winner = firstPlanet;
                    loser = secondPlanet;
                }
                else
                {
                    winner = secondPlanet;
                    loser = firstPlanet;
                }
            }
            else if (firstPlanet.MilitaryPower > secondPlanet.MilitaryPower)
            {
                winner = firstPlanet;
                loser = secondPlanet;
            }
            else
            {
                winner = secondPlanet;
                loser = firstPlanet;
            }
            
            winner.Spend(winner.Budget / 2);
            winner.Profit(loser.Budget / 2);
            winner.Profit(loser.Army.Sum(x => x.Cost));
            winner.Profit(loser.Weapons.Sum(x => x.Price));

            this.planets.RemoveItem(loser.Name);
            return string.Format(OutputMessages.WinnigTheWar, winner.Name, loser.Name);
        }

        public string ForcesReport()
        {
            var sb = new StringBuilder();
            sb.AppendLine("***UNIVERSE PLANET MILITARY REPORT***");
            sb.AppendJoin(Environment.NewLine, this.planets.Models.OrderByDescending(x => x.MilitaryPower).ThenBy(x => x.Name).Select(x => x.PlanetInfo()));
            return sb.ToString();
        }
    }
}