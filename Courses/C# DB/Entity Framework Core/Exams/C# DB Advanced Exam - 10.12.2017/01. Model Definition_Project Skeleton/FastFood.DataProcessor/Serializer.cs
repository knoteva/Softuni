using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using FastFood.Data;
using FastFood.DataProcessor.Dto.Export;
using FastFood.Models.Enums;
using Newtonsoft.Json;

namespace FastFood.DataProcessor
{
	public class Serializer
	{
		public static string ExportOrdersByEmployee(FastFoodDbContext context, string employeeName, string orderType)
		{
            //var type = Enum.Parse<OrderType>(orderType);
            var isValidEnum = Enum.TryParse<OrderType>(orderType, out OrderType type);
            var orders = context.Orders
                .Where(o => o.Employee.Name == employeeName && o.Type == type)
                .Select(o => new
                {
                    Customer = o.Customer,
                    Items = o.OrderItems
                        .Select(oi => new
                        {
                            Name = oi.Item.Name,
                            Price = oi.Item.Price,
                            Quantity = oi.Quantity
                        })
                        .ToArray(),
                    TotalPrice = o.TotalPrice
                })
                .OrderByDescending(o => o.TotalPrice)
                .ThenByDescending(o => o.Items.Count())
                .ToArray();

            var employeeOrders = new
            {
                Name = employeeName,
                Orders = orders,
                TotalMade = orders.Sum(o => o.TotalPrice)
            };

            var json = JsonConvert.SerializeObject(employeeOrders, Newtonsoft.Json.Formatting.Indented);

            return json;
        }

		public static string ExportCategoryStatistics(FastFoodDbContext context, string categoriesString)
		{
            var categoryNames = categoriesString.Split(',');

            var categories = context.Categories
                .Where(c => categoryNames.Any(cn => cn == c.Name))
                .Select(c => new
                {
                    Name = c.Name,
                    MostPopularItem = c.Items
                        .OrderByDescending(i => i.OrderItems.Sum(oi => oi.Item.Price * oi.Quantity))
                        .FirstOrDefault()
                })
                .Select(c => new Dto.Export.CategoryDto
                {
                    Name = c.Name,
                    MostPopularItem = new Dto.Export.ItemDto
                    {
                        Name = c.MostPopularItem.Name,
                        TotalMade = c.MostPopularItem.OrderItems.Sum(oi => oi.Item.Price * oi.Quantity),
                        TimesSold = c.MostPopularItem.OrderItems.Sum(oi => oi.Quantity)
                    }
                })
                .OrderByDescending(c => c.MostPopularItem.TotalMade)
                .ThenByDescending(c => c.MostPopularItem.TimesSold)
                .ToArray();

            var sb = new StringBuilder();

            var serializer = new XmlSerializer(typeof(CategoryDto[]), new XmlRootAttribute("Categories"));
            serializer.Serialize(new StringWriter(sb), categories, new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty }));

            var result = sb.ToString();
            return result;
        }
	}
}