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
    public class RecruitmentsController : ControllerBase
    {
        private readonly Security_ServiceContext _context;

        public RecruitmentsController(Security_ServiceContext context)
        {
            _context = context;
        }

        // GET: api/Recruitments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recruitment>>> GetRecruitment()
        {
            return await _context.Recruitment.ToListAsync();
        }

        // GET: api/Recruitments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Recruitment>> GetRecruitment(int id)
        {
            var recruitment = await _context.Recruitment.FindAsync(id);

            if (recruitment == null)
            {
                return NotFound();
            }

            return recruitment;
        }

        // PUT: api/Recruitments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecruitment(int id, Recruitment recruitment)
        {
            if (id != recruitment.id)
            {
                return BadRequest();
            }

            _context.Entry(recruitment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecruitmentExists(id))
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

        // POST: api/Recruitments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Recruitment>> PostRecruitment(Recruitment recruitment)
        {
            _context.Recruitment.Add(recruitment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecruitment", new { id = recruitment.id }, recruitment);
        }

        // DELETE: api/Recruitments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecruitment(int id)
        {
            var recruitment = await _context.Recruitment.FindAsync(id);
            if (recruitment == null)
            {
                return NotFound();
            }

            _context.Recruitment.Remove(recruitment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecruitmentExists(int id)
        {
            return _context.Recruitment.Any(e => e.id == id);
        }
    }
}
