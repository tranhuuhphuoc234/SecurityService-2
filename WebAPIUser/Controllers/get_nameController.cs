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

        // POST: api/orderdetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<orderdetail>> PostOrder(orderdetail orderdetail)
        {
            _context.orderdetails.Add(orderdetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = orderdetail.id }, orderdetail);
        }


    }
}
