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
    public class requestsController : ControllerBase
    {
        private readonly Security_ServiceContext _context;

        public requestsController(Security_ServiceContext context)
        {
            _context = context;
        }

        // GET: api/requests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<request>>> Getrequests()
        {

            return await _context.requests.ToListAsync();
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


        // POST: api/requests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<request>> Postrequest(request request)
        {
            _context.requests.Add(request);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getrequest", new { id = request.id }, request);
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
      
 
    }

}
