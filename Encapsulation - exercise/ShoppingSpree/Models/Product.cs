﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree.Models
{
    public class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be empty");

                this.name = value;
            }
        }
        public decimal Cost
        {
            get { return cost; }
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Money cannot be negative");
                cost = value;
            }
        }

        public override string ToString() => this.Name;
    }
}
