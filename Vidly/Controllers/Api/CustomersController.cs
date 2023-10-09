using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Vidly.Data;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
           _context = context;
        }

        //endpoint to get customers
        [HttpGet("GetCustomers")]
        public IActionResult GetAllCustomers()
        {
            var customers = _context.Customers.ToList();
            return Ok(customers);
        }

        //endpoint to get customer by id
        [HttpGet("GetCustomerById/{id}")]
        public IActionResult GetCustomersById(int id)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == id);

            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        //endpoint to create customer
        [HttpPost("CreateCustomer")]
        public IActionResult CreateCustomer([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }

            _context.Add(customer);
            _context.SaveChanges();
            return Ok();
        }

        //endpoint to update customer 
        [HttpPut("UpdateCustomer/{id}")]
        public IActionResult EditCustomer(int id,[FromBody] Customer customer) { 
            
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if(customerInDb == null)
            {
                return NotFound();
            }

            customerInDb.Name = customer.Name;
            customerInDb.BirthDate = customer.BirthDate;
            customerInDb.MembershipType = customer.MembershipType;
            customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;

            _context.Update(customerInDb);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return Ok();
        }
    }
}
