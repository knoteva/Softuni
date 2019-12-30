namespace Google
{
    public class Parent
    {
        private string parentName;
        private string parentBirthday;

        public Parent(string parentName, string parentBirthday)
        {
            ParentName = parentName;
            ParentBirthday = parentBirthday;
        }

        public string ParentName { get => parentName; set => parentName = value; }
        public string ParentBirthday { get => parentBirthday; set => parentBirthday = value; }

        public override string ToString()
        {
            return $"{parentName} {ParentBirthday}";
        }
    }
}
