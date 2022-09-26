using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EGroceryStore.DataAccess;
using EGroceryStore.Models;

namespace EGroceryStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroceryModelsController : ControllerBase
    {
        private readonly EGroceryStoreDbContext _context;

        public GroceryModelsController(EGroceryStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/GroceryModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroceryModel>>> GetGroceryModels()
        {
            return await _context.GroceryModels.ToListAsync();
        }

        // GET: api/GroceryModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GroceryModel>> GetGroceryModel(int id)
        {
            var groceryModel = await _context.GroceryModels.FindAsync(id);

            if (groceryModel == null)
            {
                return NotFound();
            }

            return groceryModel;
        }

        // PUT: api/GroceryModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroceryModel(int id, GroceryModel groceryModel)
        {
            if (id != groceryModel.GroceryId)
            {
                return BadRequest();
            }

            _context.Entry(groceryModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroceryModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/GroceryModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<GroceryModel>> PostGroceryModel(GroceryModel groceryModel)
        {
            _context.GroceryModels.Add(groceryModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroceryModel", new { id = groceryModel.GroceryId }, groceryModel);
        }

        // DELETE: api/GroceryModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<GroceryModel>> DeleteGroceryModel(int id)
        {
            var groceryModel = await _context.GroceryModels.FindAsync(id);
            if (groceryModel == null)
            {
                return NotFound();
            }

            _context.GroceryModels.Remove(groceryModel);
            await _context.SaveChangesAsync();

            return groceryModel;
        }

        private bool GroceryModelExists(int id)
        {
            return _context.GroceryModels.Any(e => e.GroceryId == id);
        }
    }
}
