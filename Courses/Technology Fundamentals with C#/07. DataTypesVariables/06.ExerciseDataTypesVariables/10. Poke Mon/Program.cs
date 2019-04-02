using System;

namespace _10._Poke_Mon
{
    class Program
    {
        static void Main(string[] args)
        {
            int nPokePowerOriginal = int.Parse(Console.ReadLine());
            int nPokePower = nPokePowerOriginal;
            int mDistance = int.Parse(Console.ReadLine()); 
            int yExhaustionFactor = int.Parse(Console.ReadLine());
            int count = 0;
            while (nPokePower >= mDistance)
            {
                nPokePower -= mDistance;
                count++;
                if (nPokePower * 2 == nPokePowerOriginal && yExhaustionFactor!=0)
                {
                    nPokePower /= yExhaustionFactor;
                }
            }
            Console.WriteLine(nPokePower);
            Console.WriteLine(count);
        }
    }
}
