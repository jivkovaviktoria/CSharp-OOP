namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {
        }

        public override double FuelConsumption => base.FuelConsumption + 1.6;
        public override void Refuel(double fuel) => base.Refuel(fuel*0.95);
        
    }
}