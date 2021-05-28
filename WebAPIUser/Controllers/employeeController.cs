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
    public class employeesController : ControllerBase
    {
        private readonly Security_ServiceContext _context;

        public employeesController(Security_ServiceContext context)
        {
            _context = context;
        }

        // chua xong
        // GET: api/employees
        [HttpGet("{skip}")]
        public async Task<ActionResult<IEnumerable<employeeView>>> Getemployees(int skip)
        {
            skip = skip > 1 ? skip * 9 : 0;
            var re = (from e in _context.employees
                      join s in _context.specialities on e.speciality equals s.id
                      join d in _context.departments on e.department equals d.id
                      join rg in _context.regions on d.region equals rg.id
                      join g in _context.grades on e.grade equals g.id
                      join r in _context.roles on e.role equals r.id

                      select new employeeView { id = e.id, name = e.name, age = e.age, weight = e.weight, height = e.height, email = e.email, phone = e.phone, address = e.address, grade = g.name, role = r.name, speciality = s.name, achivement = e.achivement, aboutme = e.aboutme, price = e.price, region = rg.name, status = e.status }).Where(e=>e.status == true).OrderBy(e=>e.id).Skip(skip).Take(9).ToListAsync();
            return await re;
        }

        // GET: api/employees/5
        [HttpGet("find/{id}")]
        public async Task<ActionResult<IEnumerable<employeeView>>> Getemployee(int id)
        {
            var employee = await _context.employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            var re = (from e in _context.employees
                      join s in _context.specialities on e.speciality equals s.id
                      join d in _context.departments on e.department equals d.id
                      join rg in _context.regions on d.region equals rg.id
                      join g in _context.grades on e.grade equals g.id
                      join r in _context.roles on e.role equals r.id
                      join img in _context.images on e.id equals img.employee

                      select new employeeView { id = e.id, name = e.name, age = e.age, weight = e.weight, height = e.height, email = e.email, phone = e.phone, address = e.address, grade = g.name, role = r.name, speciality = s.name, achivement = e.achivement, aboutme = e.aboutme, price = e.price, region = rg.name, status = e.status, image = img.path }).Where(e => e.status == true && e.id == id).ToListAsync();
            return await re;
        }

        // PUT: api/employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putemployee(int id, employee employee)
        {
            if (id != employee.id)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!employeeExists(id))
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

        private bool employeeExists(int id)
        {
            return _context.employees.Any(e => e.id == id);
        }
        /// search by name
        // GET: api/Search/name
        [HttpGet("SearchByName/{name}")]
        public async Task<ActionResult<IEnumerable<employeeView>>> searchByName(string name,int skip)
        {
            skip = skip > 1 ? skip * 9 : 1;
            var re = (from e in _context.employees
                      join s in _context.specialities on e.speciality equals s.id
                      join d in _context.departments on e.department equals d.id
                      join rg in _context.regions on d.region equals rg.id
                      join g in _context.grades on e.grade equals g.id
                      join r in _context.roles on e.role equals r.id

                      select new employeeView { id = e.id, name = e.name, age = e.age, weight = e.weight, height = e.height, email = e.email, phone = e.phone, address = e.address, grade = g.name, role = r.name, speciality = s.name, achivement = e.achivement,region = r.name, aboutme = e.aboutme, price = e.price, status = e.status }).Where(a => a.name.Contains(name) && a.status == true).OrderBy(a=>a.id).Skip(skip).Take(9).ToListAsync();
            return await re;
        }
        //search by phone
        [HttpGet("SearchByPhone/{phone}")]
        public async Task<ActionResult<IEnumerable<employeeView>>> searchByPhone(string phone,int skip)
        {
            skip = skip > 1 ? skip * 9 : 1;
            var re = (from e in _context.employees
                      join s in _context.specialities on e.speciality equals s.id
                      join d in _context.departments on e.department equals d.id
                      join g in _context.grades on e.grade equals g.id
                      join r in _context.roles on e.role equals r.id

                      select new employeeView { id = e.id, name = e.name, age = e.age, weight = e.weight, height = e.height, email = e.email, phone = e.phone, address = e.address, grade = g.name, role = r.name, speciality = s.name, achivement = e.achivement, region = r.name, aboutme = e.aboutme, price = e.price, status = e.status }).Where(a => a.phone.Contains(phone) && a.status == true).OrderBy(a=>a.id).Skip(skip).Take(9).ToListAsync();
            return await re;
        }
        //search by region
        [HttpGet("SearchByRegion/{region}")]
        public async Task<ActionResult<IEnumerable<employeeView>>> searchByRegion(string region, int skip)
        {
            skip = skip > 1 ? skip * 9 : 1;
            var re = (from e in _context.employees
                      join s in _context.specialities on e.speciality equals s.id
                      join d in _context.departments on e.department equals d.id
                      join g in _context.grades on e.grade equals g.id
                      join r in _context.roles on e.role equals r.id

                      select new employeeView { id = e.id, name = e.name, age = e.age, weight = e.weight, height = e.height, email = e.email, phone = e.phone, address = e.address, grade = g.name, role = r.name, speciality = s.name, achivement = e.achivement, region = r.name, aboutme = e.aboutme, price = e.price, status = e.status }).Where(a => a.region.Contains(region) && a.status == true).OrderBy(a => a.id).Skip(skip).Take(9).ToListAsync();
            return await re;
        }
        //search by grade
        [HttpGet("SearchByGrade/{grade}")]
        public async Task<ActionResult<IEnumerable<employeeView>>> searchByGrade(string grade, int skip)
        {
            skip = skip > 1 ? skip * 9 : 1;
            var re = (from e in _context.employees
                      join s in _context.specialities on e.speciality equals s.id
                      join d in _context.departments on e.department equals d.id
                      join g in _context.grades on e.grade equals g.id
                      join r in _context.roles on e.role equals r.id

                      select new employeeView { id = e.id, name = e.name, age = e.age, weight = e.weight, height = e.height, email = e.email, phone = e.phone, address = e.address, grade = g.name, role = r.name, speciality = s.name, achivement = e.achivement, region = r.name, aboutme = e.aboutme, price = e.price, status = e.status }).Where(a => a.grade.Contains(grade) && a.status == true).OrderBy(a => a.id).Skip(skip).Take(9).ToListAsync();
            return await re;
        }
        //search by role
        [HttpGet("SearchByRole/{region}")]
        public async Task<ActionResult<IEnumerable<employeeView>>> searchByRole(string role, int skip)
        {
            skip = skip > 1 ? skip * 9 : 1;
            var re = (from e in _context.employees
                      join s in _context.specialities on e.speciality equals s.id
                      join d in _context.departments on e.department equals d.id
                      join g in _context.grades on e.grade equals g.id
                      join r in _context.roles on e.role equals r.id

                      select new employeeView { id = e.id, name = e.name, age = e.age, weight = e.weight, height = e.height, email = e.email, phone = e.phone, address = e.address, grade = g.name, role = r.name, speciality = s.name, achivement = e.achivement, region = r.name, aboutme = e.aboutme, price = e.price, status = e.status }).Where(a => a.role.Contains(role) && a.status == true).OrderBy(a => a.id).Skip(skip).Take(9).ToListAsync();
            return await re;
        }
        //search by speciality
        [HttpGet("SearchBySpeciality/{Speciality}")]
        public async Task<ActionResult<IEnumerable<employeeView>>> searchBySpeciality(string speciality, int skip)
        {
            skip = skip > 1 ? skip * 9 : 1;
            var re = (from e in _context.employees
                      join s in _context.specialities on e.speciality equals s.id
                      join d in _context.departments on e.department equals d.id
                      join g in _context.grades on e.grade equals g.id
                      join r in _context.roles on e.role equals r.id

                      select new employeeView { id = e.id, name = e.name, age = e.age, weight = e.weight, height = e.height, email = e.email, phone = e.phone, address = e.address, grade = g.name, role = r.name, speciality = s.name, achivement = e.achivement, region = r.name, aboutme = e.aboutme, price = e.price, status = e.status }).Where(a => a.speciality.Contains(speciality) && a.status == true).OrderBy(a => a.id).Skip(skip).Take(9).ToListAsync();
            return await re;
        }

        //login
        [HttpGet("Login/{username},{password}")]
        public async Task<ActionResult<bool>> login(string username, string password)
        {
            var re = (from e in _context.employees
                      join s in _context.specialities on e.speciality equals s.id
                      join d in _context.departments on e.department equals d.id
                      join g in _context.grades on e.grade equals g.id
                      join r in _context.roles on e.role equals r.id
                      where e.usrname == username && e.pwd == password
                      select new employeeView { id = e.id, name = e.name, age = e.age, weight = e.weight, height = e.height, email = e.email, phone = e.phone, address = e.address, grade = g.name, role = r.name, speciality = s.name, achivement = e.achivement, region = r.name, aboutme = e.aboutme, price = e.price, status = e.status }).Count();
            if(re != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [HttpGet("getUsername/{username}")]
        public async Task<ActionResult<IEnumerable<employeeView>>> getUsername(string username)
        {
            var re = (from e in _context.employees
                      join s in _context.specialities on e.speciality equals s.id
                      join d in _context.departments on e.department equals d.id
                      join g in _context.grades on e.grade equals g.id
                      join r in _context.roles on e.role equals r.id
                      join img in _context.images on e.id equals img.employee
                      where e.usrname == username
                      select new employeeView { id = e.id, name = e.name, age = e.age, weight = e.weight, height = e.height, email = e.email, phone = e.phone, address = e.address, grade = g.name, role = r.name, speciality = s.name, achivement = e.achivement, region = r.name, aboutme = e.aboutme, price = e.price, status = e.status, image = img.path }).ToListAsync();
            return await re;
        }

        [HttpGet("getEmployeeSkip/{row},{page}")]
        public async Task<ActionResult<IEnumerable<employeeView>>> getEmployeeSkip(int row, int page)
        {
            var re = (from e in _context.employees
                      join s in _context.specialities on e.speciality equals s.id
                      join d in _context.departments on e.department equals d.id
                      join rg in _context.regions on d.region equals rg.id
                      join g in _context.grades on e.grade equals g.id
                      join r in _context.roles on e.role equals r.id
                      join img in _context.images on e.id equals img.employee
                      select new employeeView { id = e.id, name = e.name, age = e.age, weight = e.weight, height = e.height, email = e.email, phone = e.phone, address = e.address, grade = g.name, role = r.name, speciality = s.name, achivement = e.achivement, region = r.name, aboutme = e.aboutme, price = e.price, status = e.status, image = img.path }).OrderBy(a => a.id).Skip((page - 1) * row).Take(row).ToListAsync();
            return await re;
        }

        [HttpGet("getAllEmployees")]
        public async Task<ActionResult<IEnumerable<employeeView>>> getAllEmployees()
        {
            var re = (from e in _context.employees
                      join s in _context.specialities on e.speciality equals s.id
                      join d in _context.departments on e.department equals d.id
                      join rg in _context.regions on d.region equals rg.id
                      join g in _context.grades on e.grade equals g.id
                      join r in _context.roles on e.role equals r.id
                      join img in _context.images on e.id  equals img.employee
                      select new employeeView { id = e.id, name = e.name, age = e.age, weight = e.weight, height = e.height, email = e.email, phone = e.phone, address = e.address, grade = g.name, role = r.name, speciality = s.name, achivement = e.achivement, region = r.name, aboutme = e.aboutme, price = e.price, status = e.status, image = img.path }).ToListAsync();
            return await re;
        }

        [HttpGet("CountEmployee")]
        public async Task<ActionResult<int>> CountEmployee()
        {
            var re = (from e in _context.employees
                      join s in _context.specialities on e.speciality equals s.id
                      join d in _context.departments on e.department equals d.id
                      join rg in _context.regions on d.region equals rg.id
                      join g in _context.grades on e.grade equals g.id
                      join r in _context.roles on e.role equals r.id
                      join img in _context.images on e.id equals img.employee
                      select new employeeView { id = e.id, name = e.name, age = e.age, weight = e.weight, height = e.height, email = e.email, phone = e.phone, address = e.address, grade = g.name, role = r.name, speciality = s.name, achivement = e.achivement, region = r.name, aboutme = e.aboutme, price = e.price, status = e.status, image = img.path }).Count();
            return re;
        }
    }
}
