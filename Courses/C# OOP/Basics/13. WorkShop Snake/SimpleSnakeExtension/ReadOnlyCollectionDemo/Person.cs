using System;
using System.Collections.Generic;
using System.Text;

namespace ReadOnlyCollectionDemo
{
    public class Person
    {
        private string name;
        private List<Car> cars;

        public Person(string name)
        {
            this.Name = name;
        }

        public IReadOnlyCollection<Car> Cars => this.cars.AsReadOnly();

        public void AddCar(Car car)
        {
            //logic
            this.cars.Add(car);
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}
