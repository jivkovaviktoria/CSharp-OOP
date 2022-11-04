namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption => base.FuelConsumption + 1.6;

        public override void Refuel(double fuel)
        {
            if(this.FuelQuantity + (fuel*0.95) < this.TankCapacity)
                base.Refuel(fuel*0.95);
            else base.Refuel(fuel);
        }

    }
}