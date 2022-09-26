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
    public class LoginModelsController : ControllerBase
    {
        private readonly EGroceryStoreDbContext _context;

        public LoginModelsController(EGroceryStoreDbContext context)
        {
            _context = context;
        }

        // GET: api/LoginModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoginModel>>> GetLoginModels()
        {
            return await _context.LoginModels.ToListAsync();
        }

        // GET: api/LoginModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LoginModel>> GetLoginModel(string id)
        {
            var loginModel = await _context.LoginModels.FindAsync(id);

            if (loginModel == null)
            {
                return NotFound();
            }

            return loginModel;
        }

        // PUT: api/LoginModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLoginModel(string id, LoginModel loginModel)
        {
            if (id != loginModel.EmailId)
            {
                return BadRequest();
            }

            _context.Entry(loginModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginModelExists(id))
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

        // POST: api/LoginModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LoginModel>> PostLoginModel(LoginModel loginModel)
        {
            _context.LoginModels.Add(loginModel);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LoginModelExists(loginModel.EmailId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLoginModel", new { id = loginModel.EmailId }, loginModel);
        }

        // DELETE: api/LoginModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LoginModel>> DeleteLoginModel(string id)
        {
            var loginModel = await _context.LoginModels.FindAsync(id);
            if (loginModel == null)
            {
                return NotFound();
            }

            _context.LoginModels.Remove(loginModel);
            await _context.SaveChangesAsync();

            return loginModel;
        }

        private bool LoginModelExists(string id)
        {
            return _context.LoginModels.Any(e => e.EmailId == id);
        }
    }
}
