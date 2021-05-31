using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIUser.Models;
using WebAPIUser.Models.Context;

namespace WebAPIUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class adminsController : ControllerBase
    {
        private readonly Security_ServiceContext _context;

        public adminsController(Security_ServiceContext context)
        {
            _context = context;
        }

        // GET: api/admins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<admin>>> Getadmin()
        {
            return await _context.admin.ToListAsync();
        }

        // GET: api/admins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<admin>> Getadmin(int id)
        {
            var admin = await _context.admin.FindAsync(id);

            if (admin == null)
            {
                return NotFound();
            }

            return admin;
        }

        // PUT: api/admins/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putadmin(int id, admin admin)
        {
            if (id != admin.id)
            {
                return BadRequest();
            }

            _context.Entry(admin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!adminExists(id))
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

        // POST: api/admins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<admin>> Postadmin(admin admin)
        {
            _context.admin.Add(admin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getadmin", new { id = admin.id }, admin);
        }

        // DELETE: api/admins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteadmin(int id)
        {
            var admin = await _context.admin.FindAsync(id);
            if (admin == null)
            {
                return NotFound();
            }

            _context.admin.Remove(admin);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool adminExists(int id)
        {
            return _context.admin.Any(e => e.id == id);
        }

        [HttpGet("Login/{username},{password}")]
        public async Task<ActionResult<bool>> login(string username, string password)
        {
            var re = _context.admin.Where(d => d.username == username && d.password == password).Count();
            if (re != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
