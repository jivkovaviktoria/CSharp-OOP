using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;

namespace AquaShop.Models.Aquariums
{
    public class Aquarium : IAquarium
    {
        private ICollection<IDecoration> decorations;
        private ICollection<IFish> fish;
        
        protected Aquarium(string name, int capacity)
        {
            if (string.IsNullOrWhiteSpace(name)) 
                throw new ArgumentException(ExceptionMessages.InvalidAquariumName);

            this.Name = name;
            this.Capacity = capacity;
            this.decorations = new List<IDecoration>();
            this.fish = new List<IFish>();
        }
        
        public string Name { get; }
        public int Capacity { get; }
        
        public int Comfort => this.decorations.Select(x => x.Comfort).Sum();
        
        public ICollection<IDecoration> Decorations => this.decorations;
        public ICollection<IFish> Fish => this.fish;
        
        public void AddFish(IFish fish)
        {
            if (this.fish.Count < this.Capacity) this.fish.Add(fish);
            else throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
        }

        public bool RemoveFish(IFish fish) => this.fish.Remove(fish);

        public void AddDecoration(IDecoration decoration) => this.decorations.Add(decoration);

        public void Feed()
        {
            foreach (var x in this.fish) x.Eat();
        }

        public string GetInfo()
        {
            var sb = new StringBuilder();
            
            sb.AppendLine($"{this.Name} ({this.GetType().Name}):");

            if (this.fish.Count > 0) sb.AppendLine($"Fish: {string.Join(", ", this.fish.Select(x => x.Name))}");
            else sb.AppendLine($"Fish: none");

            sb.AppendLine($"Decorations: {this.decorations.Count}");
            sb.Append($"Comfort: {this.Comfort}");

            return sb.ToString();
        }
    }
}