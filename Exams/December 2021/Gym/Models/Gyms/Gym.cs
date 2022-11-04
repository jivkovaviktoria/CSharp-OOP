using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Gym.Utilities.Messages;
using System.Linq;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private readonly List<IEquipment> equipments = new List<IEquipment>();
        private readonly List<IAthlete> athletes = new List<IAthlete>();

        protected Gym(string name, int capacity)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException(ExceptionMessages.InvalidGymName);

            this.Name = name;
            this.Capacity = capacity;

            this.Equipment = new List<IEquipment>();
            this.Athletes = new List<IAthlete>();
        }
        public string Name { get; }

        public int Capacity { get; }

        public double EquipmentWeight => CalculateEquipmentWeight();

        private double CalculateEquipmentWeight()
        {
            double total = 0;
            foreach (var equipment in this.Equipment)
                total += equipment.Weight;

            return total;
        }

        public ICollection<IEquipment> Equipment => this.equipments;

        public ICollection<IAthlete> Athletes => this.athletes;

        public void AddAthlete(IAthlete athlete)
        {
            if (this.Athletes.Count == this.Capacity)
                throw new InvalidOperationException(ExceptionMessages.NotEnoughSize);

            this.Athletes.Add(athlete);
        }

        public void AddEquipment(IEquipment equipment)
        {
            this.Equipment.Add(equipment);
        }

        public void Exercise()
        {
            foreach (var athlete in this.Athletes)
                athlete.Exercise();
        }

        public string GymInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.Name} is a {this.GetType().Name}:");
            sb.Append("Athletes: ");

            if (this.Athletes.Any()) sb.AppendLine(String.Join(", ", this.Athletes.Select(x => x.FullName)));
            else sb.AppendLine("No athletes");

            sb.AppendLine($"Equipment total count: {this.Equipment.Count}");
            sb.Append($"Equipment total weight: {this.EquipmentWeight} grams");

            return sb.ToString().Trim();
        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            return this.Athletes.Remove(athlete);
        }
    }
}
