using AshaApi.Data;
using AshaCollectionFormApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AshaCollectionFormApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AshaCollectionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AshaCollectionController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/AshaCollection
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AshaCollection>>> GetAll()
        {
            var list = await _context.AshaCollections.ToListAsync();

            if (list == null || !list.Any())
                return NotFound("No Asha Collection found.");

            return Ok(list);
        }

        // GET: api/AshaCollection/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<AshaCollection>> GetById(int id)
        {
            var ashacollection = await _context.AshaCollections.FindAsync(id);

            if (ashacollection == null)
                return NotFound();

            return Ok(ashacollection);
        }

        // POST: api/AshaCollection
        [HttpPost]
        public async Task<ActionResult<AshaCollection>> Create([FromBody] AshaCollection ashacollection)
        {
            if (ashacollection == null)
                return BadRequest("Invalid Asha Collection data.");

            ashacollection.CreatedAt = DateTime.UtcNow;
            ashacollection.UpdatedAt = DateTime.UtcNow;

            await _context.AshaCollections.AddAsync(ashacollection);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = ashacollection.Id }, ashacollection);
        }

        // PUT: api/AshaCollection/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AshaCollection ashacollection)
        {
            if (id != ashacollection.Id)
                return BadRequest("Asha Collection ID mismatch.");

            var existingAshaCollection = await _context.AshaCollections.FindAsync(id);
            if (existingAshaCollection == null)
                return NotFound("Asha Collection not found.");

            ashacollection.UpdatedAt = DateTime.UtcNow;

            _context.Entry(existingAshaCollection).CurrentValues.SetValues(ashacollection);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}