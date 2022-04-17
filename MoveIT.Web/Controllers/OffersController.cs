#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoveIT.Web.Models;

namespace MoveIT.Web.Controllers
{
    [Route("api/offers")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        private readonly MoveITContext _context;

        public OffersController(MoveITContext context)
        {
            _context = context;
        }

        // GET: api/offers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Offer>> GetOffer(long id)
        {
            var offer = await _context.Offers.FindAsync(id);

            if (offer == null)
            {
                return NotFound();
            }

            return offer;
        }

        // POST: api/offers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> CreateOffer(Customer customer)
        {
            if (!CustomerExists(customer.Email))
            {
                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();
            }
            else
            {
                _context.Entry(customer).State = EntityState.Modified;
            }

            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        }

        // PUT: api/offers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(long id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }



        private bool CustomerExists(string email)
        {
            return _context.Customers.Any(e => e.Email.ToLowerInvariant() == email.ToLowerInvariant());
        }

        private bool CustomerExists(long id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }

        private Customer GetCustomerByEmail(string email)
        {
            return _context.Customers.FirstOrDefault(c => c.Email.ToLowerInvariant() == email.ToLowerInvariant());
        }
    }
}
