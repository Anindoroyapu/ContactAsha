using AshaApi.Data;
using MooniAddProductApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MooniAddProductApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MooniAddProductController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MooniAddProductController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/MooniAddProduct
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MooniAddProduct>>> GetAll()
        {
            var list = await _context.MooniAddProducts.ToListAsync();

            if (list == null || !list.Any())
                return NotFound("No Product found.");

            return Ok(list);
        }

        // GET: api/MooniAddProduct/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<MooniAddProduct>> GetById(int id)
        {
            var mooniAddProduct = await _context.MooniAddProducts.FindAsync(id);

            if (mooniAddProduct == null)
                return NotFound();

            return Ok(mooniAddProduct);
        }

        // POST: api/MooniAddProduct
        [HttpPost]
        public async Task<ActionResult<MooniAddProduct>> Create([FromBody] MooniAddProduct mooniAddProduct)
        {
            if (mooniAddProduct == null)
                return BadRequest("Invalid Product data.");

            mooniAddProduct.CreatedAt = DateTime.UtcNow;
            mooniAddProduct.UpdatedAt = DateTime.UtcNow;

            await _context.MooniAddProducts.AddAsync(mooniAddProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = mooniAddProduct.Id }, mooniAddProduct);
        }

        // PUT: api/mooniAddProduct/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MooniAddProduct mooniAddProduct)
        {
            if (id != mooniAddProduct.Id)
                return BadRequest("Product ID mismatch.");

            var existingMooniAddProduct = await _context.MooniAddProducts.FindAsync(id);
            if (existingMooniAddProduct == null)
                return NotFound("addProduct not found.");

            mooniAddProduct.UpdatedAt = DateTime.UtcNow;

            _context.Entry(existingMooniAddProduct).CurrentValues.SetValues(mooniAddProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
