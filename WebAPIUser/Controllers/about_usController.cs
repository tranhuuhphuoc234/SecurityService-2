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
    public class about_usController : ControllerBase
    {
        private readonly Security_ServiceContext _context;

        public about_usController(Security_ServiceContext context)
        {
            _context = context;
        }

        // GET: api/about_us
        [HttpGet]
        public async Task<ActionResult<IEnumerable<about_us>>> Getget_about_us()
        {
            return await _context.get_about_us.ToListAsync();
        }

       
    }
}
