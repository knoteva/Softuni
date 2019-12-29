using System;
using System.Collections.Generic;
using System.Text;

namespace AquaShop.Models.Decorations
{
    public class Ornament : Decoration
    {
        private const int initialComfort = 1;
        private const decimal initialPrice = 5;

        public Ornament() 
            : base(initialComfort, initialPrice)
        {
        }
    }
}
