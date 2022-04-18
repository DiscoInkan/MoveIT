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

        // GET: api/offers/guid
        [HttpGet("{offerIdentifier}")]
        public async Task<ActionResult<Offer>> GetOffer(string offerIdentifier)
        {
            if (!string.IsNullOrEmpty(offerIdentifier))
            {
                var identifiedOffer = GetOfferByIdentifier(offerIdentifier);

                if (identifiedOffer == null)
                {
                    return NotFound();
                }

                return Ok(identifiedOffer);
            }
            return NotFound();
        }

        // POST: api/offers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<string>> CreateOffer(Customer customer)
        {
            if (!CustomerExists(customer.Email)) //Create a new customer
            {
                _context.Customers.Add(customer);
                await _context.SaveChangesAsync();
                var maxOfferDate = customer.Offers.Max(d => d.OfferDate);
                var latestOffer = customer.Offers.FirstOrDefault(d => d.OfferDate >= maxOfferDate);                

                return Ok(latestOffer.OfferIdentifier);
            }
            else //Update an existing customer
            {   
                var existingCustomer = GetCustomerByEmail(customer.Email);
                var customerOffer = customer.Offers.FirstOrDefault();
                customerOffer.Customer = customer;
                _context.Offers.Add(customerOffer);
                _context.Entry(customerOffer).State = EntityState.Modified;
                return Ok(customerOffer.OfferIdentifier);
            }
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
        private Offer GetOfferByIdentifier(string offerIdentifier)
        {
            return _context.Offers.Include(o => o.Customer).FirstOrDefault(c => c.OfferIdentifier == Guid.Parse(offerIdentifier));
        }
    }
}
