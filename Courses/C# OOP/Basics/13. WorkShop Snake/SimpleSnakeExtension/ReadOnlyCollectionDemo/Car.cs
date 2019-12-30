using System;
using System.Collections.Generic;
using System.Text;

namespace ReadOnlyCollectionDemo
{
    public class Car
    {
        private string model;

        public Car(string model)
        {
            this.Model = model;
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

    }
}
