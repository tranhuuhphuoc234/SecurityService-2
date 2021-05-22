using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIAdmin.Models;
using WebAPIAdmin.Models.Context;
using WebAPIAdmin.Models.View;

namespace WebAPIAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillsController : ControllerBase
    {
        private readonly Security_ServiceContext _context;

        public BillsController(Security_ServiceContext context)
        {
            _context = context;
        }

        // GET: api/Bills
        [HttpGet]
        public async Task<ActionResult<IEnumerable<billView>>> GetBills()
        {
            var b = (from o in _context.orders
                     join od in _context.orderdetails on o.id equals od.order
                     join s in _context.services on od.service equals s.id
                     join e in _context.employees on od.employee equals e.id
                     join c in _context.clients on o.client equals c.id
                     select new billView {id=od.id,service=s.name,discount =o.discount,total=s.price,employee = e.name,client = c.name,date = o.date }).ToListAsync();
            return await b;
        }

    }
}
