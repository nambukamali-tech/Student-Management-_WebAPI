using StudentManagementAPI.Models;
using StudentManagementAPI.Data;
using Microsoft.AspNetCore.Mvc;
namespace StudentManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly StudentContext _context;
        public StudentController(StudentContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(student);
            }

        }

        [HttpPost]
        public async Task<ActionResult<Student>> AddStudent(Student student)
        {
            _context.Students.Add(student);//Add the student first
            await _context.SaveChangesAsync();//Then save the changes next to db
            return student;

        }
        //Update student details
        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> UpdateStudent(int id ,Student student)
        {
            if(id != student.Id)
            {
                return BadRequest("Id not found!");
            }
            var existingStudent = await _context.Students.FindAsync(id);
            if(existingStudent == null)
            {
                return NotFound();
            }
            existingStudent.Name = student.Name;
            existingStudent.Course = student.Course;
            existingStudent.Year = student.Year;

            await _context.SaveChangesAsync();
            return Ok(existingStudent);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> DeleteStudents(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}
