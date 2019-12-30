using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private int weight;

        public Dough(string flourType, string bakingTechnique, int weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }

        public string FlourType
        {
            get => flourType; 
            set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                flourType = value.ToLower();
            }
        }
     
        public string BakingTechnique
        {
            get => bakingTechnique; 
            set
            {

                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                bakingTechnique = value.ToLower();
            }
        }

        public int Weight
        {
            get => weight; 
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                weight = value;
            }
        }

        public double DoughCalories { get => this.CalculateDoughCalories(); }

        public double CalculateDoughCalories()
        {
            double floorModifier = FlourType == "white" ? 1.5 : 1.00;
            double bakingModifier = BakingTechnique == "crispy" ? 0.9 : BakingTechnique == "chewy" ? 1.1: 1.0;
            return 2 * Weight * floorModifier * bakingModifier;
        }
    }

}
