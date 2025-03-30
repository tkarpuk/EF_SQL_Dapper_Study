namespace EF_SQL_Dapper_Study.Models
{
    public class DepartmentEmployees
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? EmployeeFullName { get; set; }
        public string? Email { get; set; }
        public DateTime? HireDate { get; set; }
    }
}
