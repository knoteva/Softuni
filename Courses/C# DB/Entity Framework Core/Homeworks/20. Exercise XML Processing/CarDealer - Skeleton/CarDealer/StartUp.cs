using AutoMapper;
using CarDealer.Data;
using CarDealer.Dtos.Export;
using CarDealer.Dtos.Import;
using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<CarDealerProfile>();
            });

            var context = new CarDealerContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();


            //// 09.Import Suppliers
            //var suppliersXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            //var suppliersResult = ImportSuppliers(context, suppliersXml);
            //Console.WriteLine(suppliersResult);

            //// 10. Import Parts
            //var partsXml = File.ReadAllText("../../../Datasets/parts.xml");
            //var partsResult = ImportParts(context, partsXml);
            //Console.WriteLine(partsResult);

            //// 11. Import Cars
            //var carsXml = File.ReadAllText("../../../Datasets/cars.xml");
            //var carsResult = ImportCars(context, carsXml);
            //Console.WriteLine(carsResult);

            //// 12. Import Customers
            //var customersXml = File.ReadAllText("../../../Datasets/customers.xml");
            //var customersResult = ImportCustomers(context, customersXml);
            //Console.WriteLine(customersResult);

            //// 13. Import Sales
            //var salesXml = File.ReadAllText("../../../Datasets/sales.xml");
            //var salesResult = ImportSales(context, salesXml);
            //Console.WriteLine(salesResult);

            //// 14. Export Cars With Distance
            //Console.WriteLine(GetCarsWithDistance(context));

            //// 15. Export Cars From Make BMW
            //Console.WriteLine(GetCarsFromMakeBmw(context));

            //// 16.Export Local Suppliers
             //Console.WriteLine(GetLocalSuppliers(context));

            //// 17. Export Cars With Their List Of Parts
            //Console.WriteLine(GetCarsWithTheirListOfParts(context));

            //// 18. Export Total Sales By Customer
            //Console.WriteLine(GetTotalSalesByCustomer(context));

            //// 19. Export Sales With Applied Discount
            Console.WriteLine(GetSalesWithAppliedDiscount(context));

        }

        // 09.Import Suppliers
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportSuppliersDto[]), new XmlRootAttribute("Suppliers"));
            var suppliersDto = (ImportSuppliersDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var suppliers = new List<Supplier>();
            foreach (var supplierDto in suppliersDto)
            {
                var supplier = Mapper.Map<Supplier>(supplierDto);
                suppliers.Add(supplier);
            }
            context.Suppliers.AddRange(suppliers);
            int count = context.SaveChanges();
            return $"Successfully imported {count}";
        }

        // 10. Import Parts
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportPartsDto[]), new XmlRootAttribute("Parts"));
            var partsDto = (ImportPartsDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var parts = new List<Part>();
            var suppliersCount = context.Suppliers.Count();

            foreach (var partDto in partsDto)
            {
                if (partDto.SupplierId <= suppliersCount && partDto.SupplierId > 0)
                {
                    var part = Mapper.Map<Part>(partDto);

                    parts.Add(part);
                }
            }

            context.Parts.AddRange(parts);
            int count = context.SaveChanges();

            return $"Successfully imported {count}";
        }

        // 11. Import Cars
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportCarsDto[]), new XmlRootAttribute("Cars"));

            var carsDtos = (ImportCarsDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var cars = new List<Car>();
            var carParts = new List<PartCar>();

            foreach (var car in carsDtos)
            {
                var currentCar = Mapper.Map<Car>(car);

                foreach (var part in car.Parts)
                {
                    if (!currentCar.PartCars.Select(e => e.PartId).Contains(part.PartId)
                        && part.PartId <= context.Parts.Count())
                    {
                        currentCar.PartCars.Add(new PartCar()
                        {
                            PartId = part.PartId
                        });
                    }
                }
                cars.Add(currentCar);
            }

            context.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        // 12. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCustomersDto[]), new XmlRootAttribute("Customers"));
            var customersDto = (ImportCustomersDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var customers = new List<Customer>();
            foreach (var customerDto in customersDto)
            {
                var customer = Mapper.Map<Customer>(customerDto);
                customers.Add(customer);
            }
            context.Customers.AddRange(customers);
            int count = context.SaveChanges();
            return $"Successfully imported {count}";
        }

        // 13. Import Sales
        public static string ImportSales(CarDealerContext context, string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ImportSalesDto[]),
               new XmlRootAttribute("Sales"));

            var salesDeserialized = (ImportSalesDto[])serializer
                .Deserialize(new StringReader(inputXml));

            var sales = new List<Sale>();

            foreach (var sale in salesDeserialized.Where(e => context.Cars.Any(n => n.Id == e.CarId) && e.Discount <= 100))
            {
                var currentSale = Mapper.Map<Sale>(sale);
                sales.Add(currentSale);
            }

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Count}";
        }

        // 14. Export Cars With Distance
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var carsWithDistance = context.Cars
                        .Where(c => c.TravelledDistance > 2000000)
                        .Select(c => new ExportCarsWithDistanceDto
                        {
                            Make = c.Make,
                            Model = c.Model,
                            TravelledDistance = c.TravelledDistance
                        })
                        .OrderBy(c => c.Make)
                        .ThenBy(c => c.Model)
                        .Take(10)
                        .ToArray();

            var xmlSerializer =
                 new XmlSerializer(typeof(ExportCarsWithDistanceDto[]), new XmlRootAttribute("cars"));

            StringBuilder sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(sb), carsWithDistance, namespaces);

            return sb.ToString().TrimEnd();
        }

        // 15. Export Cars From Make BMW
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var cars = context.Cars
                   .Where(e => e.Make == "BMW")
                   .OrderBy(e => e.Model)
                   .ThenByDescending(e => e.TravelledDistance)
                   .Select(e => new ExportCarsFromMakeBMWDto
                   {
                       Id = e.Id,
                       Model = e.Model,
                       TravelledDistance = e.TravelledDistance
                   })
                   .ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(ExportCarsFromMakeBMWDto[]),
                new XmlRootAttribute("cars"));

            StringBuilder sb = new StringBuilder();

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            serializer.Serialize(new StringWriter(sb), cars, ns);

            return sb.ToString();
        }

        // 16.Export Local Suppliers
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
             .Where(e => e.IsImporter == false)
             .Select(e => new ExportLocalSuppliersDto
             {
                 Id = e.Id,
                 Name = e.Name,
                 PartsCount = e.Parts.Count()
             })
             .ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(ExportLocalSuppliersDto[]),
                new XmlRootAttribute("suppliers"));

            StringBuilder sb = new StringBuilder();

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            serializer.Serialize(new StringWriter(sb), suppliers, ns);

            return sb.ToString();
        }

        // 17. Export Cars With Their List Of Parts
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                    .OrderByDescending(e => e.TravelledDistance)
                    .ThenBy(e => e.Model)
                   .Select(e => new ExportCarsWithListOfPartsDto
                   {
                       Make = e.Make,
                       Model = e.Model,
                       TravelledDistance = e.TravelledDistance,

                       Parts =

                           e.PartCars.Select(p => new ExportCarsPartsListDto
                           {
                               Name = p.Part.Name,
                               Price = p.Part.Price
                           })
                           .OrderByDescending(p => p.Price)
                           .ToArray()
                   })
                   .Take(5)
                   .ToArray();


            XmlSerializer serializer = new XmlSerializer(typeof(ExportCarsWithListOfPartsDto[]),
                new XmlRootAttribute("cars"));

            StringBuilder sb = new StringBuilder();

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            serializer.Serialize(new StringWriter(sb), cars, ns);

            return sb.ToString();
        }

        // 18. Export Total Sales By Customer
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        { 
             var customers = context.Customers
                 .Where(e => e.Sales.Any())
                  .OrderByDescending(e => e.Sales.Sum(s => s.Car.PartCars.Sum(n => n.Part.Price)))
                 .Select(e => new ExportTotalSalesByCustomerDto
                 {
                     Name = e.Name,
                     BoughtCars = e.Sales.Count(),
                    //SpentMoney = e.Sales.Select(s => s.Car.PartCars.Sum(n => n.Part.Price)),
                    SpentMoney = e.Sales.Sum(s => s.Car.PartCars.Sum(n => n.Part.Price)),

                 })
                 .ToArray();


            XmlSerializer serializer = new XmlSerializer(typeof(ExportTotalSalesByCustomerDto[]),
                new XmlRootAttribute("customers"));

            StringBuilder sb = new StringBuilder();

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            serializer.Serialize(new StringWriter(sb), customers, ns);

            return sb.ToString();
        }

        // 19. Export Sales With Applied Discount
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {

            var sales = context.Sales
                .Select(e => new ExportSalesWithAppliedDiscountDto
                {
                    Car = new ExportCarsAttributeDto
                    {
                        Make = e.Car.Make,
                        Model = e.Car.Model,
                        TravelledDistance = e.Car.TravelledDistance
                    },
                    Discount = e.Discount,
                    CustomerName = e.Customer.Name,
                    Price = e.Car.PartCars.Sum(p => p.Part.Price),
                    PriceWithDiscount = ((e.Car.PartCars.Sum(p => p.Part.Price) * (1 - e.Discount / 100))).ToString().TrimEnd('0'),
                })
                .ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(ExportSalesWithAppliedDiscountDto[]),
                new XmlRootAttribute("sales"));

            StringBuilder sb = new StringBuilder();

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            serializer.Serialize(new StringWriter(sb), sales, ns);

            return sb.ToString();
        }
    }

}