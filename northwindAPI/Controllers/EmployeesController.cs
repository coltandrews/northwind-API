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
        public IEnumerable<Employee> GetAll()
        {
            return _employeesRepo.getEmployees();
        }

        [HttpPost]
        public ActionResult<Employee> AddEmployee([FromBody] Employee emp)
        {
            try
            {
                return _employeesRepo.addEmployee(emp);
            }
            catch (ApiException apiEx) when (apiEx.HttpStatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                // validation error
                return BadRequest(apiEx.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Employee> GetById(string id)
        {            
            var emp = _employeesRepo.getEmployeeById(id);
            if (emp == null) {
                return NotFound();
            }
            return emp;
        }

        [HttpPatch]
        [Route("{id}")]
        public ActionResult<Employee> UpdateEmployee([FromBody] Employee emp)
        {
            try
            {
                return _employeesRepo.updateEmployee(emp);
            }
            catch (ApiException apiEx) when (apiEx.HttpStatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                // validation error (400)
                return BadRequest(apiEx.Message);
            }
            catch (ApiException apiEx) when (apiEx.HttpStatusCode == System.Net.HttpStatusCode.NotFound)
            {
                // record not found (404)
                return NotFound();
            }
        }

    }
}
