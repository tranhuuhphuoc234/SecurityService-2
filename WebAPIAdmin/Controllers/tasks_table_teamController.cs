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
    public class tasks_table_teamController : ControllerBase
    {
        private readonly Security_ServiceContext _context;

        public tasks_table_teamController(Security_ServiceContext context)
        {
            _context = context;
        }
        [HttpGet("{id_team}")]
        public async Task<ActionResult<List<Models.View.taskView>>> Getaskteam(int id_team)
        {
            var q = (from t in _context.tasks
                     join te in _context.teams
                     on t.team equals te.id
                     join d in _context.departments
                     on te.department equals d.id
                     join r in _context.regions
                     on d.region equals r.id
                     join re in _context.requests
                     on t.request equals re.id
                     join se in _context.services
                     on re.service equals se.id
                     join c in _context.clients
                     on re.client equals c.id
                     join ta in _context.task_Statuses
                     on t.task_status equals ta.id
                     where t.id == id_team
                     select new Models.View.taskView
                     {
                         name_client = c.name,
                         name_service = se.name,
                         name_task = t.name,
                         name_task_status = ta.name,
                         name_team = te.name
                     }).ToList();
            return q;
        }
    }
}
