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
