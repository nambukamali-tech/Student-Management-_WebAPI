using Microsoft.EntityFrameworkCore;
using EmployeeManagement_API.Data;
using EmployeeManagement_API.Models;
using Microsoft.AspNetCore.Mvc;


namespace EmployeeManagement_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeContext _context;
        public EmployeeController(EmployeeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployee(int EmployeeId)
        {
            var allEmployees = await _context.Employees.FindAsync(EmployeeId);
            if (allEmployees == null)
                return NotFound();
            return Ok(allEmployees);

        }

        [HttpPost]
        public async Task<ActionResult<Employee>> AddEmployee(Employee newEmployee)
        {
            try
            {
                _context.Employees.Add(newEmployee);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                var existingEmployee = await _context.Employees
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.EmployeeId == newEmployee.EmployeeId);
                return Ok(existingEmployee);
            }
        }

        [HttpPut("{EmployeeId}")]
        public async Task<ActionResult> UpdateEmployee(int EmployeeId, Employee UpdatedEmp)
        {
            if (UpdatedEmp == null)
                return BadRequest("Data is empty");

            var employee = await _context.Employees.FindAsync(EmployeeId);
            if (employee == null)
                return NotFound();

            employee.EmployeeName = UpdatedEmp.EmployeeName;
            employee.EmployeeRole = UpdatedEmp.EmployeeRole;
            employee.Experience = UpdatedEmp.Experience;
                await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{EmployeeId}")]
        public async Task<ActionResult> DeleteEmployee(int EmployeeId)
        {
            var employee = await _context.Employees.FindAsync(EmployeeId);
            if (employee == null)
                return NotFound();

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
    
}
