using System.Collections.Generic;

namespace Google
{
    public class Person
    {
        private string name;
        private Company company;
        private List<Pokemon> pokemon;
        private List<Parent> parent;
        private List<Child> child;
        private Car car;

        public Person(string name)
        {
            this.Name = name;
            this.Parent = new List<Parent>();
            this.Child = new List<Child>();
            this.Pokemon = new List<Pokemon>();
            this.Car = null;
            this.Company = null;
        }

        public string Name { get => name; set => name = value; }
        public Company Company { get => company; set => company = value; }
        public List<Pokemon> Pokemon { get => pokemon; set => pokemon = value; }
        public List<Parent> Parent { get => parent; set => parent = value; }
        public List<Child> Child { get => child; set => child = value; }
        public Car Car { get => car; set => car = value; }
    }
}
