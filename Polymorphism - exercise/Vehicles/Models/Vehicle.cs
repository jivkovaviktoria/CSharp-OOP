using Vehicles.Models.Contracts;

namespace Vehicles.Models
{
    public abstract class Vehicle : IVehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }
        public double FuelQuantity { get; set; }
        public virtual double FuelConsumption { get; set; }

        public string Drive(double distance)
        {
            if (this.FuelQuantity - (this.FuelConsumption * distance) >= 0)
            {
                this.FuelQuantity -= this.FuelConsumption * distance;
                return $"{this.GetType().Name} travelled {distance} km";
            }

            return $"{this.GetType().Name} needs refueling";
        }
        
        public virtual void Refuel(double fuel) => this.FuelQuantity += fuel;

        public override string ToString() => $"{this.GetType().Name}: {this.FuelQuantity:f2}";
    }
}