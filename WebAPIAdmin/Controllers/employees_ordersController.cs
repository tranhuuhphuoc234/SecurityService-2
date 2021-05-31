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
    public class employees_ordersController : ControllerBase
    {
        private readonly Security_ServiceContext _context;

        public employees_ordersController(Security_ServiceContext context)
        {
            _context = context;
        }

        // GET: api/employees_orders
       /* [HttpGet]
        public async Task<ActionResult<IEnumerable<employee>>> Getemployees()
        {
            return await _context.employees.ToListAsync();
        }
*/
        // GET: api/employees_orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<employeeView>>> Getemployee(int id)
        {
            var re = (from e in _context.employees
                      join s in _context.specialities on e.speciality equals s.id
                      join g in _context.grades on e.grade equals g.id
                      join r in _context.roles on e.role equals r.id
                      where e.speciality == id && e.status==true
                      select new employeeView { id = e.id, name = e.name, age = e.age, weight = e.weight, height = e.height, email = e.email, phone = e.phone, address = e.address, grade = g.name, role = r.name, speciality = s.name, achivement = e.achivement, aboutme = e.aboutme, price = e.price, status = e.status, usrname = e.usrname }).ToListAsync();
            return await re;
        }

        // PUT: api/employees_orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
       /* [HttpPut("{id}")]
        public async Task<IActionResult> Putemployee(int id, employee employee)
        {
            if (id != employee.id)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!employeeExists(id))
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

        // POST: api/employees_orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
       /* [HttpPost]
        public async Task<ActionResult<employee>> Postemployee(employee employee)
        {
            _context.employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getemployee", new { id = employee.id }, employee);
        }

        // DELETE: api/employees_orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteemployee(int id)
        {
            var employee = await _context.employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool employeeExists(int id)
        {
            return _context.employees.Any(e => e.id == id);
        }*/
    }
}
