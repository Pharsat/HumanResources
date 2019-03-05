namespace HumanResources.Dao
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using HumanResources.Entities;
    using HumanResources.Util.ConfigurationManager;
    using Newtonsoft.Json.Linq;

    //http://masglobaltestapi.azurewebsites.net/swagger/
    public class BrokerSwagger : IDisposable
    {
        private static HttpClient client;

        private bool disposed = false;

        public BrokerSwagger()
        {
            client = new HttpClient()
            {
                BaseAddress = new Uri(RepositoryManager.SwaggerBaseUri())
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IList<Employee>> Employees()
        {
            HttpResponseMessage response = await client.GetAsync(RepositoryManager.SwaggerGetAllData());
            if (response.IsSuccessStatusCode)
            {
                response.EnsureSuccessStatusCode();
                string result = response.Content.ReadAsStringAsync().Result;
                JArray jsonStructuredData = JArray.Parse(result);
                IList<Employee> deserializedEmployees = jsonStructuredData.Select(p => new Employee
                {
                    Id = (int)p["id"],
                    Name = (string)p["name"],
                    Contract = (string)p["contractTypeName"] == "HourlySalaryEmployee" 
                    ? (IContract)new HourlyContract { Name = (string)p["contractTypeName"], Salary = (int)p["hourlySalary"] }
                    : (string)p["contractTypeName"] == "MonthlySalaryEmployee" 
                    ? (IContract)new MonthlyContract { Name = (string)p["contractTypeName"], Salary = (int)p["monthlySalary"] }
                    : null,
                    Role = new Role {
                        Id = (int)p["roleId"],
                        Name = (string)p["roleName"],
                        Description = (string)p["roleDescription"]
                    }
                }).ToList();
                return deserializedEmployees;
            }
            else
            {
                return null;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (client != null)
                    {
                        client.Dispose();
                    }
                }
            }
            disposed = true;
        }
    }
}