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
    public class gradesController : ControllerBase
    {
        private readonly Security_ServiceContext _context;

        public gradesController(Security_ServiceContext context)
        {
            _context = context;
        }

        // GET: api/grades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<grade>>> Getgrades()
        {
            return await _context.grades.ToListAsync();
        }

        // GET: api/grades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<grade>> Getgrade(int id)
        {
            var grade = await _context.grades.FindAsync(id);

            if (grade == null)
            {
                return NotFound();
            }

            return grade;
        }

        // PUT: api/grades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putgrade(int id, grade grade)
        {
            if (id != grade.id)
            {
                return BadRequest();
            }

            _context.Entry(grade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!gradeExists(id))
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

        // POST: api/grades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<grade>> Postgrade(grade grade)
        {
            _context.grades.Add(grade);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getgrade", new { id = grade.id }, grade);
        }

        // DELETE: api/grades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletegrade(int id)
        {
            var grade = await _context.grades.FindAsync(id);
            if (grade == null)
            {
                return NotFound();
            }

            _context.grades.Remove(grade);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool gradeExists(int id)
        {
            return _context.grades.Any(e => e.id == id);
        }
        /// search by name
        // GET: api/Searcg/name
        [HttpGet("Search/{name}")]
        public async Task<ActionResult<IEnumerable<grade>>> Search(string name)
        {
            return await _context.grades.Where(a => a.name.Contains(name)).ToListAsync();
        }
        //active  though id
        [HttpPut("active/{id}")]
        public async Task<IActionResult> Active(int id)
        {

            grade b = _context.grades.FirstOrDefault(u => u.id == id && u.status == false);
            if (b != null) b.status = true; else b = null;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!gradeExists(id))
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
        public async Task<IActionResult> DisableGrade(int id)
        {

            grade b = _context.grades.FirstOrDefault(u => u.id == id && u.status == true);
            if (b != null) b.status = false; else b = null;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!gradeExists(id))
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
