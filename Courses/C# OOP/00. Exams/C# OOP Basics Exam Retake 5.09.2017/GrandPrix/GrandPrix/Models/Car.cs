using HardTyre.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace HardTyre.Models
{
    public class Car : ICar
    {
        private int hp;

        private double fuelAmount;

        private ITyre tyre;

        public Car(int hp, double fuelAmount, ITyre tyre)
        {
            Hp = hp;
            FuelAmount = fuelAmount;
            Tyre = tyre;
        }

        public int Hp { get => hp; set => hp = value; }
        public double FuelAmount
        {
            get => fuelAmount; 
            set
            {
                if (value > 160)
                {
                    fuelAmount = 160;
                }
                fuelAmount = value;
            }
        }
        public ITyre Tyre { get => tyre; set => tyre = value; }
    }
}
