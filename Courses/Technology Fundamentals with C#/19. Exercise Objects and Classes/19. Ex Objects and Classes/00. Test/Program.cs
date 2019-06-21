using System;

namespace _00._Test
{
    class Program
    {
        static void Main(string[] args)
        {
            // Инстанция(Създаване на оибект в класа. Използваме неговите пропъртита и чрез тях задаваме стойности.) на класа Human
            Human kate = new Human
            {
                name = "Kate",
                age = 20,
                gender = "female"
            };

            // Друг начин за инстанциране
                //Human kate = new Human();

                //kate.name = "Kate";
                //kate.age = 20;
                //kate.gender = "female";

            Console.WriteLine(kate.name);
            Console.WriteLine(kate.age);
            Console.WriteLine(kate.gender);
        }        
    }
    class Human
    {
        //properties: дават х-ки на обекта, който ще създадем впоследствие 
        public string name; 
        public int age;
        public string gender;
    }
}
