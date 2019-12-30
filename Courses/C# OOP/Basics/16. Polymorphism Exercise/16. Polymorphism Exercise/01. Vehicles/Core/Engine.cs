using _01._Vehicles.Vehicles;
using _01._Vehicles.Vehicles.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace _01._Vehicles.Core
{
    public class Engine
    {
        public void Run()
        {
            //Car 15 0.3
            //Truck 100 0.9
            var carInfo = Console.ReadLine().Split(" ");
            var carFuelQuantity = double.Parse(carInfo[1]);
            var carLitersPerKm = double.Parse(carInfo[2]);
            var carThankCapacity = double.Parse(carInfo[3]);
            var truckInfo = Console.ReadLine().Split(" ");
            var truckFuelQuantity = double.Parse(truckInfo[1]);
            var truckLitersPerKm = double.Parse(truckInfo[2]);
            var truckThankCapacity = double.Parse(truckInfo[3]);
            var busInfo = Console.ReadLine().Split(" ");
            var busFuelQuantity = double.Parse(busInfo[1]);
            var busLitersPerKm = double.Parse(busInfo[2]);
            var busThankCapacity = double.Parse(busInfo[3]);

            IVehicle car = new Car(carFuelQuantity, carLitersPerKm, carThankCapacity);
            IVehicle truck = new Truck(truckFuelQuantity, truckLitersPerKm, truckThankCapacity);
            Vehicle bus = new Bus(busFuelQuantity, busLitersPerKm, busThankCapacity);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                try
                {
                    var inputArgs = Console.ReadLine().Split(" ");
                    var command = inputArgs[0];
                    var type = inputArgs[1];
                    var value = double.Parse(inputArgs[2]);
                    if (command == "Drive")
                    {
                        if (type == "Car")
                        {
                            car.Drive(value);
                        }
                        else if(type == "Truck")
                        {
                            truck.Drive(value);
                        }
                        else if (type == "Bus")
                        {
                            bus.IsVehicleEmpty = false;
                            bus.Drive(value);
                        }
                    }
                    else if (command == "Refuel")
                    {
                        if (type == "Car")
                        {
                            car.Refuel(value);
                        }
                        else if(type == "Truck")
                        {
                            truck.Refuel(value);
                        }
                        else if (type == "Bus")
                        {
                            
                            bus.Refuel(value);
                        }
                    }
                    else if (command == "DriveEmpty")
                    {
                        if (type == "Bus")
                        {
                            bus.IsVehicleEmpty = true;
                            bus.Drive(value);
                        }
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}
