using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIAdmin.Models;
using WebAPIAdmin.Models.Context;

namespace WebAPIAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class about_usController : ControllerBase
    {
        private readonly Security_ServiceContext _context;

        public about_usController(Security_ServiceContext context)
        {
            _context = context;
        }

        // GET: api/about_us
        [HttpGet]
        public async Task<ActionResult<IEnumerable<about_us>>> Getget_about_us()
        {
            return await _context.get_about_us.ToListAsync();
        }

        // GET: api/about_us/5
        [HttpGet("{id}")]
        public async Task<ActionResult<about_us>> Getabout_us(int id)
        {
            var about_us = await _context.get_about_us.FindAsync(id);

            if (about_us == null)
            {
                return NotFound();
            }

            return about_us;
        }

        // PUT: api/about_us/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putabout_us(int id, about_us about_us)
        {
            if (id != about_us.id)
            {
                return BadRequest();
            }

            _context.Entry(about_us).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!about_usExists(id))
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

        // POST: api/about_us
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<about_us>> Postabout_us(about_us about_us)
        {
            _context.get_about_us.Add(about_us);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getabout_us", new { id = about_us.id }, about_us);
        }

        // DELETE: api/about_us/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteabout_us(int id)
        {
            var about_us = await _context.get_about_us.FindAsync(id);
            if (about_us == null)
            {
                return NotFound();
            }

            _context.get_about_us.Remove(about_us);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool about_usExists(int id)
        {
            return _context.get_about_us.Any(e => e.id == id);
        }
    }
}
