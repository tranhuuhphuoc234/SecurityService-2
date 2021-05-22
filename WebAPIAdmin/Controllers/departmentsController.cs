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
    public class departmentsController : ControllerBase
    {
        private readonly Security_ServiceContext _context;

        public departmentsController(Security_ServiceContext context)
        {
            _context = context;
        }

        // GET: api/departments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<departmentView>>> Getdepartments()
        {
            var s = (from d in _context.departments
                     join r in _context.regions on d.region equals r.id
                     select new departmentView {id = d.id, name=d.name , region=r.name, status=d.status }).ToListAsync();
            return await s;
        }

        // GET: api/departments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<department>> Getdepartment(int id)
        {
            var department = await _context.departments.FindAsync(id);

            if (department == null)
            {
                return NotFound();
            }

            return department;
        }

        // PUT: api/departments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
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
        }

        // POST: api/departments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<department>> Postdepartment(department department)
        {
            _context.departments.Add(department);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getdepartment", new { id = department.id }, department);
        }

        // DELETE: api/departments/5
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
        }
        /// search by name
        // GET: api/Search/name
        [HttpGet("Search/{name}")]
        public async Task<ActionResult<IEnumerable<departmentView>>> Search(string name)
        {
            var s = (from d in _context.departments
                     join r in _context.regions on d.region equals r.id
                     select new departmentView { name = d.name, region = r.name, status = d.status }).Where(a=> a.name.Contains(name)).ToListAsync();
            return await s;
        }
        //active  though id
        [HttpPut("active/{id}")]
        public async Task<IActionResult> Active(int id)
        {

            department b = _context.departments.FirstOrDefault(u => u.id == id && u.status == false);
            if (b != null) b.status = true; else b = null;
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
        }
        ///disable  though id
        [HttpPut("disable/{id}")]
        public async Task<IActionResult> Disable(int id)
        {

            department b = _context.departments.FirstOrDefault(u => u.id == id && u.status == true);
            if (b != null) b.status = false; else b = null;
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
        }
    }
}
