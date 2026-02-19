using Microsoft.EntityFrameworkCore;
using EmployeeManagement_API.Models;
namespace EmployeeManagement_API.Data

{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options
            ) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
       
    }
}
