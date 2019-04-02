using System;

namespace _10.RageExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGamesCount = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());
            int headsetTrash = 0;
            int mouseTrash = 0;
            int keyboardTrash = 0;
            int displayTrash = 0;
            double totalrice = 0;
            int keyBM = 0;
            for (int i = lostGamesCount; i >= 1; i--)
            {
                if (i % 2 == 0)
                {
                    headsetTrash++;
                }
                if (i % 3 == 0)
                {
                    mouseTrash++;
                }
                if (i % 2 == 0 && i % 3 == 0)
                {
                    keyboardTrash++;
                    keyBM++;
                }
                if (keyBM % 2 == 0 && keyBM != 0)
                {
                    displayTrash++;
                    keyBM = 0;
                }
            }
            totalrice = headsetPrice * headsetTrash + mousePrice * mouseTrash + keyboardPrice * keyboardTrash + displayPrice * displayTrash;
            //Console.WriteLine(headsetTrash);
            //Console.WriteLine(mouseTrash);
            //Console.WriteLine(keyboardTrash);
            //Console.WriteLine(displayTrash);
            Console.WriteLine($"Rage expenses: {totalrice:F2} lv.");
            
        }
    }
}
