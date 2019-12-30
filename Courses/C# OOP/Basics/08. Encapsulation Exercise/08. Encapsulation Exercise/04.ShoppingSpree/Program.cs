namespace ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        static void Main(string[] args)
        {
            string[] peopleInfoPairs = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            string[] productsInfoPairs = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);

            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            try
            {
                for (int i = 0; i < peopleInfoPairs.Length; i++)
                {
                    var person = new Person(peopleInfoPairs[i].Split("=")[0], decimal.Parse(peopleInfoPairs[i].Split("=")[1]));
                    people.Add(person);
                }

                for (int i = 0; i < productsInfoPairs.Length; i++)
                {
                    var product = new Product(productsInfoPairs[i].Split("=")[0], decimal.Parse(productsInfoPairs[i].Split("=")[1]));
                    products.Add(product);
                }             
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            var command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                string currName = command.Split(" ")[0];
                string currproduct = command.Split(" ")[1];
                people.FirstOrDefault(p => p.Name == currName).AddProduct(products.FirstOrDefault(p => p.Name == currproduct));
            }

           people.ForEach(p => Console.WriteLine(p.ToString()));
        }
    }
}
