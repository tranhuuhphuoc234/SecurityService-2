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
    public class tasksController : ControllerBase
    {
        private readonly Security_ServiceContext _context;

        public tasksController(Security_ServiceContext context)
        {
            _context = context;
        }

        // GET: api/tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<task>>> Gettasks()
        {
            return await _context.tasks.ToListAsync();
        }

        // GET: api/tasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<task>> Gettask(int id)
        {
            var task = await _context.tasks.FindAsync(id);

            if (task == null)
            {
                return NotFound();
            }

            return task;
        }

        // PUT: api/tasks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttask(int id, task task)
        {
            if (id != task.id)
            {
                return BadRequest();
            }

            _context.Entry(task).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!taskExists(id))
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

        // POST: api/tasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<task>> Posttask(task task)
        {
            _context.tasks.Add(task);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettask", new { id = task.id }, task);
        }

        // DELETE: api/tasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetask(int id)
        {
            var task = await _context.tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }

            _context.tasks.Remove(task);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool taskExists(int id)
        {
            return _context.tasks.Any(e => e.id == id);
        }
    }
}
