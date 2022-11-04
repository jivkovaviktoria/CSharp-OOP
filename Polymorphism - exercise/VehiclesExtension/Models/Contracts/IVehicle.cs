namespace Vehicles.Models.Contracts
{
    public interface IVehicle
    {
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }
        public double TankCapacity { get; set; }

        public string Drive(double distance);
        public void Refuel(double fuel);
    }
}