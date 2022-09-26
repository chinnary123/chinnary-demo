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
    public class BuyModelsController : ControllerBase
    {
        private readonly EGroceryStoreDbContext _context;

        public BuyModelsController(EGroceryStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/BuyModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BuyModel>>> GetBuyModel()
        {
            return await _context.BuyModel.ToListAsync();
        }

        // GET: api/BuyModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BuyModel>> GetBuyModel(int id)
        {
            var buyModel = await _context.BuyModel.FindAsync(id);

            if (buyModel == null)
            {
                return NotFound();
            }

            return buyModel;
        }

        // PUT: api/BuyModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBuyModel(int id, BuyModel buyModel)
        {
            if (id != buyModel.BuyerId)
            {
                return BadRequest();
            }

            _context.Entry(buyModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuyModelExists(id))
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

        // POST: api/BuyModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BuyModel>> PostBuyModel(BuyModel buyModel)
        {
            _context.BuyModel.Add(buyModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBuyModel", new { id = buyModel.BuyerId }, buyModel);
        }

        // DELETE: api/BuyModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BuyModel>> DeleteBuyModel(int id)
        {
            var buyModel = await _context.BuyModel.FindAsync(id);
            if (buyModel == null)
            {
                return NotFound();
            }

            _context.BuyModel.Remove(buyModel);
            await _context.SaveChangesAsync();

            return buyModel;
        }

        private bool BuyModelExists(int id)
        {
            return _context.BuyModel.Any(e => e.BuyerId == id);
        }
    }
}
