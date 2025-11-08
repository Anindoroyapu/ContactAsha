using AshaApi.Data;
using AddProductApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AddProductApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddProductController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AddProductController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/AddProduct
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddProduct>>> GetAll()
        {
            var list = await _context.AddProducts.ToListAsync();

            if (list == null || !list.Any())
                return NotFound("No Product found.");

            return Ok(list);
        }

        // GET: api/AddProduct/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<AddProduct>> GetById(int id)
        {
            var addProduct = await _context.AddProducts.FindAsync(id);

            if (addProduct == null)
                return NotFound();

            return Ok(addProduct);
        }

        // POST: api/AddProduct
        [HttpPost]
        public async Task<ActionResult<AddProduct>> Create([FromBody] AddProduct addProduct)
        {
            if (addProduct == null)
                return BadRequest("Invalid Product data.");

            addProduct.CreatedAt = DateTime.UtcNow;
            addProduct.UpdatedAt = DateTime.UtcNow;

            await _context.AddProducts.AddAsync(addProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = addProduct.Sl }, addProduct);
        }

        // PUT: api/addProduct/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] AddProduct addProduct)
        {
            if (id != addProduct.Sl)
                return BadRequest("Product ID mismatch.");

            var existingAddProduct = await _context.AddProducts.FindAsync(id);
            if (existingAddProduct == null)
                return NotFound("addProduct not found.");

            addProduct.UpdatedAt = DateTime.UtcNow;

            _context.Entry(existingAddProduct).CurrentValues.SetValues(addProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
