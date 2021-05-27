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
    public class Check_requestController : ControllerBase
    {
        private readonly Security_ServiceContext _context;

        public Check_requestController(Security_ServiceContext context)
        {
            _context = context;
        }

        // GET: api/Check_request
        [HttpGet]
        public async Task<ActionResult<List<Models.View.requestView>>> Check_fasle()
        {
            var q = (from re in _context.requests
                     join cl in _context.clients
                     on re.client equals cl.id
                     where re.status == false
                     select new Models.View.requestView
                     {
                         id = re.id,
                         service = re.service,
                         message = re.message,
                         client = re.client,
                         status = re.status,
                         client_name = cl.name,
                         client_address = cl.address,
                         client_email = cl.email,
                         employee = cl.id,
                         client_phone = cl.phone,
                         client_status = cl.status
                     }).ToList();
            return q;
        }

        // GET: api/Check_request/5
       /* [HttpGet("{id}")]
        public async Task<ActionResult<request>> Getrequest(int id)
        {
            var request = await _context.requests.FindAsync(id);

            if (request == null)
            {
                return NotFound();
            }

            return request;
        }*/

        // PUT: api/Check_request/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /*[HttpPut("{id}")]
        public async Task<IActionResult> Putrequest(int id, request request)
        {
            if (id != request.id)
            {
                return BadRequest();
            }

            _context.Entry(request).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!requestExists(id))
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

        // POST: api/Check_request
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /*[HttpPost]
        public async Task<ActionResult<request>> Postrequest(request request)
        {
            _context.requests.Add(request);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getrequest", new { id = request.id }, request);
        }

        // DELETE: api/Check_request/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleterequest(int id)
        {
            var request = await _context.requests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }

            _context.requests.Remove(request);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool requestExists(int id)
        {
            return _context.requests.Any(e => e.id == id);
        }*/
    }
}
