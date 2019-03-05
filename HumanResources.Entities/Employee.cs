namespace HumanResources.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IContract Contract { get; set; }

        public Role Role { get; set; }
    }
}