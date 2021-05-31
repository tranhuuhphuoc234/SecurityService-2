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
    public class reason_rejectController : ControllerBase
    {
        private readonly Security_ServiceContext _context;

        public reason_rejectController(Security_ServiceContext context)
        {
            _context = context;
        }

        // GET: api/reason_reject
        [HttpGet]
        public async Task<ActionResult<IEnumerable<reason_reject>>> Getreason_Rejects()
        {
            return await _context.reason_Rejects.ToListAsync();
        }

        // GET: api/reason_reject/5
        [HttpGet("{id}")]
        public async Task<ActionResult<reason_reject>> Getreason_reject(int id)
        {
            var reason_reject = await _context.reason_Rejects.FindAsync(id);

            if (reason_reject == null)
            {
                return NotFound();
            }

            return reason_reject;
        }

        // PUT: api/reason_reject/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putreason_reject(int id, reason_reject reason_reject)
        {
            if (id != reason_reject.id)
            {
                return BadRequest();
            }

            _context.Entry(reason_reject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!reason_rejectExists(id))
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

        // POST: api/reason_reject
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<reason_reject>> Postreason_reject(reason_reject reason_reject)
        {
            _context.reason_Rejects.Add(reason_reject);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getreason_reject", new { id = reason_reject.id }, reason_reject);
        }

        // DELETE: api/reason_reject/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletereason_reject(int id)
        {
            var reason_reject = await _context.reason_Rejects.FindAsync(id);
            if (reason_reject == null)
            {
                return NotFound();
            }

            _context.reason_Rejects.Remove(reason_reject);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool reason_rejectExists(int id)
        {
            return _context.reason_Rejects.Any(e => e.id == id);
        }
    }
}
