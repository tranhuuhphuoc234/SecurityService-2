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
    public class requestsController : ControllerBase
    {
        private readonly Security_ServiceContext _context;

        public requestsController(Security_ServiceContext context)
        {
            _context = context;
        }

        // GET: api/requests
        [HttpGet]
        public async Task<ActionResult<List<Models.View.requestView>>> Getrequests()
        {
            var q = (from re in _context.requests
                     join cl in _context.clients
                     on re.client equals cl.id
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
                         client_phone = cl.phone,
                         client_status = cl.status
                     }).ToList();
            return q;
        }

        // GET: api/requests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<request>> Getrequest(int id)
        {
            var request = await _context.requests.FindAsync(id);

            if (request == null)
            {
                return NotFound();
            }

            return request;
        }

        // PUT: api/requests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
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
        }

        // POST: api/requests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<request>> Postrequest(request request)
        {
            _context.requests.Add(request);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getrequest", new { id = request.id }, request);
        }

        // DELETE: api/requests/5
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
        }
        /// search by client id 
        // GET: api/Search/name
        [HttpGet("Search/{client}")]
        public async Task<ActionResult<IEnumerable<request>>> Search(int client)
        {
            return await _context.requests.Where(a => a.client == client).ToListAsync();
        }
        //active  though id
        [HttpPut("active/{id}")]
        public async Task<IActionResult> Active(int id)
        {

            request b = _context.requests.FirstOrDefault(u => u.id == id && u.status == false);
            if (b != null) b.status = true; else b = null;
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
        }
        ///disable  though id
        [HttpPut("disable/{id}")]
        public async Task<IActionResult> Disable(int id)
        {

            request b = _context.requests.FirstOrDefault(u => u.id == id && u.status == true);
            if (b != null) b.status = false; else b = null;
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
        }
    }

}
