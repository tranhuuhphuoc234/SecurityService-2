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
    public class servicesController : ControllerBase
    {
        private readonly Security_ServiceContext _context;

        public servicesController(Security_ServiceContext context)
        {
            _context = context;
        }

        // GET: api/services
        [HttpGet]
        public async Task<ActionResult<IEnumerable<service>>> Getservices()
        {
            return await _context.services.ToListAsync();
        }

        // GET: api/services/5
        [HttpGet("{id}")]
        public async Task<ActionResult<service>> Getservice(int id)
        {
            var service = await _context.services.FindAsync(id);

            if (service == null)
            {
                return NotFound();
            }

            return service;
        }

        // PUT: api/services/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putservice(int id, service service)
        {
            if (id != service.id)
            {
                return BadRequest();
            }

            _context.Entry(service).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!serviceExists(id))
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

        // POST: api/services
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<service>> Postservice(service service)
        {
            _context.services.Add(service);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getservice", new { id = service.id }, service);
        }

        // DELETE: api/services/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteservice(int id)
        {
            var service = await _context.services.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }

            _context.services.Remove(service);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool serviceExists(int id)
        {
            return _context.services.Any(e => e.id == id);
        }
        /// search by name
        // GET: api/Search/name
        [HttpGet("Search/{name}")]
        public async Task<ActionResult<IEnumerable<service>>> Search(string name)
        {
            return await _context.services.Where(a => a.name.Contains(name)).ToListAsync();
        }
        //active  though id
        [HttpPut("active/{id}")]
        public async Task<IActionResult> Active(int id)
        {

            service b = _context.services.FirstOrDefault(u => u.id == id && u.status == false);
            if (b != null) b.status = true; else b = null;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!serviceExists(id))
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

            service b = _context.services.FirstOrDefault(u => u.id == id && u.status == true);
            if (b != null) b.status = false; else b = null;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!serviceExists(id))
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
