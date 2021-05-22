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
    public class specialitiesController : ControllerBase
    {
        private readonly Security_ServiceContext _context;

        public specialitiesController(Security_ServiceContext context)
        {
            _context = context;
        }

        // GET: api/specialities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<speciality>>> Getspecialities()
        {
            return await _context.specialities.ToListAsync();
        }

        // GET: api/specialities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<speciality>> Getspeciality(int id)
        {
            var speciality = await _context.specialities.FindAsync(id);

            if (speciality == null)
            {
                return NotFound();
            }

            return speciality;
        }

        // PUT: api/specialities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putspeciality(int id, speciality speciality)
        {
            if (id != speciality.id)
            {
                return BadRequest();
            }

            _context.Entry(speciality).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!specialityExists(id))
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

        // POST: api/specialities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<speciality>> Postspeciality(speciality speciality)
        {
            _context.specialities.Add(speciality);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getspeciality", new { id = speciality.id }, speciality);
        }

        // DELETE: api/specialities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletespeciality(int id)
        {
            var speciality = await _context.specialities.FindAsync(id);
            if (speciality == null)
            {
                return NotFound();
            }

            _context.specialities.Remove(speciality);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool specialityExists(int id)
        {
            return _context.specialities.Any(e => e.id == id);
        }
        /// search by name
        // GET: api/Searcg/name
        [HttpGet("Search/{name}")]
        public async Task<ActionResult<IEnumerable<speciality>>> Search(string name)
        {
            return await _context.specialities.Where(a => a.name.Contains(name)).ToListAsync();
        }
        //active  though id
        [HttpPut("active/{id}")]
        public async Task<IActionResult> Active(int id)
        {

            speciality b = _context.specialities.FirstOrDefault(u => u.id == id && u.status == false);
            if (b != null) b.status = true; else b = null;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!specialityExists(id))
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

            speciality b = _context.specialities.FirstOrDefault(u => u.id == id && u.status == true);
            if (b != null) b.status = false; else b = null;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!specialityExists(id))
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
