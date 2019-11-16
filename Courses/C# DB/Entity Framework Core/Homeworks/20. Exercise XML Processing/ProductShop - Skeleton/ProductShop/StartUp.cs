using System;
using AutoMapper;
using ProductShop.Data;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Linq;
using ProductShop.Dtos.Export;
using System.Text;
using System.Xml;
using AutoMapper.QueryableExtensions;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<ProductShopProfile>();
            });

            var context = new ProductShopContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();


            //// 01. Import Users          
            //var usersXml = File.ReadAllText("../../../Datasets/users.xml");
            //var usersResult = ImportUsers(context, usersXml);
            //Console.WriteLine(usersResult);

            //// 02. Import Products
            //var productsXml = File.ReadAllText("../../../Datasets/products.xml");
            //var productsResult = ImportProducts(context, productsXml);
            //Console.WriteLine(productsResult);

            //// 03. Import Categories
            //var categoriesXml = File.ReadAllText("../../../Datasets/categories.xml");
            //var categoriesResult = ImportCategories(context, categoriesXml);
            //Console.WriteLine(categoriesResult);

            //// 04.Import Categories and Products
            //var categoriesProductsXml = File.ReadAllText("../../../Datasets/categories-products.xml");
            //var categoriesProductsResult = ImportCategoryProducts(context, categoriesProductsXml);
            //Console.WriteLine(categoriesProductsResult);

            //// 05. Export Products In Range
            //Console.WriteLine(GetProductsInRange(context));

            //// 06. Export Sold Products
            //Console.WriteLine(GetSoldProducts(context));

            //// 07. Export Categories By Products Count
            //Console.WriteLine(GetCategoriesByProductsCount(context));

            //// 08.Export Users and Products
            Console.WriteLine(GetUsersWithProducts(context));
        }

        // 01. Import Users
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportUserDto[]), new XmlRootAttribute("Users"));
            var usersDto = (ImportUserDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            List<User> users = new List<User>();
            foreach (var userDto in usersDto)
            {
                var user = Mapper.Map<User>(userDto);
                users.Add(user);
            }
            context.Users.AddRange(users);
           int count = context.SaveChanges();
            return $"Successfully imported {count}";

        }

        // 02. Import Products
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportProductDto[]), new XmlRootAttribute("Products"));
            var productsDto = (ImportProductDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var products = new List<Product>();
            foreach (var productDto in productsDto)
            {
                var product = Mapper.Map<Product>(productDto);
                products.Add(product);
            }
            context.Products.AddRange(products);
            int count = context.SaveChanges();
            return $"Successfully imported {count}";
        }

        // 03. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCategoryDto[]), new XmlRootAttribute("Categories"));
            var categoriesDto = (ImportCategoryDto[])xmlSerializer.Deserialize(new StringReader(inputXml));

            var categories = new List<Category>();
            foreach (var categoryDto in categoriesDto)
            {
                var category = Mapper.Map<Category>(categoryDto);
                categories.Add(category);
            }
            context.Categories.AddRange(categories);
            int count = context.SaveChanges();
            return $"Successfully imported {count}";
        }

        // 04. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportCategoryProductsDto[]),
                new XmlRootAttribute("CategoryProducts"));
            var categoryProductsDto =
                ((ImportCategoryProductsDto[])xmlSerializer.Deserialize(new StringReader(inputXml)))
                .ToList();

            var categoryProducts = new List<CategoryProduct>();

            foreach (var categoryProductDto in categoryProductsDto)
            {
                var targetProduct = context.Products.Find(categoryProductDto.ProductId);
                var targetCategory = context.Categories.Find(categoryProductDto.CategoryId);

                //if (targetProduct != null && targetCategory != null)
                //{
                    var category = Mapper.Map<CategoryProduct>(categoryProductDto);
                    categoryProducts.Add(category);
                //}
            }

            context.CategoryProducts.AddRange(categoryProducts);
            int count = context.SaveChanges();

            return $"Successfully imported {count}";
        }

        // 05. Export Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            var productsInRange = context.Products
                    .Where(p => p.Price >= 500 && p.Price <= 1000)
                    .Select(p => new ExportProductsInRangeDto
                    {
                        Name = p.Name,
                        Price = p.Price,
                        Buyer = $"{p.Buyer.FirstName} {p.Buyer.LastName}"
                    })
                    .OrderBy(p => p.Price)
                    .Take(10)
                    .ToArray();
            var xmlSerializer =
                 new XmlSerializer(typeof(ExportProductsInRangeDto[]), new XmlRootAttribute("Products"));

            StringBuilder sb = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(sb), productsInRange, namespaces);

            return sb.ToString().TrimEnd();
        }

        // 06. Export Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            var soldProducts = context.Users
                 .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                 .Select(u => new ExportProductsSoldDto
                 {
                     FirstName = u.FirstName,
                     LastName = u.LastName,
                     Products = u.ProductsSold.Select(p => new ExportSoldProductDto
                     {
                         Name = p.Name,
                         Price = p.Price
                     })
                     .ToArray()
                 })
                 .OrderBy(u => u.LastName)
                 .ThenBy(u => u.FirstName)
                 .Take(5)
                 .ToArray();
            var xmlSerializer = new XmlSerializer(typeof(ExportProductsSoldDto[]), new XmlRootAttribute("Users"));

            var sb = new StringBuilder();
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            xmlSerializer.Serialize(new StringWriter(sb), soldProducts, namespaces);

            return sb.ToString().TrimEnd();
        }
       
        //Query 7. Categories By Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context
                .Categories
                .Select(x => new ExportCategoriesByCountDto
                {
                    Name = x.Name,
                    ProductsCount = x.CategoryProducts.Count,
                    AveragePrice = x.CategoryProducts.Select(a => a.Product.Price).Average(),
                    TotalRevenue = x.CategoryProducts.Select(а => а.Product.Price).Sum()
                })
                .OrderByDescending(x => x.ProductsCount)
                .ThenBy(x => x.TotalRevenue)
                .ToArray();

            var sb = new StringBuilder();

            var serializer = new XmlSerializer(typeof(ExportCategoriesByCountDto[]), new XmlRootAttribute("Categories"));
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });

            serializer.Serialize(new StringWriter(sb), categories, namespaces);

            return sb.ToString().TrimEnd();
        }

        //Query 8. Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(x => x.ProductsSold.Any())
                .Select(x => new ExportUserAndProductDto
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    SoldProductDto = new SoldProductDto
                    {
                        Count = x.ProductsSold.Count,
                        ProductDtos = x.ProductsSold.Select(p => new ProductDto()
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .OrderByDescending(p => p.Price)
                        .ToArray()
                    }
                })
                .OrderByDescending(x => x.SoldProductDto.Count)
                .Take(10)
                .ToArray();

            var customExport = new ExportCustomUserProductDto
            {
                Count = context.Users.Count(x => x.ProductsSold.Any()),
                ExportUserAndProductDto = users
            };

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ExportCustomUserProductDto), new XmlRootAttribute("Users"));

            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var sb = new StringBuilder();

            xmlSerializer.Serialize(new StringWriter(sb), customExport, namespaces);

            return sb.ToString().TrimEnd();
        }


    }
}