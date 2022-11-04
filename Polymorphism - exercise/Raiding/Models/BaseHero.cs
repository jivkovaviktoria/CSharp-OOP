﻿using Raiding.Models.Contracts;

namespace Raiding.Models
{
    public abstract class BaseHero : IHero
    {
        protected BaseHero(string name, int power)
        {
            this.Name = name;
            this.Power = power;
        }
        
        public string Name { get; set; }
        public int Power { get; set; }

        public abstract string CastAbility();
    }
}