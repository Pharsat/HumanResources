namespace HumanResources.Entities
{
    using Newtonsoft.Json;

    public class HourlyContract : Contract, IContract
    {
        public int Salary { get; set; }
    }
}