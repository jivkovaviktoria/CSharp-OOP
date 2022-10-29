namespace PlanetWars.Models.Planets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using PlanetWars.Models.MilitaryUnits;
    using PlanetWars.Models.MilitaryUnits.Contracts;
    using PlanetWars.Models.Planets.Contracts;
    using PlanetWars.Models.Weapons;
    using PlanetWars.Models.Weapons.Contracts;
    using PlanetWars.Repositories;
    using PlanetWars.Utilities.Messages;

    public class Planet : IPlanet
    {
        private UnitRepository units = new UnitRepository();
        private WeaponRepository weapons = new WeaponRepository();

        public Planet(string name, double budget)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(ExceptionMessages.InvalidPlanetName);
            if (budget < 0) throw new ArgumentException(ExceptionMessages.InvalidBudgetAmount);

            this.Name = name;
            this.Budget = budget;
        }
        
        public string Name { get; }
        public double Budget { get; private set; }
        public double MilitaryPower => this.CalculateMilitaryPower();

        public IReadOnlyCollection<IMilitaryUnit> Army => this.units.Models;
        public IReadOnlyCollection<IWeapon> Weapons => this.weapons.Models;

        public void AddUnit(IMilitaryUnit unit)
        {
            this.units.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            this.weapons.AddItem(weapon);
        }

        public void TrainArmy()
        {
            foreach (var unit in this.Army) unit.IncreaseEndurance();
        }

        public void Spend(double amount)
        {
            if (amount > this.Budget) throw new InvalidOperationException(ExceptionMessages.UnsufficientBudget);
            this.Budget -= amount;
        }

        public void Profit(double amount)
        {
            this.Budget += amount; // Think about negative amount
        }

        public string PlanetInfo()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Planet: {this.Name}");
            sb.AppendLine($"--Budget: {this.Budget} billion QUID");
            
            sb.Append("--Forces: ");
            if (this.Army.Count == 0) sb.AppendLine("No units");
            else sb.AppendLine(string.Join(", ", this.Army.Select(x => x.GetType().Name)));

            sb.Append("--Combat equipment: ");
            if (this.Weapons.Count == 0) sb.AppendLine("No weapons");
            else sb.AppendLine(string.Join(", ", this.Weapons.Select(x => x.GetType().Name)));

            sb.Append($"--Military Power: {this.MilitaryPower}");

            return sb.ToString();
        }

        private double CalculateMilitaryPower()
        {
            double totalAmount = this.Army.Sum(x => x.EnduranceLevel) + this.Weapons.Sum(x => x.DestructionLevel);

            var anonymousImpactUnit = this.units.FindByName(nameof(AnonymousImpactUnit));
            if (anonymousImpactUnit != null) totalAmount *= 1.3;

            var nuclearWeapon = this.weapons.FindByName(nameof(NuclearWeapon));
            if (nuclearWeapon != null) totalAmount *= 1.45;

            return Math.Round(totalAmount, 3);
        }
    }
}