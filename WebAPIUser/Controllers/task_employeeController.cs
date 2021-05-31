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
    public class task_employeeController : ControllerBase
    {
        private readonly Security_ServiceContext _context;

        public task_employeeController(Security_ServiceContext context)
        {
            _context = context;
        }

        // GET: api/task_employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<task_employee>>> Gettask_Employees()
        {
            return await _context.task_Employees.ToListAsync();
        }

        // GET: api/task_employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<task_employee>> Gettask_employee(int id)
        {
            var task_employee = await _context.task_Employees.FindAsync(id);

            if (task_employee == null)
            {
                return NotFound();
            }

            return task_employee;
        }

        // PUT: api/task_employee/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttask_employee(int id, task_employee task_employee)
        {
            if (id != task_employee.id)
            {
                return BadRequest();
            }

            _context.Entry(task_employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!task_employeeExists(id))
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

        // POST: api/task_employee
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<task_employee>> Posttask_employee(task_employee task_employee)
        {
            _context.task_Employees.Add(task_employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettask_employee", new { id = task_employee.id }, task_employee);
        }

        // DELETE: api/task_employee/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetask_employee(int id)
        {
            var task_employee = await _context.task_Employees.FindAsync(id);
            if (task_employee == null)
            {
                return NotFound();
            }

            _context.task_Employees.Remove(task_employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool task_employeeExists(int id)
        {
            return _context.task_Employees.Any(e => e.id == id);
        }
        [HttpGet("getTaskByEmployee/{employee},{status}")]
        public async Task<ActionResult<List<Models.View.task_employeeView>>> getTaskByEmployee(int employee, string status)
        {
            var re = (from te in _context.task_Employees
                      join st in _context.task_Statuses
                      on te.task_status equals st.id
                      where te.employee == employee && st.name == status
                      select new Models.View.task_employeeView { id = te.id, task_main = te.task_main, task_name = te.task_name, employee = te.employee, description = te.description, start_time = te.start_time, end_time = te.end_time, start_day = te.start_day, end_day = te.end_day, name_status = st.name, task_status = te.task_status }).ToListAsync();
            return await re;
        }
    }
    
}
