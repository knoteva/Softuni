using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using CarDealer.Data;
using CarDealer.DTO.Export;
using CarDealer.DTO.Import;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new CarDealerContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();
            //// 09. Import Suppliers
            // var suppliersJson = File.ReadAllText(@"D:\Programing\Softuni\01. Entity Framework Core\18. Exercise JSON Processing\Car Dealer - Skeleton\CarDealer\Datasets\suppliers.json");
            //var usersResult = ImportSuppliers(context, suppliersJson);
            //Console.WriteLine(usersResult);

            //// 10. Import Parts
            //var partsJson = File.ReadAllText(@"D:\Programing\Softuni\01. Entity Framework Core\18. Exercise JSON Processing\Car Dealer - Skeleton\CarDealer\Datasets\parts.json");
            //var partsResult = ImportParts(context, partsJson);
            //Console.WriteLine(partsResult);

            //// 11.Import Cars
            //var carsJson = File.ReadAllText(@"D:\Programing\Softuni\01. Entity Framework Core\18. Exercise JSON Processing\Car Dealer - Skeleton\CarDealer\Datasets\cars.json");
            //var carsResult = ImportCars(context, carsJson);
            //Console.WriteLine(carsResult);

            ////12. Import Customers
            //var customersJson = File.ReadAllText(@"D:\Programing\Softuni\01. Entity Framework Core\18. Exercise JSON Processing\Car Dealer - Skeleton\CarDealer\Datasets\customers.json");
            //var customersResult = ImportCustomers(context, customersJson);
            //Console.WriteLine(customersResult);

            //// 13. Import Sales
            //var salesJson = File.ReadAllText(@"D:\Programing\Softuni\01. Entity Framework Core\18. Exercise JSON Processing\Car Dealer - Skeleton\CarDealer\Datasets\sales.json");
            //var salesResult = ImportSales(context, salesJson);
            //Console.WriteLine(salesResult);

            ////// 3. Query and Export Data
            //// 14. Export Ordered Customers
            //Console.WriteLine(GetOrderedCustomers(context));

            //// 15. Export Cars From Make Toyota
            //Console.WriteLine(GetCarsFromMakeToyota(context));

            //// 16. Export Local Suppliers
            //Console.WriteLine(GetLocalSuppliers(context));

            //// 17. Export Cars With Their List Of Parts
            //var text = GetCarsWithTheirListOfParts(context);
            //System.IO.File.WriteAllText(@"D:\Programing\Softuni\01. Entity Framework Core\18. Exercise JSON Processing\Car Dealer - Skeleton\WriteText.txt", text);
            //Console.WriteLine(text);

            //// 18. Export Total Sales By Customer
            Console.WriteLine(GetTotalSalesByCustomer(context));

            //// 19. Export Sales With Applied Discount
            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }


        // 09. Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<Supplier[]>(inputJson)
                   .ToList();
            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();
            return $"Successfully imported {suppliers.Count}.";
        }

        // 10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var existingSuppliers = context.Suppliers
                .Select(s => s.Id)
                .ToArray();

            var parts = JsonConvert.DeserializeObject<Part[]>(inputJson)
                .Where(p => existingSuppliers.Contains(p.SupplierId))
                .ToArray();

            context.Parts.AddRange(parts);
            int affectedRows = context.SaveChanges();

            return $"Successfully imported {affectedRows}.";
        }

        // 11. Import Cars
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var cars = JsonConvert.DeserializeObject<ImortCarDto[]>(inputJson)
                   .ToList();
            foreach (var carDto in cars)
            {
                var car = new Car
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TravelledDistance
                };

                context.Cars.Add(car);

                foreach (var partId in carDto.PartsId)
                {
                    var partCar = new PartCar
                    {
                        CarId = car.Id,
                        PartId = partId
                    };

                    if (car.PartCars.FirstOrDefault(p => p.PartId == partId) == null)
                    {
                        context.PartCars.Add(partCar);
                    }
                }
            }

            context.SaveChanges();
            return $"Successfully imported {cars.Count}.";
        }

        // 12. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<Customer[]>(inputJson)
                   .ToList();
            context.Customers.AddRange(customers);
            context.SaveChanges();
            return $"Successfully imported {customers.Count}.";
        }

        // 13. Import Sales
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<Sale[]>(inputJson)
                     .ToList();
            context.Sales.AddRange(sales);
            context.SaveChanges();
            return $"Successfully imported {sales.Count}.";
        }


        //// 3. Query and Export Data
        // 14. Export Ordered Customers
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var orderedCustomers = context.Customers
                    .OrderBy(oc => oc.BirthDate)
                    .ThenBy(oc => oc.IsYoungDriver)
                    .Select(oc => new OrderedCustomersDto
                    {
                        Name = oc.Name,
                        BirthDate = oc.BirthDate.ToString("dd/MM/yyyy"),
                        IsYoungDriver = oc.IsYoungDriver
                    })
                    .ToList();

            var jsonCustomers = JsonConvert.SerializeObject(orderedCustomers, Formatting.Indented);

            return jsonCustomers;
        }

        // 15. Export Cars From Make Toyota
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var getToyotaCars = context.Cars
                 .Where(tc => tc.Make == "Toyota")
                    .Select(tc => new GetToyotaCarsDto
                    {
                        Id = tc.Id,
                        Make = tc.Make,
                        Model = tc.Model,
                        TravelledDistance = tc.TravelledDistance,
                    })
                    .OrderBy(tc => tc.Model)
                    .ThenByDescending(tc => tc.TravelledDistance)
                    .ToList();

            var jsonToyotaCars = JsonConvert.SerializeObject(getToyotaCars, Formatting.Indented);

            return jsonToyotaCars;
        }

        // 16. Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new LocalSuppliersDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count()
                })
                .ToList();

            var suppliersJson = JsonConvert.SerializeObject(suppliers, Formatting.Indented);

            return suppliersJson;
        }

        // 17. Export Cars With Their List Of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new
                {
                    car = new CarDto
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance
                    },
                    parts = c.PartCars
                    .Select(p => new PartDto
                    {
                        Name = p.Part.Name,
                        Price = $"{p.Part.Price:F2}"
                    })
                })
                .ToList();

            var carsPartsJson = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return carsPartsJson;
        }

        // 18. Export Total Sales By Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        { 
            var customers = context.Customers
                .Where(c => c.Sales.Count > 0)
                .Select( cc => new CustomerWithCarDto 
                {
                    FullName = cc.Name,
                    BoughtCars = cc.Sales.Count,
                    SpentMoney = cc.Sales.Sum(s => s.Car.PartCars.Sum(p => p.Part.Price))
                })
                .OrderByDescending(m => m.SpentMoney)
                .ThenByDescending(c => c.BoughtCars)
                .ToList();
            var customerSalesJson = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return customerSalesJson;
        }

        // 19. Export Sales With Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                   .Select(s => new
                   {
                       car = new CarDto
                       {
                           Make = s.Car.Make,
                           Model = s.Car.Model,
                           TravelledDistance = s.Car.TravelledDistance
                       },
                       customerName = s.Customer.Name,
                       Discount = $"{s.Discount:F2}",
                       price = $"{s.Car.PartCars.Sum(p => p.Part.Price):F2}",
                       priceWithDiscount = $@"{(s.Car.PartCars.Sum(p => p.Part.Price) -
                           s.Car.PartCars.Sum(p => p.Part.Price) * s.Discount / 100):F2}"
                   })
                   .Take(10)
                   .ToList();

            var json = JsonConvert.SerializeObject(sales, Formatting.Indented);

            return json;
        }
    }
}