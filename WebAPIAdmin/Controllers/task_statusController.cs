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
    public class task_statusController : ControllerBase
    {
        private readonly Security_ServiceContext _context;

        public task_statusController(Security_ServiceContext context)
        {
            _context = context;
        }

        // GET: api/task_status
        [HttpGet]
        public async Task<ActionResult<IEnumerable<task_status>>> Gettask_Statuses()
        {
            return await _context.task_Statuses.ToListAsync();
        }

        // GET: api/task_status/5
        [HttpGet("{id}")]
        public async Task<ActionResult<task_status>> Gettask_status(int id)
        {
            var task_status = await _context.task_Statuses.FindAsync(id);

            if (task_status == null)
            {
                return NotFound();
            }

            return task_status;
        }

        // PUT: api/task_status/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttask_status(int id, task_status task_status)
        {
            if (id != task_status.id)
            {
                return BadRequest();
            }

            _context.Entry(task_status).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!task_statusExists(id))
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

        // POST: api/task_status
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<task_status>> Posttask_status(task_status task_status)
        {
            _context.task_Statuses.Add(task_status);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettask_status", new { id = task_status.id }, task_status);
        }

        // DELETE: api/task_status/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetask_status(int id)
        {
            var task_status = await _context.task_Statuses.FindAsync(id);
            if (task_status == null)
            {
                return NotFound();
            }

            _context.task_Statuses.Remove(task_status);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool task_statusExists(int id)
        {
            return _context.task_Statuses.Any(e => e.id == id);
        }
    }
}
