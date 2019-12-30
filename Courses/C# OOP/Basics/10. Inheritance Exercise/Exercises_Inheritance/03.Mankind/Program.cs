using System;

namespace _03.Mankind
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var studentInfo = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.None);
                var studentFirstName = studentInfo[0];
                var studentLastName = studentInfo[1];
                var facuktyNumber = studentInfo[2];
                var student = new Student(studentFirstName, studentLastName, facuktyNumber);               

                var workerInfo = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.None);
                var workerFirstName = workerInfo[0];
                var workerLastName = workerInfo[1];
                var workerSalary = double.Parse(workerInfo[2]);
                var workerHours = double.Parse(workerInfo[3]);
                var worker = new Worker(workerFirstName, workerLastName, workerSalary, workerHours);
                Console.WriteLine(student);
                Console.WriteLine(worker);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }

        }
    }
}
