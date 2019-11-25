using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using FastFood.Data;
using FastFood.DataProcessor.Dto.Import;
using FastFood.Models;
using FastFood.Models.Enums;
using Newtonsoft.Json;

namespace FastFood.DataProcessor
{
    public static class Deserializer
    {
        private const string FailureMessage = "Invalid data format.";
        private const string SuccessMessage = "Record {0} successfully imported.";

        public static string ImportEmployees(FastFoodDbContext context, string jsonString)
        {
            var employeesDto = JsonConvert.DeserializeObject<ImportEmployeesDto[]>(jsonString);
            var sb = new StringBuilder();
            var employees = new List<Employee>();

            foreach (var employeeDto in employeesDto)
            {
                if (!IsValid(employeeDto))
                {
                    sb.AppendLine($"{FailureMessage}");
                    continue;
                }

                var employee = new Employee
                {
                    Name = employeeDto.Name,
                    Age = employeeDto.Age,

                };

                var position = GetPosition(context, employeeDto.Position);

                employee.Position = (Position)position;

                employees.Add(employee);
                sb.AppendLine($"{$"Record {employee.Name} successfully imported."}");
            }
            context.Employees.AddRange(employees);
            context.SaveChanges();
            return sb.ToString().TrimEnd();

        }

        private static object GetPosition(FastFoodDbContext context, string employeeDtoPosition)
        {
            var position = context.Positions.FirstOrDefault(x => x.Name == employeeDtoPosition);
            if (position == null)
            {
                position = new Position
                {
                    Name = employeeDtoPosition
                };
                context.Positions.Add(position);
                context.SaveChanges();
            }
            return position;
        }



        public static string ImportItems(FastFoodDbContext context, string jsonString)
        {
            var itemsDto = JsonConvert.DeserializeObject<ImportItemsDto[]>(jsonString);
            var sb = new StringBuilder();
            var items = new List<Item>();

            foreach (var itemDto in itemsDto)
            {
                if (!IsValid(itemDto))
                {
                    sb.AppendLine($"{FailureMessage}");
                    continue;
                }

                var item = new Item
                {
                    Name = itemDto.Name,
                    Price = itemDto.Price

                };
                var category = GetCategory(context, itemDto.Category);

                item.Category = (Category)category;
                var a = true;
                foreach (var i in items)
                {
                    if (i.Name == item.Name)
                    {
                        a = false;
                        sb.AppendLine($"{FailureMessage}");
                        break;
                    }
                }
                if (a)
                {
                    items.Add(item);
                    sb.AppendLine($"{$"Record {item.Name} successfully imported."}");
                }

            }
            context.Items.AddRange(items);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        private static object GetCategory(FastFoodDbContext context, string itemDtoCategory)
        {
            var category = context.Categories.FirstOrDefault(x => x.Name == itemDtoCategory);
            if (category == null)
            {
                category = new Category
                {
                    Name = itemDtoCategory
                };
                context.Categories.Add(category);
                context.SaveChanges();
            }
            return category;
        }


        public static string ImportOrders(FastFoodDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(ImportOrdersDto[]), new XmlRootAttribute("Orders"));
            var ordersDto = (ImportOrdersDto[])xmlSerializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();
            var orders = new List<Order>();

            foreach (var orderDto in ordersDto)
            {
                if (!IsValid(orderDto))
                {
                    sb.AppendLine($"{FailureMessage}");
                    continue;
                }

                var isValidEnumType = Enum.TryParse<OrderType>(orderDto.Type, out OrderType orderType);
                if (!isValidEnumType)
                {
                    sb.AppendLine($"{FailureMessage}");
                    continue;
                }
                var orderItems = new List<OrderItem>();

                foreach (var i in orderDto.Items)
                {
                    orderItems.Add(new OrderItem()
                    {
                        Item = context.Items.Single(it => it.Name == i.Name),
                        Quantity = i.Quantity
                    });
                }
      
                var employee = context.Employees.FirstOrDefault(x => x.Name == orderDto.Employee);
        

                var order = new Order
                {
                    Customer = orderDto.Customer,
                    DateTime = DateTime.ParseExact(orderDto.DateTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                    Type = orderType,
                    Employee = employee,
                    OrderItems = orderItems
                };

                order.Employee = employee;

                orders.Add(order);              
                
                sb.AppendLine($"Order for {orderDto.Customer} on {orderDto.DateTime} added");
            }

            context.Orders.AddRange(orders);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object entity)
        {
            var validationContext = new ValidationContext(entity);
            var validationResult = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(entity, validationContext, validationResult, true);
            return isValid;
        }
    }
}