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
    public class imagesController : ControllerBase
    {
        private readonly Security_ServiceContext _context;

        public imagesController(Security_ServiceContext context)
        {
            _context = context;
        }

        // GET: api/images
        [HttpGet]
        public async Task<ActionResult<IEnumerable<image>>> Getimages()
        {
            return await _context.images.ToListAsync();
        }

        // GET: api/images/5
        [HttpGet("{id}")]
        public async Task<ActionResult<image>> Getimage(int id)
        {
            var image = await _context.images.FindAsync(id);

            if (image == null)
            {
                return NotFound();
            }

            return image;
        }

        // PUT: api/images/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putimage(int id, image image)
        {
            if (id != image.id)
            {
                return BadRequest();
            }

            _context.Entry(image).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!imageExists(id))
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

        // POST: api/images
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<image>> Postimage(image image)
        {
            _context.images.Add(image);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getimage", new { id = image.id }, image);
        }

        // DELETE: api/images/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteimage(int id)
        {
            var image = await _context.images.FindAsync(id);
            if (image == null)
            {
                return NotFound();
            }

            _context.images.Remove(image);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool imageExists(int id)
        {
            return _context.images.Any(e => e.id == id);
        }
        //get img path though employee id 
        // GET: api/Search/employee
        [HttpGet("Search/{employee}")]
        public async Task<ActionResult<IEnumerable<image>>> Search(int employee)
        {
            return await _context.images.Where(a => a.employee == employee).ToListAsync();
        }
    }
}
