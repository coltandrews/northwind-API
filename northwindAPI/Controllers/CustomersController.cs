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
    [Route("/customers")]
    public class CustomersController : ControllerBase
    {
        Database db = new Database();

        private readonly ILogger<EmployeesController> _logger;

        public CustomersController(ILogger<EmployeesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            using (CustomersRepo repo = new CustomersRepo())            {
                return repo.getCustomers();
            }
        }
    }
}
