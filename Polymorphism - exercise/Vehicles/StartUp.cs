using System;
using Vehicles.Models;

namespace Vehicles
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var carInfo = Console.ReadLine().Split();
            var truckInfo = Console.ReadLine().Split();

            double carFuel = double.Parse(carInfo[1]), carConsumption = double.Parse(carInfo[2]);
            double truckFuel = double.Parse(truckInfo[1]), truckConsumption = double.Parse(truckInfo[2]);

            var car = new Car(carFuel, carConsumption);
            var truck = new Truck(truckFuel, truckConsumption);
            
            int commandsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < commandsCount; i++)
            {
                var tokens = Console.ReadLine().Split();
                var cmd = tokens[0];
                var type = tokens[1];
                var amount = double.Parse(tokens[2]);

                if (type == nameof(Car))
                {
                    if (cmd == "Drive") Console.WriteLine(car.Drive(amount));
                    else if(cmd == "Refuel") car.Refuel(amount);
                }
                else if (type == nameof(Truck))
                {
                    if (cmd == "Drive") Console.WriteLine(truck.Drive(amount));
                    else if(cmd == "Refuel") truck.Refuel(amount);
                }
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
        }
    }
}