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
    public class teams_get_2idController : ControllerBase
    {
        private readonly Security_ServiceContext _context;

        public teams_get_2idController(Security_ServiceContext context)
        {
            _context = context;
        }

        [HttpGet("{id_department}/{id_service}")]
        public async Task<ActionResult<List<Models.View.teamView>>> Getiddepartment(int id_department, int id_service)
        {
            var q = _context.teams.Where(d => d.department == id_department && d.service==id_service).Select(d => new Models.View.teamView { id = d.id, name = d.name, service = d.service, department = d.department, status = d.status }).ToList();
            return q;
        }
    }
}
