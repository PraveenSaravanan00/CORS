using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CORS_web.Data;
using CORS_web.Model;

namespace CORS_web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class registersController : ControllerBase
    {
        private readonly CORS_webContext _context;

        public registersController(CORS_webContext context)
        {
            _context = context;
        }

        // GET: api/registers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<register>>> Getregister()
        {
            return await _context.register.ToListAsync();
        }

        // GET: api/registers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<register>> Getregister(int id)
        {
            var register = await _context.register.FindAsync(id);

            if (register == null)
            {
                return NotFound();
            }

            return register;
        }

        // PUT: api/registers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putregister(int id, register register)
        {
            if (id != register.Id)
            {
                return BadRequest();
            }

            _context.Entry(register).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!registerExists(id))
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

        // POST: api/registers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<register>> Postregister(register register)
        {
            _context.register.Add(register);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getregister", new { id = register.Id }, register);
        }

        // DELETE: api/registers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteregister(int id)
        {
            var register = await _context.register.FindAsync(id);
            if (register == null)
            {
                return NotFound();
            }

            _context.register.Remove(register);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool registerExists(int id)
        {
            return _context.register.Any(e => e.Id == id);
        }
    }
}
