using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Person
    {
        // Полета(fields)
        private string name;
        private int age;


        //Конструктор 1
        public Person()
        {
            this.Name = "No name";
            this.Age = 1;
        }

        //Конструктор 2
        public Person(int age)
            : this()
        {
            this.Age = age;
        }

        //Конструктор
        public Person(string name, int age)
            :this(age)
        {
            this.Name = name;
        }

        // Гетъри и сетъри
       public string Name
        {
            get => this.name;
            set => this.name = value;
        }
        public int Age 
        { 
            get => this.age; 
            set => this.age = value; 
        }        
    }
}
