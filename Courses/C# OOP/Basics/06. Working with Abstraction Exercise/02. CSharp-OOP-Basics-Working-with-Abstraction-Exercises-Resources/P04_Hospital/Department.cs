using System.Collections.Generic;

namespace P04_Hospital
{
    public class Department
    {
        private string name;
        private List<Room> rooms;

        public Department(string name)
        {
            Name = name;
            Rooms = new List<Room>();
        }

        public string Name { get => name; set => name = value; }
        public List<Room> Rooms { get => rooms; set => rooms = value; }

       
    }
}
