using System;
using System.Collections.Generic;
using System.Text;

namespace _06.BirthdayCelebrations
{
    class Citizen : IIdentifiable, IBirthable
    {
        public Citizen(string name, int age, string id, string birthday)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthday = birthday;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }
        public string Birthday { get; set; }
       
    }
}
