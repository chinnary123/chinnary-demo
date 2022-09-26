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
    public class CartModelsController : ControllerBase
    {
        private readonly EGroceryStoreDbContext _context;

        public CartModelsController(EGroceryStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/CartModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartModel>>> GetCartModels()
        {
            return await _context.CartModels.ToListAsync();
        }

        // GET: api/CartModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CartModel>> GetCartModel(int id)
        {
            var cartModel = await _context.CartModels.FindAsync(id);

            if (cartModel == null)
            {
                return NotFound();
            }

            return cartModel;
        }

        // PUT: api/CartModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCartModel(int id, CartModel cartModel)
        {
            if (id != cartModel.CartId)
            {
                return BadRequest();
            }

            _context.Entry(cartModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartModelExists(id))
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

        // POST: api/CartModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CartModel>> PostCartModel(CartModel cartModel)
        {
            _context.CartModels.Add(cartModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCartModel", new { id = cartModel.CartId }, cartModel);
        }

        // DELETE: api/CartModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CartModel>> DeleteCartModel(int id)
        {
            var cartModel = await _context.CartModels.FindAsync(id);
            if (cartModel == null)
            {
                return NotFound();
            }

            _context.CartModels.Remove(cartModel);
            await _context.SaveChangesAsync();

            return cartModel;
        }

        private bool CartModelExists(int id)
        {
            return _context.CartModels.Any(e => e.CartId == id);
        }
    }
}
