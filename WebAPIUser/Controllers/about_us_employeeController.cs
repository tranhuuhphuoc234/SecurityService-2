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
    public class about_us_employeeController : ControllerBase
    {
        private readonly Security_ServiceContext _context;

        public about_us_employeeController(Security_ServiceContext context)
        {
            _context = context;
        }

        // GET: api/about_us_employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<about_us_employee>>> Getget_about_us_employee()
        {
            return await _context.get_about_us_employee.ToListAsync();
        }
        /// search by name
        // GET: api/Searcg/name
        [HttpGet("Search/{name}")]
        public async Task<ActionResult<IEnumerable<about_us_employee>>> Search(string name)
        {
            return await _context.get_about_us_employee.Where(a => a.name.Contains(name)).ToListAsync();
        }
       
    }
}
