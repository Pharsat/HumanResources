namespace HumanResources.Util.ConfigurationManager
{
    using System.Configuration;
    using System.Linq;

    public static class RepositoryManager
    {
        public static string SwaggerBaseUri()
        {
            return ConfigurationManager.AppSettings.GetValues("SwaggerBaseUri").FirstOrDefault();
        }

        public static string SwaggerGetAllData()
        {
            return ConfigurationManager.AppSettings.GetValues("SwaggerGetAllData").FirstOrDefault();
        }

        public static string HumanResourcesWebApiBaseUri()
        {
            return ConfigurationManager.AppSettings.GetValues("HumanResourcesWebApiBaseUri").FirstOrDefault();
        }

        public static string HumanResourcesWebApiGetAllEmployees()
        {
            return ConfigurationManager.AppSettings.GetValues("HumanResourcesWebApiGetAllEmployees").FirstOrDefault();
        }

        public static string HumanResourcesWebApiGetEmployeeById()
        {
            return ConfigurationManager.AppSettings.GetValues("HumanResourcesWebApiGetEmployeeById").FirstOrDefault();
        }
    }
}