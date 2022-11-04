namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
        }

        public bool IsEmpty { get; set; }
        public override string Drive(double distance)
        {
            string result;
            if (IsEmpty) return base.Drive(distance);
            else
            {
                this.FuelConsumption = this.FuelConsumption + 1.4;
                result = base.Drive(distance);
                this.FuelConsumption = this.FuelConsumption - 1.4;
            }

            return result;
        }
    }
}