using AshaApi.Data;
using AshaExpenditureFormApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AshaExpenditureFormApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AshaExpenditureController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AshaExpenditureController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/AshaExpenditure
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AshaExpenditure>>> GetAll()
        {
            var list = await _context.AshaExpenditures.ToListAsync();

            if (list == null || !list.Any())
                return NotFound("No Asha Expenditure found.");

            return Ok(list);
        }

        // GET: api/Asha/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<AshaExpenditure>> GetById(int id)
        {
            var ashaexpenditure = await _context.AshaExpenditures.FindAsync(id);

            if (ashaexpenditure == null)
                return NotFound();

            return Ok(ashaexpenditure);
        }

        // POST: api/AshaExpenditure
        [HttpPost]
        public async Task<ActionResult<AshaExpenditure>> Create([FromBody] AshaExpenditure ashaexpenditure)
        {
            if (ashaexpenditure == null)
                return BadRequest("Invalid Asha expenditure data.");

            ashaexpenditure.CreatedAt = DateTime.UtcNow;
            ashaexpenditure.UpdatedAt = DateTime.UtcNow;

            await _context.AshaExpenditures.AddAsync(ashaexpenditure);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = ashaexpenditure.Id }, ashaexpenditure);
        }

        // PUT: api/AshaBooking/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AshaExpenditure ashaexpenditure)
        {
            if (id != ashaexpenditure.Id)
                return BadRequest("Asha expenditure ID mismatch.");

            var existingAshaExpenditure = await _context.AshaExpenditures.FindAsync(id);
            if (existingAshaExpenditure == null)
                return NotFound("Asha Expenditure not found.");

            ashaexpenditure.UpdatedAt = DateTime.UtcNow;

            _context.Entry(existingAshaExpenditure).CurrentValues.SetValues(ashaexpenditure);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

