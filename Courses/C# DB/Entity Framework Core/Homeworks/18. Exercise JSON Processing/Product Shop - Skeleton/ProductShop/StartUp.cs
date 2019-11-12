using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Dto.Export;
using ProductShop.Dtos.Exports;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var context = new ProductShopContext();
            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //// 01. Import Users
            //var userJson = File.ReadAllText(@"D:\Programing\Softuni\01. Entity Framework Core\18. Exercise JSON Processing\Product Shop - Skeleton\ProductShop\Datasets\users.json");
            //var UsersResult = ImportUsers(context, userJson);
            //Console.WriteLine(UsersResult);

            //// 02. Import Products
            //var productsJson = File.ReadAllText(@"D:\Programing\Softuni\01. Entity Framework Core\18. Exercise JSON Processing\Product Shop - Skeleton\ProductShop\Datasets\products.json");
            //var productsResult = ImportProducts(context, productsJson);
            //Console.WriteLine(productsResult);

            //// 03. Import Categories
            //var categoriesJson = File.ReadAllText(@"D:\Programing\Softuni\01. Entity Framework Core\18. Exercise JSON Processing\Product Shop - Skeleton\ProductShop\Datasets\categories.json");
            //var categoriesResult = ImportCategories(context, categoriesJson);
            //Console.WriteLine(categoriesResult);

            //// 04. Import Categories and Products
            //var categoriesProductsJson = File.ReadAllText(@"D:\Programing\Softuni\01. Entity Framework Core\18. Exercise JSON Processing\Product Shop - Skeleton\ProductShop\Datasets\categories-products.json");
            //var categoriesProducts = ImportCategoryProducts(context, categoriesProductsJson);
            //Console.WriteLine(categoriesProducts);

            //// 05. Export Products In Range
            //Console.WriteLine(GetProductsInRange(context));

            //// 06. Export Sold Products
            //Console.WriteLine(GetSoldProducts(context));

            //// 07. Export Categories By Products Count
            //Console.WriteLine(GetCategoriesByProductsCount(context));

            //// 08. Export Users and Products
            Console.WriteLine(GetUsersWithProducts(context));

        }

        // 01. Import Users
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<User[]>(inputJson)
                .Where(u => u.LastName != null && u.LastName.Length >= 3)
                .ToList();
            context.Users.AddRange(users);
            context.SaveChanges();
            return $"Successfully imported {users.Count}";
        }

        // 02. Import Products
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<Product[]>(inputJson)
                    .Where(p => p.Name.Length >= 3 && p.Name != null)
                    .ToArray();
            context.Products.AddRange(products);
            context.SaveChanges();
            return $"Successfully imported {products.Length}";
        }

        // 03. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert.DeserializeObject<Category[]>(inputJson)
                    .Where(c => c.Name != null && c.Name.Length >= 3 && c.Name.Length <= 15)
                    .ToArray();
            context.Categories.AddRange(categories);
            context.SaveChanges();
            return $"Successfully imported {categories.Length}";
        }

        // 04. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoriesProducts = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson)
                      .ToArray();
            context.CategoryProducts.AddRange(categoriesProducts);
            context.SaveChanges();
            return $"Successfully imported {categoriesProducts.Length}";
        }

        // 05. Export Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            var productsInRange = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p => new ProductDto
                {
                    Name = p.Name,
                    Price = p.Price,
                    Seller = $"{p.Seller.FirstName} {p.Seller.LastName}"
                })
                .OrderBy(p => p.Price)
                .ToList();

            var jsonProduct = JsonConvert.SerializeObject(productsInRange, Formatting.Indented);

            return jsonProduct;

        }

        // 06. Export Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            var soldProducts = context.Users
                 .Where(u => u.ProductsSold.Any(ps => ps.Buyer != null))
                 .Select(u => new
                 {
                     firstName = u.FirstName,
                     lastName = u.LastName,
                     soldProducts = u.ProductsSold
                     .Where(ps => ps.Buyer != null)
                     .Select(ps => new
                     {
                         name = ps.Name,
                         price = ps.Price,
                         buyerFirstName = ps.Buyer.FirstName,
                         buyerLastName = ps.Buyer.LastName

                     })
                 })

                 .OrderBy(u => u.lastName)
                 .ThenBy(u => u.firstName)
                 .ToList();

            var jsonSoldProducts = JsonConvert.SerializeObject(soldProducts, Formatting.Indented);
            return jsonSoldProducts;
        }

        // 07. Export Categories By Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categoriesByProductsCount = context.Categories               
                .Select(x => new
                {
                    category = x.Name,
                    productsCount = x.CategoryProducts.Count(),
                    averagePrice = $@"{x.CategoryProducts
                    .Sum(p => p.Product.Price) / x.CategoryProducts.Count():F2}",
                   totalRevenue = $"{x.CategoryProducts.Sum(p => p.Product.Price):F2}"
                })
                .OrderByDescending(x => x.productsCount)
                .ToList();

                var jsonCategoriesByProductsCount = JsonConvert.SerializeObject(categoriesByProductsCount, Formatting.Indented);
            return jsonCategoriesByProductsCount;
        }

        // 08. Export Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderByDescending(p => p.ProductsSold.Count(ps => ps.Buyer != null))
                .Select(u => new UserWithProductsDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new SoldProductsToUserDto
                    {
                        Count = u.ProductsSold.Count(p => p.Buyer != null),
                        Products = u.ProductsSold
                        .Where(p => p.Buyer != null)
                        .Select(p => new SoldProductsDto
                        {
                            Name = p.Name,
                            Price = p.Price
                        })
                        .ToList()
                    }
                })
                .ToList();

            var result = new UsersAndProductsDto
            {
                UsersCount = users.Count(),
                Users = users
            };

            var json = JsonConvert.SerializeObject(result,
                Formatting.Indented,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });

            return json;
        }
    }

}