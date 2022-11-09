﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private List<IAquarium> aquariums = new List<IAquarium>();
        private DecorationRepository decorations = new DecorationRepository();
        public string AddAquarium(string aquariumType, string aquariumName)
        {
            IAquarium aquarium;
            if (aquariumType == nameof(FreshwaterAquarium)) aquarium = new FreshwaterAquarium(aquariumName);
            else if (aquariumType == nameof(SaltwaterAquarium)) aquarium = new SaltwaterAquarium(aquariumName);
            else throw new InvalidOperationException(ExceptionMessages.InvalidAquariumType);

            this.aquariums.Add(aquarium);
            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            IDecoration decoration;
            if (decorationType == nameof(Ornament)) decoration = new Ornament();
            else if (decorationType == nameof(Plant)) decoration = new Plant();
            else throw new InvalidOperationException(ExceptionMessages.InvalidDecorationType);

            this.decorations.Add(decoration);
            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var decoration = this.decorations.FindByType(decorationType);
            if (decoration is null)
                throw new InvalidOperationException(String.Format(ExceptionMessages.InexistentDecoration,
                    decorationType));
            
            var aquarium = this.aquariums.Find(x => x.Name == aquariumName);
            aquarium.AddDecoration(decoration);
            decorations.Remove(decoration);

            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType, aquariumName);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish;
            if (fishType == nameof(FreshwaterFish)) fish = new FreshwaterFish(fishName, fishSpecies, price);
            else if (fishType == nameof(SaltwaterFish)) fish = new SaltwaterFish(fishName, fishSpecies, price);
            else throw new InvalidOperationException(ExceptionMessages.InvalidFishType);

            var aquarium = this.aquariums.Find(x => x.Name == aquariumName);

            if (fishType == nameof(FreshwaterFish) && aquarium.GetType().Name == nameof(FreshwaterAquarium))
            {
                aquarium.AddFish(fish);
                return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
            }
            else if(fishType == nameof(SaltwaterFish) && aquarium.GetType().Name == nameof(SaltwaterAquarium))
            {
                aquarium.AddFish(fish);
                return string.Format(OutputMessages.EntityAddedToAquarium, fishType, aquariumName);
            }
            
            return OutputMessages.UnsuitableWater;
        }

        public string FeedFish(string aquariumName)
        {
            var aquarium = this.aquariums.Find(x => x.Name == aquariumName);
            aquarium.Feed();

            return string.Format(OutputMessages.FishFed, aquarium.Fish.Count);
        }

        public string CalculateValue(string aquariumName)
        {
            var aquarium = this.aquariums.Find(x => x.Name == aquariumName);
            
            var decorationsValue = aquarium.Decorations.Select(x => x.Price).Sum();
            var fishValue = aquarium.Fish.Select(x => x.Price).Sum();

            var total = (decorationsValue + fishValue);
            string value = $"{total:f2}";

            return string.Format(OutputMessages.AquariumValue, aquariumName, value);
        }

        public string Report()
        {
            var sb = new StringBuilder();
            foreach (var aq in this.aquariums) sb.AppendLine(aq.GetInfo());

            return sb.ToString().Trim();
        }
    }
}