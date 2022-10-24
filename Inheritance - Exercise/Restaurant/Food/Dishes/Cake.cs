using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Dishes
{
    public class Cake : Dessert
    {
        public const double grams = 250;
        public const double calories = 1000;
        public const decimal price = 5;

        public Cake(string name) : base(name, price, grams, calories)
        {
            this.Grams = grams;
            this.Calories = calories;
            this.Price = price;
        }
    }
}
