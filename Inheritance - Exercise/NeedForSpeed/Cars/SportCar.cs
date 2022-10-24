using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed.Cars
{
    public class SportCar : Car
    {
        public SportCar(int horsePower, double fuel) : base(horsePower, fuel)
        {
            this.FuelConsumption = 10;
        }
    }
}
