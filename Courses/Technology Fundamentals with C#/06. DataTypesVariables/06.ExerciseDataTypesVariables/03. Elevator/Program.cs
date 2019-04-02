using System;

namespace _03._Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int p = int.Parse(Console.ReadLine());
            int courses = (int)Math.Ceiling((double)n / p);
            int fullCourses = n / p;
            int partiallyFullCourse = 0;
            if (n % p != 0)
            {
                partiallyFullCourse = n % p;
            }
            Console.WriteLine(courses);
        
        }
    }
}
