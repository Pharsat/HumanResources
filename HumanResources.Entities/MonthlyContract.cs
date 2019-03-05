namespace HumanResources.Entities
{
    public class MonthlyContract : Contract, IContract
    {
        public int Salary { get; set; }
    }
}