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
    public class trainningsController : ControllerBase
    {
        private readonly Security_ServiceContext _context;

        public trainningsController(Security_ServiceContext context)
        {
            _context = context;
        }

        // GET: api/trainnings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<trainning>>> Gettrainnings()
        {
            return await _context.trainnings.ToListAsync();
        }

        // GET: api/trainnings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<trainning>> Gettrainning(int id)
        {
            var trainning = await _context.trainnings.FindAsync(id);

            if (trainning == null)
            {
                return NotFound();
            }

            return trainning;
        }

        // PUT: api/trainnings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttrainning(int id, trainning trainning)
        {
            if (id != trainning.id)
            {
                return BadRequest();
            }

            _context.Entry(trainning).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!trainningExists(id))
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

        // POST: api/trainnings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<trainning>> Posttrainning(trainning trainning)
        {
            _context.trainnings.Add(trainning);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Gettrainning", new { id = trainning.id }, trainning);
        }

        // DELETE: api/trainnings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetrainning(int id)
        {
            var trainning = await _context.trainnings.FindAsync(id);
            if (trainning == null)
            {
                return NotFound();
            }

            _context.trainnings.Remove(trainning);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool trainningExists(int id)
        {
            return _context.trainnings.Any(e => e.id == id);
        }
        /// search by name
        // GET: api/Searcg/name
        [HttpGet("Search/{name}")]
        public async Task<ActionResult<IEnumerable<trainning>>> Search(string name)
        {
            return await _context.trainnings.Where(a => a.name.Contains(name)).ToListAsync();
        }
        //active  though id
        [HttpPut("active/{id}")]
        public async Task<IActionResult> Active(int id)
        {

            trainning b = _context.trainnings.FirstOrDefault(u => u.id == id && u.status == false);
            if (b != null) b.status = true; else b = null;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!trainningExists(id))
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

            trainning b = _context.trainnings.FirstOrDefault(u => u.id == id && u.status == true);
            if (b != null) b.status = false; else b = null;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!trainningExists(id))
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
