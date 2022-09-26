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
    public class RatingModelsController : ControllerBase
    {
        private readonly EGroceryStoreDbContext _context;

        public RatingModelsController(EGroceryStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/RatingModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RatingModel>>> GetRatingModels()
        {
            return await _context.RatingModels.ToListAsync();
        }

        // GET: api/RatingModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RatingModel>> GetRatingModel(int id)
        {
            var ratingModel = await _context.RatingModels.FindAsync(id);

            if (ratingModel == null)
            {
                return NotFound();
            }

            return ratingModel;
        }

        // PUT: api/RatingModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRatingModel(int id, RatingModel ratingModel)
        {
            if (id != ratingModel.RatingId)
            {
                return BadRequest();
            }

            _context.Entry(ratingModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RatingModelExists(id))
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

        // POST: api/RatingModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RatingModel>> PostRatingModel(RatingModel ratingModel)
        {
            _context.RatingModels.Add(ratingModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRatingModel", new { id = ratingModel.RatingId }, ratingModel);
        }

        // DELETE: api/RatingModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RatingModel>> DeleteRatingModel(int id)
        {
            var ratingModel = await _context.RatingModels.FindAsync(id);
            if (ratingModel == null)
            {
                return NotFound();
            }

            _context.RatingModels.Remove(ratingModel);
            await _context.SaveChangesAsync();

            return ratingModel;
        }

        private bool RatingModelExists(int id)
        {
            return _context.RatingModels.Any(e => e.RatingId == id);
        }
    }
}
