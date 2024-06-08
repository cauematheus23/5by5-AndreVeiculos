using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndreVehiclesAPI.Data;
using Models;
using Models.DTO;
using Humanizer;

namespace AndreVehiclesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly AndreVehiclesAPIContext _context;

        public EmployeesController(AndreVehiclesAPIContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee()
        {
          if (_context.Employee == null)
          {
              return NotFound();
          }
            return await _context.Employee.Include(a => a.Adress).Include(p => p.Position).ToListAsync();
        }

        // GET: api/Employees/5
        [HttpGet("{document}")]
        public async Task<ActionResult<Employee>> GetEmployee(string document)
        {
          if (_context.Employee == null)
          {
              return NotFound();
          }
            var employee = await _context.Employee.Include(a => a.Adress).Include(p => p.Position).Where(e => e.Document == document).SingleOrDefaultAsync(e => e.Document == document);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{document}")]
        public async Task<IActionResult> PutEmployee(string document, EmployeeDTO DTO)
        {
            Employee employee = new Employee(DTO);
            employee.Document = DTO.Document;
            employee.Position = await _context.Position.FindAsync(employee.Position.Id);
            _context.Employee.Add(employee);
            if (document != employee.Document)
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
                if (!EmployeeExists(document))
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

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(EmployeeDTO DTO)
        {
            Employee employee = new Employee(DTO);
            employee.Document = DTO.Document;
            employee.Position = await _context.Position.FindAsync(employee.Position.Id);
            _context.Employee.Add(employee);

            
          if (_context.Employee == null)
          {
              return Problem("Entity set 'AndreVehiclesAPIContext.Employee'  is null.");
          }
            _context.Employee.Add(employee);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmployeeExists(employee.Document))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmployee", new { id = employee.Document }, employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(string id)
        {
            if (_context.Employee == null)
            {
                return NotFound();
            }
            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(string id)
        {
            return (_context.Employee?.Any(e => e.Document == id)).GetValueOrDefault();
        }
    }
}
