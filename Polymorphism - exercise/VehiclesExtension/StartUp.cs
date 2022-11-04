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
            var busInfo = Console.ReadLine().Split();
            
            double carFuel = double.Parse(carInfo[1]), carConsumption = double.Parse(carInfo[2]), carCapacity = double.Parse(carInfo[3]);
            double truckFuel = double.Parse(truckInfo[1]), truckConsumption = double.Parse(truckInfo[2]), truckCapacity = double.Parse(truckInfo[3]);
            double busFuel = double.Parse(busInfo[1]), busConsumption = double.Parse(busInfo[2]), busCapacity = double.Parse(busInfo[3]);
            
            var car = new Car(carFuel, carConsumption, carCapacity);
            var truck = new Truck(truckFuel, truckConsumption, truckCapacity);
            var bus = new Bus(busFuel, busConsumption, busCapacity);
            
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
                else if (type == nameof(Bus))
                {
                    if(cmd == "Drive") Console.WriteLine(bus.Drive(amount));
                    else if (cmd == "DriveEmpty")
                    {
                        bus.IsEmpty = true;
                        Console.WriteLine(bus.Drive(amount));
                        bus.IsEmpty = false;
                    }
                    else if(cmd == "Refuel") bus.Refuel(amount);
                }
            }

            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
            Console.WriteLine(bus.ToString());
        }
    }
}