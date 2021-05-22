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
    public class  get_nameController : ControllerBase
    {
        private readonly Security_ServiceContext _context;

        public get_nameController(Security_ServiceContext context)
        {
            _context = context;
        }

        // GET: api/regions
        [HttpGet("region")]
        public async Task<ActionResult<IEnumerable<region>>> GetRegion()
        {
            return await _context.regions.ToListAsync();
        }
        // GET: api/roles
        [HttpGet("role")]
        public async Task<ActionResult<IEnumerable<role>>> GetRole()
        {
            return await _context.roles.ToListAsync();
        }
        // GET: api/grade
        [HttpGet("grade")]
        public async Task<ActionResult<IEnumerable<grade>>> GetGrade()
        {
            return await _context.grades.ToListAsync();
        }
        // GET: api/speciality
        [HttpGet("speciality")]
        public async Task<ActionResult<IEnumerable<speciality>>> GetSpeciality()
        {
            return await _context.specialities.ToListAsync();
        }




    }
}
