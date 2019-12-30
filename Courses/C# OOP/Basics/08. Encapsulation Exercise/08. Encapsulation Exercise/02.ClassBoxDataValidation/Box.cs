using System;

namespace ClassBox
{
    public class Box
    {
        private decimal length;
        private decimal width;
        private decimal height;

        public Box(decimal length, decimal width, decimal height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public decimal Length 
        { 
            get => length;
            private set
            {
                ValidateSide("Length", value);
                //if (value <= 0)
                //{
                //    throw new ArgumentException("Length cannot be zero or negative.");
                //}
                this.length = value;
            }
        }
        public decimal Width 
        {
            get => width;
            private set
            {
                ValidateSide("Width", value);
                //if (value <= 0)
                //{
                //    throw new ArgumentException("Width cannot be zero or negative.");
                //}
                this.width = value;
            }
        }
        public decimal Height 
        {
            get => height;
            private set
            {
                ValidateSide("Height", value);
                //if (value <= 0)
                //{
                //    throw new ArgumentException("Height cannot be zero or negative.");
                //}
                this.height = value;
            }
        }

        private void ValidateSide(string sideName, decimal value)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{sideName} cannot be zero or negative.");
                //Console.WriteLine($"{sideName} cannot be zero or negative.");
            }
        }
        public decimal SurfaceArea()
        {
            return 2* Length * Width + 2 * Length * Height + 2 * Width * Height;
        }
        public decimal LateralSurfaceArea()
        {
            return 2 * Length * Height + 2 * Width * Height;
        }
        public decimal Volume()
        {
            return Length * Width * Height;
        }
    }
}
