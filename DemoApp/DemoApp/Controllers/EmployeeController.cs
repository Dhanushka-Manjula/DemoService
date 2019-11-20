using DemoApp.Cache;
using DemoApp.Pojo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoApp.Controllers
{
    public class EmployeeController : ApiController
    {
        // GET: api/Employee
        [HttpGet]
        [Route("api/employee")]
        public IEnumerable<Employee> Get()
        {
            return EmplyeeCache.getInstance().getAllUsers();
        }

        // GET: api/Employee/5
        public Employee Get(string id)
        {
            return EmplyeeCache.getInstance().getByUserId(id);
        }

    }
}
