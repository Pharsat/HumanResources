namespace HumanResources.Dao
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using HumanResources.Entities;
    using HumanResources.Util;
    using HumanResources.Util.ConfigurationManager;
    using Newtonsoft.Json;

    public class BrokerHumanResourcesWebApi : IDisposable
    {
        private static HttpClient client;

        private bool disposed = false;

        public BrokerHumanResourcesWebApi()
        {
            client = new HttpClient()
            {
                BaseAddress = new Uri(RepositoryManager.HumanResourcesWebApiBaseUri())
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IList<Employee>> GetAll()
        {
            HttpResponseMessage response = await client.GetAsync(RepositoryManager.HumanResourcesWebApiGetAllEmployees());
            if (response.IsSuccessStatusCode)
            {
                response.EnsureSuccessStatusCode();
                string result = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<IList<Employee>>(result, new JsonSerializerSettings
                {
                    Converters = new List<JsonConverter> { new JsonTypeMapper<IContract, HourlyContract>(), new JsonTypeMapper<IContract, MonthlyContract>() }
                });
            }
            else
            {
                return null;
            }
        }

        public async Task<Employee> GetById(int id)
        {
            HttpResponseMessage response = await client.GetAsync(string.Format(RepositoryManager.HumanResourcesWebApiGetEmployeeById(), id));
            if (response.IsSuccessStatusCode)
            {
                response.EnsureSuccessStatusCode();
                string result = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<Employee>(result, new JsonSerializerSettings
                {
                    Converters = new List<JsonConverter> { new JsonTypeMapper<IContract, HourlyContract>(), new JsonTypeMapper<IContract, MonthlyContract>() }
                });
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