using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Beverages.HotBeverages
{
    public class Coffee : HotBeverage
    {
        public Coffee(string name, double caffeine) : base(name , CoffeePrice, CoffeeMillileters)
        {
            this.Caffeine = caffeine;
        }

        public const double CoffeeMillileters = 50;
        public const decimal CoffeePrice = 3.50m;
        public double Caffeine { get; set; }
    }
}
