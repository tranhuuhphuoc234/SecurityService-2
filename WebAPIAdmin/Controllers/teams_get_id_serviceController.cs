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
    public class teams_get_id_serviceController : ControllerBase
    {
        private readonly Security_ServiceContext _context;

        public teams_get_id_serviceController(Security_ServiceContext context)
        {
            _context = context;
        }

        // GET: api/teams_get_id_service
        /*      [HttpGet]
              public async Task<ActionResult<IEnumerable<team>>> Getteams()
              {
                  return await _context.teams.ToListAsync();
              }*/

        // GET: api/teams_get_id_service/5
        [HttpGet("{id_service}")]
        public async Task<ActionResult<List<Models.View.teamView>>> Getteamss(int id_service)
        {
            var q = _context.teams.Where(d => d.service == id_service).Select(d => new Models.View.teamView { id = d.id,name=d.name, service = d.service, department = d.department, status = d.status }).ToList();
            return q;
        }

        // PUT: api/teams_get_id_service/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /*[HttpPut("{id}")]
        public async Task<IActionResult> Putteam(int id, team team)
        {
            if (id != team.id)
            {
                return BadRequest();
            }

            _context.Entry(team).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!teamExists(id))
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

        // POST: api/teams_get_id_service
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /*[HttpPost]
        public async Task<ActionResult<team>> Postteam(team team)
        {
            _context.teams.Add(team);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getteam", new { id = team.id }, team);
        }

        // DELETE: api/teams_get_id_service/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteteam(int id)
        {
            var team = await _context.teams.FindAsync(id);
            if (team == null)
            {
                return NotFound();
            }

            _context.teams.Remove(team);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool teamExists(int id)
        {
            return _context.teams.Any(e => e.id == id);
        }*/
    }
}
