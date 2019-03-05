namespace HumanResources.Mvc.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using HumanResources.Business;
    using HumanResources.Dao;
    using HumanResources.Entities;
    using HumanResources.Mvc.Models;

    public class EmployeeController : Controller
    {
        public ActionResult Index()
        {
            return View(new EmployeeSearchViewModel());
        }

        [HttpPost]
        public async Task<ActionResult> Index(EmployeeSearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (BrokerHumanResourcesWebApi brokerHumanResourcesWebApi = new BrokerHumanResourcesWebApi())
                {
                    SalaryBusiness salaryBusiness = new SalaryBusiness();
                    if (!model.IdEmployee.HasValue)
                    {
                        //Mappping can be merged.
                        model.EmployeeResultsTable = (from employee in await brokerHumanResourcesWebApi.GetAll()
                                                      select new EmployeeViewModel
                                                      {
                                                          AnnualSalary = employee.Contract is HourlyContract
                                                          ? salaryBusiness.CalculateHourlySalaryAnnualSalary(employee.Contract.Salary)
                                                          : employee.Contract is MonthlyContract
                                                          ? salaryBusiness.CalculateMontlySalaryAnnualSalary(employee.Contract.Salary) : (decimal?)null,
                                                          ContractName = employee.Contract.Name,
                                                          NameEmployee = employee.Name,
                                                          RoleName = employee.Role.Name
                                                      }).ToList();
                    }
                    else
                    {
                        //Mappping can be merged.
                        Employee employee = await brokerHumanResourcesWebApi.GetById(model.IdEmployee.Value);
                        model.EmployeeResultsTable = employee != null ? new List<EmployeeViewModel> { new EmployeeViewModel {
                            AnnualSalary = employee.Contract is HourlyContract
                                                          ? salaryBusiness.CalculateHourlySalaryAnnualSalary(employee.Contract.Salary)
                                                          : employee.Contract is MonthlyContract
                                                          ? salaryBusiness.CalculateMontlySalaryAnnualSalary(employee.Contract.Salary) : (decimal?)null,
                                                          ContractName = employee.Contract.Name,
                                                          NameEmployee = employee.Name,
                                                          RoleName = employee.Role.Name
                        } } : null;
                    }
                }
                return View(model);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}