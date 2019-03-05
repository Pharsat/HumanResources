namespace HumanResources.WebApi.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Http;
    using HumanResources.Dao;
    using HumanResources.Entities;

    [RoutePrefix("api/Employee")]
    public class EmployeeController : ApiController
    {
        [HttpGet]
        [Route("GetAll")]
        public async Task<IHttpActionResult> GetAll()
        {
            using (BrokerSwagger broker = new BrokerSwagger())
            {
                return Json(await broker.Employees());
            }
        }

         [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IHttpActionResult> GetById(int id)
        {
            using (BrokerSwagger broker = new BrokerSwagger())
            {
                IList<Employee> allEmployees = await broker.Employees();
                return Json(allEmployees.Where(p=> p.Id == id).SingleOrDefault());
            }
        }
    }
}