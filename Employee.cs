namespace designIssueExample
{
    internal class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsSalaried { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name} {Age} {IsSalaried}";
        }
    }
}