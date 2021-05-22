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
    public class feedbacksController : ControllerBase
    {
        private readonly Security_ServiceContext _context;

        public feedbacksController(Security_ServiceContext context)
        {
            _context = context;
        }

        // GET: api/feedbacks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<feedback>>> Getfeedbacks()
        {
            return await _context.feedbacks.ToListAsync();
        }

        // GET: api/feedbacks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<feedback>> Getfeedback(int id)
        {
            var feedback = await _context.feedbacks.FindAsync(id);

            if (feedback == null)
            {
                return NotFound();
            }

            return feedback;
        }

        // PUT: api/feedbacks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putfeedback(int id, feedback feedback)
        {
            if (id != feedback.id)
            {
                return BadRequest();
            }

            _context.Entry(feedback).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!feedbackExists(id))
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

        // DELETE: api/feedbacks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletefeedback(int id)
        {
            var feedback = await _context.feedbacks.FindAsync(id);
            if (feedback == null)
            {
                return NotFound();
            }

            _context.feedbacks.Remove(feedback);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool feedbackExists(int id)
        {
            return _context.feedbacks.Any(e => e.id == id);
        }
        //active  though id
        [HttpPut("active/{id}")]
        public async Task<IActionResult> Active(int id)
        {

            feedback b = _context.feedbacks.FirstOrDefault(u => u.id == id && u.status == false);
            if (b != null) b.status = true; else b = null;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!feedbackExists(id))
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

            feedback b = _context.feedbacks.FirstOrDefault(u => u.id == id && u.status == true);
            if (b != null) b.status = false; else b = null;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!feedbackExists(id))
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
