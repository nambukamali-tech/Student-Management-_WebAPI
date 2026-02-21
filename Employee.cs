namespace EmployeeManagement_API.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; } = string.Empty;
        public string EmployeeRole { get; set; } = string.Empty;
        public string Experience { get; set; } = string.Empty;
        public List<Attendance> Attendances { get; set; } = new List<Attendance>();

    }
}
