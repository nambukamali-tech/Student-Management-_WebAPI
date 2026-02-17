using EmployeeManagement_API.Data;
using EmployeeManagement_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JoinsController : ControllerBase
    {
        private readonly EmployeeContext _context;
        public JoinsController(EmployeeContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<List<Attendance>>> AddAttendance(Attendance attendance)
        {
            _context.Attendances.Add(attendance);
            await _context.SaveChangesAsync();
            return Ok(attendance);
        }


        [HttpGet("report")]
        public async Task<ActionResult<List<Attendance>>> AttendanceReport(int EmployeeId)
        {
            var report = await _context.Attendances
                .Include(e => e.Employee)
                .Select(e => new
                {
                    e.EmployeeId,
                    EmployeeName = e.Employee.EmployeeName,
                    e.AttendanceId,
                    e.AttendanceDate,
                    e.Status

                }).ToListAsync();
            return Ok(report);
                

        }


    }
}
