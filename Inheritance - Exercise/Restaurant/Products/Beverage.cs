using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Beverage : Product
    {
        public Beverage(string name, decimal price, double millileters) : base(name, price)
        {
            this.Millileters = millileters;
        }
        public double Millileters { get; set; }
    }
}
