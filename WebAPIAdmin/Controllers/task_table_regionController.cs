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
    public class task_table_regionController : ControllerBase
    {
        private readonly Security_ServiceContext _context;

        public task_table_regionController(Security_ServiceContext context)
        {
            _context = context;
        }

        // GET: api/task_table_region

        // PUT: api/task_table_region/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpGet("{id_region}")]
        public async Task<ActionResult<List<Models.View.taskView>>> Getask(int id_region)
        {
            var q = (from t in _context.tasks
                     join te in _context.teams
                     on t.team equals te.id
                     join d in _context.departments
                     on te.department equals d.id
                     join r in  _context.regions
                     on d.region equals r.id
                     join re in _context.requests
                     on t.request equals re.id
                     join se in _context.services
                     on re.service equals se.id
                     join c in _context.clients
                     on re.client equals c.id
                     join ta in _context.task_Statuses
                     on t.task_status equals ta.id
                     where r.id == id_region
                     select new Models.View.taskView
                     {
                         name_client = c.name,
                         name_service = se.name,
                         name = t.name,
                         name_task_status = ta.name,
                         name_team = t.name
                     }).ToList();
            return q;
        }
    }
}
