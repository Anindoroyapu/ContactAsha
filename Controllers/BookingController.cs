using ContactFormApi.Data;
using ContactFormApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactFormApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BookingController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetAll()
        {
            var list = await Booking.GetListAsync(_context);

            if (list == null || !list.Any())
                return NotFound("No bookings found.");

            return Ok(list);
        }

        [HttpPost]
        public async Task<ActionResult<Booking>> Create([FromBody] Booking booking)
        {
            if (booking == null)
            {
                return BadRequest("Invalid booking data.");
            }

            await _context.Booking.AddAsync(booking);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAll), new { id = booking.Id }, booking);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetById(int id)
        {
            var booking = await Booking.FindAsync(_context, id);
            if(booking == null)
            {
                return NotFound();
            }
            return Ok(booking) ;
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Booking booking)

        {
            if (id != booking.Id) return BadRequest();

            booking.UpdatedAt = DateTime.UtcNow;
            _context.Entry(booking).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
