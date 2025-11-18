using CheckoutFormApi.Models;
using AshaApi.Data; // যদি AppDbContext ওখানে থাকে
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CheckoutFormApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CheckoutController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CheckoutController(AppDbContext context)
        {
            _context = context;
        }

        // ✅ Get all Checkout
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Checkout>>> GetAll()
        {
            var list = await _context.Checkouts.ToListAsync();

            if (list == null || !list.Any())
                return NotFound("No Checkout found.");

            return Ok(list);
        }

        // ✅ Get Checkout by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Checkout>> GetById(int id)
        {
            var checkout = await _context.Checkouts.FindAsync(id);

            if (checkout == null)
                return NotFound("Checkout not found.");

            return Ok(checkout);
        }

        // ✅ Create new Checkout
        [HttpPost]
        public async Task<ActionResult<Checkout>> Create([FromBody] Checkout checkout)
        {
            if (checkout == null)
                return BadRequest("Invalid Checkout data.");

            checkout.CreatedAt = DateTime.UtcNow;
            checkout.UpdatedAt = DateTime.UtcNow;

            await _context.Checkouts.AddAsync(checkout);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = checkout.Id }, checkout);
        }

        // ✅ Update existing Checkout
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Checkout checkout)
        {
            if (id != checkout.Id)
                return BadRequest("Checkout ID mismatch.");

            var existingCheckout = await _context.Checkouts.FindAsync(id);
            if (existingCheckout == null)
                return NotFound("Checkout not found.");

            checkout.UpdatedAt = DateTime.UtcNow;

            _context.Entry(existingCheckout).CurrentValues.SetValues(checkout);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
