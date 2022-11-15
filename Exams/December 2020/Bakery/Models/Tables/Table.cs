﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;

namespace Bakery.Models.Tables
{
     public abstract class Table : ITable
    {
        private readonly List<IBakedFood> foodOrders = new List<IBakedFood>();
        private readonly List<IDrink> drinkOrders = new List<IDrink>();

        private int capacity;
        private int numberOfPeople;

        protected Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
            
            this.IsReserved = false;
        }

        public int TableNumber { get; }

        public int Capacity
        {
            get => this.capacity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }

                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get => this.numberOfPeople;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }

                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get; }

        public bool IsReserved { get; private set; }

        public decimal Price
            => foodOrders.Select(f => f.Price).Sum()
            + drinkOrders.Select(f => f.Price).Sum()
            + this.NumberOfPeople * this.PricePerPerson;

        public void Clear()
        {
            this.drinkOrders.Clear();
            this.foodOrders.Clear();
            
            this.IsReserved = false;
            this.Capacity = 0;
        }

        public decimal GetBill() => this.Price;
        
        public string GetFreeTableInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Table: {this.TableNumber}");
            sb.AppendLine($"Type: {this.GetType().Name}");
            sb.AppendLine($"Capacity: {this.Capacity}");
            sb.Append($"Price per Person: {this.PricePerPerson}");

            return sb.ToString();
        }

        public void OrderDrink(IDrink drink) => this.drinkOrders.Add(drink);

        public void OrderFood(IBakedFood food) => this.foodOrders.Add(food);
        
        public void Reserve(int numberOfPeople)
        {
            this.IsReserved = true;
            this.NumberOfPeople = numberOfPeople;
        }
    }
}