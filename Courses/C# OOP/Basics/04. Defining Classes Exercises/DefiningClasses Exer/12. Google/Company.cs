namespace Google
{
    public class Company
    {
        private string companyName;
        private string department;
        private decimal salary;

        public Company(string companyName, string department, decimal salary)
        {
            CompanyName = companyName;
            Department = department;
            Salary = salary;
        }

        public string CompanyName { get => companyName; set => companyName = value; }
        public string Department { get => department; set => department = value; }
        public decimal Salary { get => salary; set => salary = value; }

        public override string ToString()
        {
            return $"{CompanyName} {Department} {Salary:F2}";
        }
    }
}
