using System;

namespace ValidPerson
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                Person person = new Person("Gosho", "Gosho Goshev", 123);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
