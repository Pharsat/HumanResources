namespace HumanResources.Business
{
    public class SalaryBusiness
    {
        public decimal CalculateHourlySalaryAnnualSalary(int hourlySalary)
        {
            return 120 * hourlySalary * 12;
        }

        public decimal CalculateMontlySalaryAnnualSalary(int monthtlySalary)
        {
            return monthtlySalary * 12;
        }
    }
}