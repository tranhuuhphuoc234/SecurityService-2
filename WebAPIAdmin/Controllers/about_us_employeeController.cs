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
    public class about_us_employeeController : ControllerBase
    {
        private readonly Security_ServiceContext _context;

        public about_us_employeeController(Security_ServiceContext context)
        {
            _context = context;
        }

        // GET: api/about_us_employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<about_us_employee>>> Getget_about_us_employee()
        {
            return await _context.get_about_us_employee.ToListAsync();
        }
        /// search by name
        // GET: api/Searcg/name
        [HttpGet("Search/{name}")]
        public async Task<ActionResult<IEnumerable<about_us_employee>>> Search(string name)
        {
            return await _context.get_about_us_employee.Where(a => a.name.Contains(name)).ToListAsync();
        }
        // GET: api/about_us_employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<about_us_employee>> Getabout_us_employee(int id)
        {
            var about_us_employee = await _context.get_about_us_employee.FindAsync(id);

            if (about_us_employee == null)
            {
                return NotFound();
            }

            return about_us_employee;
        }

        // PUT: api/about_us_employee/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putabout_us_employee(int id, about_us_employee about_us_employee)
        {
            if (id != about_us_employee.id)
            {
                return BadRequest();
            }

            _context.Entry(about_us_employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!about_us_employeeExists(id))
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

        // POST: api/about_us_employee
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<about_us_employee>> Postabout_us_employee(about_us_employee about_us_employee)
        {
            _context.get_about_us_employee.Add(about_us_employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getabout_us_employee", new { id = about_us_employee.id }, about_us_employee);
        }

        // DELETE: api/about_us_employee/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteabout_us_employee(int id)
        {
            var about_us_employee = await _context.get_about_us_employee.FindAsync(id);
            if (about_us_employee == null)
            {
                return NotFound();
            }

            _context.get_about_us_employee.Remove(about_us_employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool about_us_employeeExists(int id)
        {
            return _context.get_about_us_employee.Any(e => e.id == id);
        }
    }
}
