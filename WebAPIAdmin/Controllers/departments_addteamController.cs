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
    public class departments_addteamController : ControllerBase
    {
        private readonly Security_ServiceContext _context;

        public departments_addteamController(Security_ServiceContext context)
        {
            _context = context;
        }

        [HttpGet("{id_region}")]
        public async Task<ActionResult<List<Models.departmentView>>> Getdepartments(int id_region)
        {
            var q = _context.departments.Where(d =>d.region  == id_region).Select(d => new Models.departmentView { id = d.id, name = d.name, status = d.status }).ToList();
            return q;
        }
        // GET: api/departments_addteam
        /* [HttpGet]
         public async Task<ActionResult<IEnumerable<department>>> Getdepartments()
         {
             return await _context.departments.ToListAsync();
         }*/

        // GET: api/departments_addteam/5
        /*[HttpGet("{id}")]
        public async Task<ActionResult<department>> Getdepartment(int id)
        {
            var department = await _context.departments.FindAsync(id);

            if (department == null)
            {
                return NotFound();
            }

            return department;
        }*/

        // PUT: api/departments_addteam/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /*[HttpPut("{id}")]
        public async Task<IActionResult> Putdepartment(int id, department department)
        {
            if (id != department.id)
            {
                return BadRequest();
            }

            _context.Entry(department).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!departmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }*/

        // POST: api/departments_addteam
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /*[HttpPost]
        public async Task<ActionResult<department>> Postdepartment(department department)
        {
            _context.departments.Add(department);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getdepartment", new { id = department.id }, department);
        }

        // DELETE: api/departments_addteam/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletedepartment(int id)
        {
            var department = await _context.departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            _context.departments.Remove(department);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool departmentExists(int id)
        {
            return _context.departments.Any(e => e.id == id);
        }*/
    }
}
