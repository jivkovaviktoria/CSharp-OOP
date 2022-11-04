using System;
using Vehicles.Models.Contracts;

namespace Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            if (fuelQuantity > tankCapacity)
                this.FuelQuantity = 0;
            else this.FuelQuantity = fuelQuantity;
            
            this.TankCapacity = tankCapacity;
            this.FuelConsumption = fuelConsumption;
        }

        public double FuelQuantity { get; set; }
        public virtual double FuelConsumption { get; set; }
        public double TankCapacity { get; set; }

        public virtual string Drive(double distance)
        {
            if (this.FuelQuantity - (this.FuelConsumption * distance) >= 0)
            {
                this.FuelQuantity -= this.FuelConsumption * distance;
                return $"{this.GetType().Name} travelled {distance} km";
            }

            return $"{this.GetType().Name} needs refueling";
        }

        public virtual void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }
            
            if (this.FuelQuantity + fuel > this.TankCapacity) Console.WriteLine($"Cannot fit {fuel} fuel in the tank");
            else this.FuelQuantity += fuel;
        }

        public override string ToString() => $"{this.GetType().Name}: {this.FuelQuantity:f2}";
    }
}