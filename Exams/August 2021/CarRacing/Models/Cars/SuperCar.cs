namespace CarRacing.Models.Cars
{
    public class SuperCar : Car
    {
        public SuperCar(string make, string model, string vin, int hp) : base(make, model, vin, hp, 80, 10)
        {
        }
    }
}