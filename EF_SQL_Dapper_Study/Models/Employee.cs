namespace EF_SQL_Dapper_Study.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public int? DepartmentId { get; set; }

    public DateTime? HireDate { get; set; }

    public decimal? Salary { get; set; }
}
