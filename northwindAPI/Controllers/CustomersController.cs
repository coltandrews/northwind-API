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
    [Route("customers")]
    public class CustomersController : ControllerBase
    {
        ICustomersRepo _customersRepo;
        private readonly ILogger<EmployeesController> _logger;

        public CustomersController(
            ILogger<EmployeesController> logger,
            ICustomersRepo customersRepo)
        {
            _logger = logger;
            _customersRepo = customersRepo;
        }

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _customersRepo.getCustomers();
        }
        [HttpGet]
        [Route("{id}")]
        public Customer GetById(string id)
        {
            return _customersRepo.getCustomer(id);
        }
    }
}
