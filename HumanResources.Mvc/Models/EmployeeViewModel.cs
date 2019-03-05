namespace HumanResources.Mvc.Models
{
    using System.ComponentModel.DataAnnotations;

    public class EmployeeViewModel
    {
        [Display(Name = "Name")]
        public string NameEmployee { get; set; }

        [Display(Name = "ContratType")]
        public string ContractName { get; set; }

        [Display(Name = "Role")]
        public string RoleName { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [Display(Name = "Annual Salary")]
        public decimal? AnnualSalary { get; set; }
    }
}