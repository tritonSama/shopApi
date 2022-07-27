using CustomerAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly DataContext _context;
        public CustomerController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetAllCustomer()
        {
            return Ok(await _context.Customers.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Customer>>> CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return Ok(await _context.Customers.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<Customer>>> UpdateCustomer(Customer customer)
        {
            var dbCustomer = await _context.Customers.FindAsync(customer.Id);
            if (dbCustomer == null)
                return BadRequest("Customer not found");
            dbCustomer.firstName = customer.firstName;
            dbCustomer.lastName = customer.lastName;

            await _context.SaveChangesAsync();
            return Ok(await _context.Customers.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Customer>>> DeleteCustomer(int id)
        {
            var dbCustoemr = await _context.Customers.FindAsync(id);
            if (dbCustoemr == null)
                return BadRequest("Customer not found");
            _context.Customers.Remove(dbCustoemr);
            await _context.SaveChangesAsync();

            return Ok(await _context.Customers.ToListAsync());
        
        }
    }
}
