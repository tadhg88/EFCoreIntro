using EFCoreIntro.Infrastructure.Models;
using EFCoreIntro.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace EFCoreApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ApplicationDbContext _applicationDbContext;

        public CustomerController(ILogger<CustomerController> logger, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _applicationDbContext = applicationDbContext ?? throw new ArgumentNullException(nameof(applicationDbContext));
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            _applicationDbContext.Set<Customer>().Add(customer);
            _applicationDbContext.SaveChanges();

            return Ok();
        }
    }
}
