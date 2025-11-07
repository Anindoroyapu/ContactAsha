using ContactFormApi.Models;
using AshaApi.Data; // যদি AppDbContext ওখানে থাকে
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactFormApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }

        // ✅ Get all contacts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetAll()
        {
            var list = await _context.Contacts.ToListAsync();

            if (list == null || !list.Any())
                return NotFound("No contacts found.");

            return Ok(list);
        }

        // ✅ Get contact by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetById(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);

            if (contact == null)
                return NotFound("Contact not found.");

            return Ok(contact);
        }

        // ✅ Create new contact
        [HttpPost]
        public async Task<ActionResult<Contact>> Create([FromBody] Contact contact)
        {
            if (contact == null)
                return BadRequest("Invalid contact data.");

            contact.CreatedAt = DateTime.UtcNow;
            contact.UpdatedAt = DateTime.UtcNow;

            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = contact.Id }, contact);
        }

        // ✅ Update existing contact
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Contact contact)
        {
            if (id != contact.Id)
                return BadRequest("Contact ID mismatch.");

            var existingContact = await _context.Contacts.FindAsync(id);
            if (existingContact == null)
                return NotFound("Contact not found.");

            contact.UpdatedAt = DateTime.UtcNow;

            _context.Entry(existingContact).CurrentValues.SetValues(contact);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
