using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("customers")]
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{userId}")]
        public ActionResult<Customer> GetCustomerAsync([FromRoute] long userId)
        {
            var customer = _context.Customers.SingleOrDefault(p => p.Id == userId);
            if (customer != null)
            {
                return Ok(customer);
            }

            return NotFound();
        }

        [HttpPost("")]
        public async Task<ActionResult<long>> CreateCustomerAsync([FromBody] Customer customer)
        {
            var existCustomer = _context.Customers.FirstOrDefault(c =>
            c.Firstname == customer.Firstname && c.Firstname == customer.Lastname);

            if (existCustomer != null)
            {
                return new AlreadyAdded();
            }

            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return Ok(customer.Id);
        }
    }
}