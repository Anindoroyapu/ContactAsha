using AshaApi.Data;
using ExpenditureFormApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpenditureFormApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpenditureController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ExpenditureController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Expenditure
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Expenditure>>> GetAll()
        {
            var list = await _context.Expenditures.ToListAsync();

            if (list == null || !list.Any())
                return NotFound("No Expenditure found.");

            return Ok(list);
        }

        // GET: api/Booking/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Expenditure>> GetById(int id)
        {
            var expenditure = await _context.Expenditures.FindAsync(id);

            if (expenditure == null)
                return NotFound();

            return Ok(expenditure);
        }

        // POST: api/Expenditure
        [HttpPost]
        public async Task<ActionResult<Expenditure>> Create([FromBody] Expenditure expenditure)
        {
            if (expenditure == null)
                return BadRequest("Invalid expenditure data.");

            expenditure.CreatedAt = DateTime.UtcNow;
            expenditure.UpdatedAt = DateTime.UtcNow;

            await _context.Expenditures.AddAsync(expenditure);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = expenditure.Id }, expenditure);
        }

        // PUT: api/Booking/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Expenditure expenditure)
        {
            if (id != expenditure.Id)
                return BadRequest("expenditure ID mismatch.");

            var existingExpenditure = await _context.Expenditures.FindAsync(id);
            if (existingExpenditure == null)
                return NotFound("Expenditure not found.");

            expenditure.UpdatedAt = DateTime.UtcNow;

            _context.Entry(existingExpenditure).CurrentValues.SetValues(expenditure);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

