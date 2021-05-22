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
    public class trainningsController : ControllerBase
    {
        private readonly Security_ServiceContext _context;

        public trainningsController(Security_ServiceContext context)
        {
            _context = context;
        }

        // GET: api/trainnings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<trainning>>> Gettrainnings(int skip)
        {
            skip = skip>1?skip*9:1;
            return await _context.trainnings.Where(t=>t.status == true).OrderBy(t=>t.id).Skip(skip).Take(9).ToListAsync();
        }

        /// search by name
        // GET: api/Searcg/name
        [HttpGet("Search/{name}")]
        public async Task<ActionResult<IEnumerable<trainning>>> Search(string name,int skip)
        {
            skip = skip>1?skip*9:1;
            return await _context.trainnings.Where(a => a.name.Contains(name) && a.status == true).OrderBy(a=>a.id).Skip(skip).Take(9).ToListAsync();
        }


    }
}
