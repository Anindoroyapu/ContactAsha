using Microsoft.AspNetCore.Mvc;
using ContactFormApi.Models;
using ContactFormApi.Data;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace ContactFormApi.Controllers
{
    [ApiController]
    [Route("api/contact")]
    public class ContactController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ILogger<ContactController> _logger;

        // Constructor to inject dependencies
        public ContactController(AppDbContext context, ILogger<ContactController> logger)
        {
            _context = context;
            _logger = logger;
        }

        // POST method to submit contact form
        [HttpPost]
        public async Task<IActionResult> SubmitForm([FromBody] ContactMessage message)
        {
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                _context.ContactMessages.Add(message);
                await _context.SaveChangesAsync();

                return Ok(new { success = true, message = "Form submitted successfully." });
          
        }

        }

        // GET: api/ContactMessages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactMessage>>> GetAllMessages()
        {
            var messages = await _context.ContactMessages.ToListAsync();
            return Ok(messages);
        }

    }
}
