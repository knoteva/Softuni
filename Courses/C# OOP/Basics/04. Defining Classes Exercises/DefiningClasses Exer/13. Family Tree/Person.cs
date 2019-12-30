using System.Collections.Generic;

namespace FamilyTree
{
    public class Person
    {
        private string name;
        private string birthday;
        private List<Person> parents;
        private List<Person> children;

        public Person(string name, string birthday)
        {
            Name = name;
            Birthday = birthday;
            Parents = new List<Person>();
            Children = new List<Person>();
        }

        public string Name { get => name; set => name = value; }
        public string Birthday { get => birthday; set => birthday = value; }
        public List<Person> Parents { get => parents; set => parents = value; }
        public List<Person> Children { get => children; set => children = value; }
    }
}
