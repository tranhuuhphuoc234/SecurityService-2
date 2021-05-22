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
    public class regionsController : ControllerBase
    {
        private readonly Security_ServiceContext _context;

        public regionsController(Security_ServiceContext context)
        {
            _context = context;
        }

        // GET: api/regions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<region>>> Getregions()
        {
            return await _context.regions.ToListAsync();
        }

        // GET: api/regions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<region>> Getregion(int id)
        {
            var region = await _context.regions.FindAsync(id);

            if (region == null)
            {
                return NotFound();
            }

            return region;
        }

        // PUT: api/regions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putregion(int id, region region)
        {
            if (id != region.id)
            {
                return BadRequest();
            }

            _context.Entry(region).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!regionExists(id))
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

        // POST: api/regions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<region>> Postregion(region region)
        {
            _context.regions.Add(region);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getregion", new { id = region.id }, region);
        }

        // DELETE: api/regions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteregion(int id)
        {
            var region = await _context.regions.FindAsync(id);
            if (region == null)
            {
                return NotFound();
            }

            _context.regions.Remove(region);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool regionExists(int id)
        {
            return _context.regions.Any(e => e.id == id);
        }
        /// search by name
        // GET: api/Searcg/name
        [HttpGet("Search/{name}")]
        public async Task<ActionResult<IEnumerable<region>>> Search(string name)
        {
            return await _context.regions.Where(a => a.name.Contains(name)).ToListAsync();
        }
        //active  though id
        [HttpPut("active/{id}")]
        public async Task<IActionResult> Active(int id)
        {

            region b = _context.regions.FirstOrDefault(u => u.id == id && u.status == false);
            if (b != null) b.status = true; else b = null;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!regionExists(id))
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
        ///disable  though id
        [HttpPut("disable/{id}")]
        public async Task<IActionResult> Disable(int id)
        {

            region b = _context.regions.FirstOrDefault(u => u.id == id && u.status == true);
            if (b != null) b.status = false; else b = null;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!regionExists(id))
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
    }
}
