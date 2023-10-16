namespace SoftUniKindergarten
{
    public class Child
    {
        private string firstName;
        private string lastName;
        private int age;
        private string parentName;
        private string contactNumber;

        public Child(string firstName, string lastName, int age, string parentName, string contactNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            ParentName = parentName;
            ContactNumber = contactNumber;
        }

        public string FirstName
        {
            get => firstName;
            private set { firstName = value; }
        }

        public string LastName
        {
            get => lastName;
            private set { lastName = value; }
        }

        public int Age
        {
            get => age;
            private set { age = value; }
        }
        public string ParentName
        {
            get => parentName;
            private set { parentName = value; }
        }


        public string ContactNumber
        {
            get => contactNumber;
            private set { contactNumber = value; }
        }

        public override string ToString()
            => $"Child: {this.firstName} {this.lastName}, Age: {this.age}, Contact info: {this.parentName} - {this.contactNumber}";
    }
}
