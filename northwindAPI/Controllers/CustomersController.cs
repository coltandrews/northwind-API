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
        ICustomersRepo _customersDb;
        private readonly ILogger<EmployeesController> _logger;

        public CustomersController(
            ILogger<EmployeesController> logger,
            ICustomersRepo customersRepo)
        {
            _logger = logger;
            _customersDb = customersRepo;
        }

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _customersDb.getCustomers();
        }
    }
}
