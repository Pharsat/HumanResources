namespace HumanResources.Mvc.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class EmployeeSearchViewModel
    {
        [Display(Name = "Id to search")]
        public int? IdEmployee { get; set; }

        [Display(Name = "Search results")]
        [UIHint("EmployeesList")]
        public IEnumerable<EmployeeViewModel> EmployeeResultsTable { get; set; }
    }
}