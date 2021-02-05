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
    [Route("employees")]
    public class EmployeesController : ControllerBase
    {

        private readonly ILogger<EmployeesController> _logger;
        private readonly IEmployeesRepo _employeesRepo;

        public EmployeesController(
            ILogger<EmployeesController> logger,
            IEmployeesRepo employeesRepo
            )
        {
            _logger = logger;
            _employeesRepo = employeesRepo;
        }

        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return _employeesRepo.getEmployees();
        }
        [HttpGet]
        [Route("{id}")]
        public Employee GetById(string id)
        {
            return _employeesRepo.getEmployee(id);
        }
    }
}
