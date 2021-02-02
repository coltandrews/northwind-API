using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using northwindAPI.BusinessLogic;
using northwindAPI.model;


namespace northwindAPI.Controllers
{
    [ApiController]
    [Route("/employees")]
    public class EmployeesController : ControllerBase
    {
        Database db = new Database();

        private readonly ILogger<EmployeesController> _logger;

        public EmployeesController(ILogger<EmployeesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            using (EmployeesRepo repo = new EmployeesRepo())
            {
                return repo.getEmployees();
            }
        }
        [HttpGet]
        [Route("/{id}")]
        public IEnumerable<Employee> GetById(string id)
        {
            using (EmployeesRepo repo = new EmployeesRepo())
            {
                return repo.getEmployees();
            }
        }
    }
}
