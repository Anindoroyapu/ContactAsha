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
           
        // GET method to retrieve all contact messages
      //  [HttpGet] 
       // public async Task<IActionResult> GetMessages()
       // {
          
                // Retrieve all contact messages from the database
         //       var messages = await _context.ContactMessages.ToListAsync();

                // Check if there are no messages
          //      if (messages == null || messages.Count == 0)
         //       {
          //          return NotFound(new { success = false, message = "No messages found." });
          //      }

                // Return the list of messages
          //      return Ok(new { success = true, data = messages });
            
       
        }
    }
}
