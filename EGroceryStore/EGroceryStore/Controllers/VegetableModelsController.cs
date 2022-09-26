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
    public class VegetableModelsController : ControllerBase
    {
        private readonly EGroceryStoreDbContext _context;

        public VegetableModelsController(EGroceryStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/VegetableModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VegetableModel>>> GetVegetableModels()
        {
            return await _context.VegetableModels.ToListAsync();
        }

        // GET: api/VegetableModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VegetableModel>> GetVegetableModel(Guid id)
        {
            var vegetableModel = await _context.VegetableModels.FindAsync(id);

            if (vegetableModel == null)
            {
                return NotFound();
            }

            return vegetableModel;
        }

        // PUT: api/VegetableModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVegetableModel(Guid id, VegetableModel vegetableModel)
        {
            if (id != vegetableModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(vegetableModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VegetableModelExists(id))
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

        // POST: api/VegetableModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<VegetableModel>> PostVegetableModel(VegetableModel vegetableModel)
        {
            _context.VegetableModels.Add(vegetableModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVegetableModel", new { id = vegetableModel.Id }, vegetableModel);
        }

        // DELETE: api/VegetableModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<VegetableModel>> DeleteVegetableModel(Guid id)
        {
            var vegetableModel = await _context.VegetableModels.FindAsync(id);
            if (vegetableModel == null)
            {
                return NotFound();
            }

            _context.VegetableModels.Remove(vegetableModel);
            await _context.SaveChangesAsync();

            return vegetableModel;
        }

        private bool VegetableModelExists(Guid id)
        {
            return _context.VegetableModels.Any(e => e.Id == id);
        }
    }
}
