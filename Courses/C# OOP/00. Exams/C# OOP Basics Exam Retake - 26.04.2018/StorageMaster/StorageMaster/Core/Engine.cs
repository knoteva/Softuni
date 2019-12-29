using System;
using System.Collections.Generic;
using System.Text;

namespace StorageMaster.Core
{
    public class Engine
    {
        private StorageMaster storageMaster;
        public Engine(StorageMaster storageMaster)
        {
            this.storageMaster = storageMaster;
        }


        public void Run()
        {
            var input = string.Empty;
            var output = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                try
                {
                    var inputArgs = input.Split(" ");
                    var command = inputArgs[0];
                    if (command == "AddProduct")
                    {
                        string type = inputArgs[1];
                        double price = double.Parse(inputArgs[2]);
                        output = storageMaster.AddProduct(type, price);
                    }
                    else if (command == "RegisterStorage")
                    {

                    }
                    else if (command == "SelectVehicle")
                    {

                    }
                    else if (command == "LoadVehicle")
                    {

                    }
                    else if (command == "SendVehicleTo")
                    {
                        //TODO
                    }
                    else if (command == "UnloadVehicle")
                    {
                        //TODO
                    }
                    else if (command == "GetStorageStatus")
                    {
                        //TODO
                    }
                    Console.WriteLine(output);
                }
                catch (InvalidOperationException ex)
                {

                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            
        }
    }
}
