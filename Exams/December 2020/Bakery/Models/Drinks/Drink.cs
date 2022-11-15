using System;
using Bakery.Models.Drinks.Contracts;
using Bakery.Utilities.Messages;

namespace Bakery.Models.Drinks
{
    public abstract class Drink : IDrink
    {
        protected Drink(string name, int portion, decimal price, string brand)
        {
            if(string.IsNullOrWhiteSpace(name)) throw new ArgumentException(ExceptionMessages.InvalidName);
            if (string.IsNullOrWhiteSpace(brand)) throw new ArgumentException(ExceptionMessages.InvalidBrand);

            if (portion <= 0) throw new ArgumentException(ExceptionMessages.InvalidPortion);
            if (price <= 0) throw new ArgumentException(ExceptionMessages.InvalidPrice);
            
            this.Name = name;
            this.Portion = portion;
            this.Price = price;
            this.Brand = brand;
        }

        public string Name { get; }

        public int Portion { get; }

        public decimal Price { get; }

        public string Brand { get; }

        public override string ToString()
         => $"{this.GetType().Name} {this.Brand} - {this.Portion}ml - {this.Price:F2}lv";
        
    }
}