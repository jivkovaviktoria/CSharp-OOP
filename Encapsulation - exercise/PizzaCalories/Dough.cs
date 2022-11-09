using System;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double weight;        

        private string FlourType 
        {             
            set 
            {                
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain") throw new ArgumentException("Invalid type of dough.");
                flourType = value;
            }
        }

        private string BakingTechnique
        { 
            set
            {                
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade") throw new ArgumentException("Invalid type of dough.");
                bakingTechnique = value;
            }
        }

        private double Grams 
        {
            set
            {
                if (value < 1 || value > 200) throw new ArgumentException("Dough weight should be in the range[1..200].");
                weight = value;
            } 
        }

        public double CaloriesPerGram 
        { 
            get 
            { 
                double caloriesPerGram = 2;

                if (this.flourType.ToLower() == "white") caloriesPerGram *= 1.5;
                else if (this.flourType.ToLower() == "wholegrain") caloriesPerGram *= 1.0;
                if (this.bakingTechnique.ToLower() == "crispy") caloriesPerGram *= 0.9;
                else if (this.bakingTechnique.ToLower() == "chewy") caloriesPerGram *= 1.1;
                else if (this.bakingTechnique.ToLower() == "homemade") caloriesPerGram *= 1.0;

                return caloriesPerGram;
            } 
        }

        public Dough(string flourType, string bakingTechnique, double grams)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Grams = grams;
        }

        
        public double GetCalories() => this.weight * this.CaloriesPerGram;
    }
}