namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.salary = salary;
        }

        public string FirstName { get => firstName; }
        public string LastName { get => lastName; }
        public int Age { get => age; }
        public decimal Salary { get => salary; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {this.Salary:F2} leva.";
        }

        public void IncreaseSalary(decimal perc)
        {
            if (this.Age > 30)
            {
                this.salary += this.salary * perc / 100;
            }
            else
            {
                this.salary += this.salary * perc / 200;
            }
        }
    }
}
