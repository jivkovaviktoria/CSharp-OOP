using System;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Utilities.Messages;

namespace Bakery.Models.BakedFoods
{
    public abstract class BakedFood : IBakedFood
    {
        protected BakedFood(string name, int portion, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException(ExceptionMessages.InvalidName);

            if (portion <= 0) throw new ArgumentException(ExceptionMessages.InvalidPortion);
            if (price <= 0) throw new ArgumentException(ExceptionMessages.InvalidPrice);
            
            this.Name = name;
            this.Portion = portion;
            this.Price = price;
        }

        public string Name { get; }
        public int Portion { get; }
        public decimal Price { get; }

        public override string ToString()
         => $"{this.GetType().Name}: {this.Portion}g - {this.Price:F2}";
        
    }
}