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
    public class clientsController : ControllerBase
    {
        private readonly Security_ServiceContext _context;

        public clientsController(Security_ServiceContext context)
        {
            _context = context;
        }

        /// show client with employee name
        // GET: api/clients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<client>>> Getclients()
        {
            return await _context.clients.ToListAsync();
        }

        // GET: api/clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<client>> Getclient(int id)
        {
            var client = await _context.clients.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        // using employee id instead of string 
        // PUT: api/clients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putclient(int id, client client)
        {
            if (id != client.id)
            {
                return BadRequest();
            }

            _context.Entry(client).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!clientExists(id))
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
        /// search by name
        // GET: api/Search/name
        [HttpGet("SearchByName/{name}")]
        public async Task<ActionResult<IEnumerable<client>>> searchByName(string name)
        {
            return await _context.clients.Where(a => a.name.Contains(name)).ToListAsync();


        }
        //search by phone
        [HttpGet("SearchByPhone/{phone}")]
        public async Task<ActionResult<IEnumerable<client>>> searchByPhone(string phone)
        {
            return await _context.clients.Where(a => a.phone.Contains(phone)).ToListAsync();


        }

        //active  though id
        [HttpPut("active/{id}")]
        public async Task<IActionResult> ActiveClient(int id)
        {

            client b = _context.clients.FirstOrDefault(u => u.id == id && u.status == false);
            if (b != null) b.status = true; else b = null;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!clientExists(id))
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
        public async Task<IActionResult> DisableClient(int id)
        {

            client b = _context.clients.FirstOrDefault(u => u.id == id && u.status == true);
            if (b != null) b.status = false; else b = null;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!clientExists(id))
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
        // POST: api/clients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<client>> Postclient(client client)
        {
            _context.clients.Add(client);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getclient", new { id = client.id }, client);
        }

        // DELETE: api/clients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteclient(int id)
        {
            var client = await _context.clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            _context.clients.Remove(client);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool clientExists(int id)
        {
            return _context.clients.Any(e => e.id == id);
        }
    }
}
