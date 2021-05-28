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
    public class orderdetailsController : ControllerBase
    {
        private readonly Security_ServiceContext _context;

        public orderdetailsController(Security_ServiceContext context)
        {
            _context = context;
        }

        // GET: api/orderdetails
        [HttpGet]
        public async Task<ActionResult<List<Models.View.orderdetailView>>> Getorderdetails()
        {
            var q=( from c in _context.clients
                    join o in _context.orders
                    on c.id equals o.client
                    join od in _context.orderdetails
                    on o.id equals od.order
                    join e in _context.employees
                    on od.employee equals e.id
                    select new Models.View.orderdetailView
                    { id=od.id,
                    name_client=c.name,
                    phone_client=c.phone,
                    email_client=c.email,
                    name_employee=e.name,
                    date=o.date,
                    total=o.total
            }).ToList();
            return q;
        }

        // GET: api/orderdetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<orderdetail>> Getorderdetail(int id)
        {
            var orderdetail = await _context.orderdetails.FindAsync(id);

            if (orderdetail == null)
            {
                return NotFound();
            }

            return orderdetail;
        }

        // PUT: api/orderdetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putorderdetail(int id, orderdetail orderdetail)
        {
            if (id != orderdetail.id)
            {
                return BadRequest();
            }

            _context.Entry(orderdetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!orderdetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/orderdetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<orderdetail>> Postorderdetail(orderdetail orderdetail)
        {
            _context.orderdetails.Add(orderdetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getorderdetail", new { id = orderdetail.id }, orderdetail);
        }

        // DELETE: api/orderdetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteorderdetail(int id)
        {
            var orderdetail = await _context.orderdetails.FindAsync(id);
            if (orderdetail == null)
            {
                return NotFound();
            }

            _context.orderdetails.Remove(orderdetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool orderdetailExists(int id)
        {
            return _context.orderdetails.Any(e => e.id == id);
        }
    }
}
