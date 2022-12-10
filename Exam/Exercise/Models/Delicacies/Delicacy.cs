using System;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Utilities.Messages;

namespace ChristmasPastryShop.Models.Delicacies
{
    public abstract class Delicacy : IDelicacy
    {
        protected Delicacy(string name, double price)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);

            this.Name = name;
            this.Price = price;
        }
        public string Name { get; }
        public double Price { get; }

        public override string ToString()
            => $"{this.Name} - {this.Price:f2} lv";
    }
}