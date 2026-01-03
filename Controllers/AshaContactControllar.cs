using AshaContactFormApi.Models;
using AshaApi.Data; // যদি AppDbContext ওখানে থাকে
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AshaContactFormApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AshaContactController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AshaContactController(AppDbContext context)
        {
            _context = context;
        }

        // ✅ Get all contacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AshaContact>>> GetAll()
        {
            var list = await _context.AshaContacts.ToListAsync();

            if (list == null || !list.Any())
                return NotFound("No contacts found.");

            return Ok(list);
        }

        // ✅ Get contact by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<AshaContact>> GetById(int id)
        {
            var contact = await _context.AshaContacts.FindAsync(id);

            if (contact == null)
                return NotFound("Contact not found.");

            return Ok(contact);
        }

        // ✅ Create new contact
        [HttpPost]
        public async Task<ActionResult<AshaContact>> Create([FromBody] AshaContact ashacontact)
        {
            if (ashacontact == null)
                return BadRequest("Invalid contact data.");

            ashacontact.CreatedAt = DateTime.UtcNow;
            ashacontact.UpdatedAt = DateTime.UtcNow;

            await _context.AshaContacts.AddAsync(ashacontact);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = ashacontact.Id }, ashacontact);
        }

        // ✅ Update existing contact
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AshaContact ashacontact)
        {
            if (id != ashacontact.Id)
                return BadRequest("Contact ID mismatch.");

            var existingAshaContact = await _context.AshaContacts.FindAsync(id);
            if (existingAshaContact == null)
                return NotFound("Contact not found.");

            ashacontact.UpdatedAt = DateTime.UtcNow;

            _context.Entry(existingAshaContact).CurrentValues.SetValues(ashacontact);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
