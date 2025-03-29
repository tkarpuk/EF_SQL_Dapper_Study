namespace EF_SQL_Dapper_Study.Models;

public partial class Payroll
{
    public int Id { get; set; }

    public int? EmployeeId { get; set; }

    public int? Month { get; set; }

    public int? Year { get; set; }

    public decimal? Bonus { get; set; }

    public decimal? Deductions { get; set; }
}
