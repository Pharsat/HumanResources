using System;
using HumanResources.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HumanResources.Mvc.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MonthlyContractTypeAnnualSalaryCalculationWorks()
        {
            SalaryBusiness salaryBusiness = new SalaryBusiness();
            int montlySalary = 100;
            decimal annualSalaryExpected = 1200;
            decimal annualSalaryCalculated = salaryBusiness.CalculateMontlySalaryAnnualSalary(montlySalary);
            Assert.AreEqual(annualSalaryExpected, annualSalaryCalculated);

        }

        [TestMethod]
        public void HourlyContractTypeAnnualSalaryCalculationWorks()
        {
            SalaryBusiness salaryBusiness = new SalaryBusiness();
            int hourlySalary = 100;
            decimal annualSalaryExpected = 144000;
            decimal annualSalaryCalculated = salaryBusiness.CalculateHourlySalaryAnnualSalary(hourlySalary);
            Assert.AreEqual(annualSalaryExpected, annualSalaryCalculated);
        }
    }
}
