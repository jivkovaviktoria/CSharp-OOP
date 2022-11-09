using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Topping
    {
        private string type;
        private double grams;
        private readonly List<string> toppingTypes = new List<string> { "cheese", "meat", "veggies", "sauce" };

        private double Grams
        {
            set
            {
                if (value < 1 || value > 50)
                    throw new ArgumentException($"{this.type} weight should be in the range [1..50].");
                this.grams = value;
            }
        }

        private string Type
        {
            set
            {
                if (!toppingTypes.Contains(value.ToLower()))
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                type = value;
            }
        }

        public double CaloriesPerGram
        {
            get
            {
                double caloriesPerGram = 2;
                
                if (this.type.ToLower() == "meat") caloriesPerGram *= 1.2;
                else if (this.type.ToLower() == "veggies") caloriesPerGram *= 0.8;
                else if (this.type.ToLower() == "cheese") caloriesPerGram *= 1.1;
                else if (this.type.ToLower() == "sauce") caloriesPerGram *= 0.9;
                
                return caloriesPerGram;
            }
        }

        public Topping(string type, double grams)
        {
            this.Type = type;
            this.Grams = grams;
        }

        
        public double GetCalories() => this.CaloriesPerGram * this.grams;
    }
}