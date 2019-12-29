namespace Google
{
    public class Child
    {
        private string childName;
        private string childBirthday;

        public Child(string childName, string childBirthday)
        {
            ChildName = childName;
            ChildBirthday = childBirthday;
        }

        public string ChildName { get => childName; set => childName = value; }
        public string ChildBirthday { get => childBirthday; set => childBirthday = value; }

        public override string ToString()
        {
            return $"{ChildName} {childBirthday}";
        }
    }
}
