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
    [Route("products")]
    public class ProductsController : ControllerBase
    {

        private readonly ILogger<ProductsController> _logger;
        private readonly IProductsRepo _repo;

        public ProductsController(
            ILogger<ProductsController> logger,
            IProductsRepo repo
            )
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<Product> GetAll([FromQuery] string name=null, int? discontinued=null)
        {
            _logger.LogInformation($"getProducts name: {name}  discontinued: {discontinued}");

            return _repo.getAll(name, discontinued);

        }
    }
}
