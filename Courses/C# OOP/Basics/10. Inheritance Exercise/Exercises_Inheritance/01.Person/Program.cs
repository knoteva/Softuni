using System;

namespace Person
{
    public class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());

            try
            {
                //var person = new Person(name, age);
                //Console.WriteLine(person);
                Child child = new Child(name, age);
                Console.WriteLine(child);


            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }

        }
    }
}
