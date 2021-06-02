﻿using System;
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
    public class servicesController : ControllerBase
    {
        private readonly Security_ServiceContext _context;

        public servicesController(Security_ServiceContext context)
        {
            _context = context;
        }
        // GET: api/services
        [HttpGet]
        public async Task<ActionResult<IEnumerable<service>>> Getservices()
        {
            return await _context.services.ToListAsync();
        }

        /// search by name
        // GET: api/Search/name
        [HttpGet("Search/{name}")]
        public async Task<ActionResult<IEnumerable<service>>> Search(string name,int skip)
        {
            skip = skip>1?skip*9:1;

            return await _context.services.Where(a => a.name.Contains(name) && a.status == true).OrderBy(a=>a.id).Skip(skip).Take(9).ToListAsync();
        }
        [HttpGet("getId/{id}")]
        public async Task<ActionResult<List<Models.View.serviceViewcs>>> getId( int id)
        {
            var q = _context.services.Where(d => d.id == id).Select(d => new Models.View.serviceViewcs { id = d.id, description = d.description, image = d.image_service, name = d.name, price = d.price, status = d.status }).ToList();
            return q;
        }
        [HttpGet("getService/{name}")]
        public async Task<ActionResult<Models.View.serviceViewcs>> getService(string name)
        {
            var q = _context.services.Where(d => d.name == name).Select(d => new Models.View.serviceViewcs { id = d.id, description = d.description, image = d.image_service, name = d.name, price = d.price, status = d.status }).FirstOrDefault();
            return q;
        }

    }
}
