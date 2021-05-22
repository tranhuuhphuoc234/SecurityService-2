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



        // POST: api/feedbacks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<feedback>> Postfeedback(feedback feedback)
        {
            _context.feedbacks.Add(feedback);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getfeedback", new { id = feedback.id }, feedback);
        }

      
    }
}
