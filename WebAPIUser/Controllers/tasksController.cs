using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIAdmin.Models;
using WebAPIUser.Models.Context;

namespace WebAPIUser.Controllers
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
        public async Task<ActionResult<IEnumerable<task>>> Gettaks()
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
        [HttpGet("getTaskOpenByTeam/{team}")]
        public async Task<ActionResult<List<Models.View.taskView>>> getTaskOpenByTeam(int team)
        {
            var re = (from task in _context.tasks
                      join te in _context.team on task.team equals te.id
                      join st in _context.task_Statuses on task.task_status equals st.id
                      where task.team == team && st.name == "Open"
                      select new Models.View.taskView { id = task.id, name = task.name, start_day = task.start_day, end_day = task.end_day, location = task.location, description = task.description, request = task.request, task_status = task.task_status, team = task.team, status_name = st.name}).ToListAsync();
            return await re;
        }

        [HttpGet("getTaskDoneByTeam/{team}")]
        public async Task<ActionResult<List<Models.View.taskView>>> getTaskDoneByTeam(int team)
        {
            var re = (from task in _context.tasks
                      join te in _context.team on task.team equals te.id
                      join st in _context.task_Statuses on task.task_status equals st.id
                      where task.team == team && st.name == "Done"
                      select new Models.View.taskView { id = task.id, name = task.name, start_day = task.start_day, end_day = task.end_day, location = task.location, description = task.description, request = task.request, task_status = task.task_status, team = task.team, status_name = st.name }).ToListAsync();
            return await re;
        }

        [HttpGet("getTaskInProgressByTeam/{team}")]
        public async Task<ActionResult<List<Models.View.taskView>>> getTaskInProgressByTeam(int team)
        {
            var re = (from task in _context.tasks
                      join te in _context.team on task.team equals te.id
                      join st in _context.task_Statuses on task.task_status equals st.id
                      where task.team == team && st.name == "InProgress"
                      select new Models.View.taskView { id = task.id, name = task.name, start_day = task.start_day, end_day = task.end_day, location = task.location, description = task.description, request = task.request, task_status = task.task_status, team = task.team, status_name = st.name }).ToListAsync();
            return await re;
        }

        [HttpGet("getTaskRejectedByTeam/{team}")]
        public async Task<ActionResult<List<Models.View.taskView>>> getTaskRejectedByTeam(int team)
        {
            var re = (from task in _context.tasks
                      join te in _context.team on task.team equals te.id
                      join st in _context.task_Statuses on task.task_status equals st.id
                      where task.team == team && st.name == "Rejected"
                      select new Models.View.taskView { id = task.id, name = task.name, start_day = task.start_day, end_day = task.end_day, location = task.location, description = task.description, request = task.request, task_status = task.task_status, team = task.team, status_name = st.name }).ToListAsync();
            return await re;
        }

        [HttpGet("Claim/{id}")]
        public async Task<ActionResult<bool>> Claim(int id)
        {
            var q = _context.tasks.Where(d => d.id == id).FirstOrDefault();
            var status = _context.task_Statuses.Where(d => d.name == "InProgress").FirstOrDefault();
            q.task_status = status.id;
            _context.SaveChanges();
            return true;
        }

        [HttpGet("getTaskByTeamAndStatus/{team},{status}")]
        public async Task<ActionResult<List<Models.View.taskView>>> getTaskByTeamAndStatus(int team, string status)
        {
            var re = (from task in _context.tasks
                      join te in _context.team on task.team equals te.id
                      join st in _context.task_Statuses on task.task_status equals st.id
                      where task.team == team && st.name == status
                      select new Models.View.taskView { id = task.id, name = task.name, start_day = task.start_day, end_day = task.end_day, location = task.location, description = task.description, request = task.request, task_status = task.task_status, team = task.team, status_name = st.name }).ToListAsync();
            return await re;
        }
    }
}
