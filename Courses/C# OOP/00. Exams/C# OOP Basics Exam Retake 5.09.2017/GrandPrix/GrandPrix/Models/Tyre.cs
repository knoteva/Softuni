using HardTyre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HardTyre.Models
{
    public abstract class Tyre : ITyre
    {
        private string name;

        private double hardness;

        private double degradation;

        protected Tyre(string name, double hardness, double degradation)
        {
            Name = name;
            Hardness = hardness;
            Degradation = 100;
        }

        public string Name { get => name; set => name = value; }
        public double Hardness { get => hardness; set => hardness = value; }
        public double Degradation { get => degradation; set => degradation = value; }
    }
}
