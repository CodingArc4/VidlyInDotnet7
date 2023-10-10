using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Vidly.Data;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CustomersController(ApplicationDbContext context,IMapper mapper)
        {
           _context = context;
            _mapper = mapper;
        }

        //endpoint to get customers
        [HttpGet("GetCustomers")]
        public IActionResult GetAllCustomers()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            var customerDto = _mapper.Map<List<Customer>, List<CustomerDto>>(customers);
            return Ok(customerDto);
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
            
            var customerDto = _mapper.Map<Customer, CustomerDto>(customer);
            return Ok(customerDto);
        }

        //endpoint to create customer
        [HttpPost("CreateCustomer")]
        public IActionResult CreateCustomer([FromBody] CustomerDto customerDto)
        {
            if (customerDto == null)
            {
                return BadRequest();
            }

            var customer = _mapper.Map<CustomerDto,Customer>(customerDto);
            _context.Add(customer);
            _context.SaveChanges();
            return Ok();
        }

        //endpoint to update customer 
        [HttpPut("UpdateCustomer/{id}")]
        public IActionResult EditCustomer(int id,[FromBody] CustomerDto customerDto) { 
            
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if(customerInDb == null)
            {
                return NotFound();
            }

            _mapper.Map(customerDto,customerInDb);

            //customerInDb.Name = customerDto.Name;
            //customerInDb.BirthDate = customerDto.BirthDate;
            //customerInDb.IsSubscribedToNewsletter = customerDto.IsSubscribedToNewsletter;

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
