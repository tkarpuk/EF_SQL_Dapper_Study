using EF_SQL_Dapper_Study.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_SQL_Dapper_Study;

public partial class AppDbContext(string connectionString) : DbContext
{
    private readonly string _connectionString = connectionString;
    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Payroll> Payrolls { get; set; }

    public virtual DbSet<DepartmentEmployees> DepartmentEmployees { get; set; }
    public virtual DbSet<ResultId> ResultIds { get; set; }
    public virtual DbSet<SalaryReport> SalaryReports { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(_connectionString);
}
