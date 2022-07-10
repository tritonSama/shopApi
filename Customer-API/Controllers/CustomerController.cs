using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Customer_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetAllCustomer()
        {
            return new List<Customer>
            {
                new Customer
                {
                    firstName = "Josh",
                    lastName = "Hen",

                }
            };
        }

    }
}
