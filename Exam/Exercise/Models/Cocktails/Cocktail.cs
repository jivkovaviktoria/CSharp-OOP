using System;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Utilities.Messages;

namespace ChristmasPastryShop.Models.Cocktails
{
    public abstract class Cocktail : ICocktail
    {
        private double price;
        protected Cocktail(string name, string size, double price)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
            this.Name = name;

            this.Size = size;
            this.Price = price;
        }
        public string Name { get; }
        public string Size { get; }

        public double Price
        {
            get => this.price;
            protected set
            {
                if (this.Size == "Large") this.price = value;
                else if (this.Size == "Middle") this.price = (2.00 / 3.00) * value;
                else if (this.Size == "Small") this.price = (1.00 / 3.00) * value;
            }
        }

        public override string ToString()
        => $"{this.Name} ({this.Size}) - {this.Price:f2} lv";
    }
}