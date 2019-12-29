namespace PersonsInfo
{
    public class Person
    {
        	private string firstName;
            private string lastName;
        	private int age;

        public Person(string firstName, string lastName, int age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }

        public string FirstName { get => firstName; }
        public string LastName { get => lastName; }
        public int Age { get => age; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} is {this.Age} years old.";
        }
    }
}
