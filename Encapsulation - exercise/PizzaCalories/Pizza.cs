using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value) || value.Length > 15) 
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                this.name = value;
            }
        }
        public Dough Dough { get { return dough; } set { dough = value; } }
        public int Count => this.toppings.Count;
        public double TotalCalories
        {
            get
            {
                double totalCalories = this.dough.GetCalories();
                
                foreach (Topping topping in toppings) totalCalories += topping.GetCalories();
                return totalCalories;
            }
        }

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dough = dough;
            this.toppings = new List<Topping>();
        }


        public void AddTopping(Topping topping)
        {
            if (this.Count == 10) throw new ArgumentException("Number of toppings should be in range [0..10].");
            toppings.Add(topping);
        }

        public override string ToString() => $"{this.name} - {this.TotalCalories:f2} Calories.";
    }
}