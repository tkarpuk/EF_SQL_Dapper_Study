using EF_SQL_Dapper_Study.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_SQL_Dapper_Study.Repositories
{
    public class EfEmployeeRepository : IEmpoyeeRepository
    {
        public IEnumerable<Employee> GetAll()
        {
            using var db = new AppDbContext();
            var employees = db.Employees
                .FromSqlRaw("SELECT * FROM march.Employees")
                .ToList();

            return employees;
        }
    }

    //var deleteEmployee = await db.Employees.FromSqlInterpolated
    //($@"SELECT TOP(1) * FROM march.Employees WHERE Email = {newEmployee.Email}")
    //.AsNoTracking()
    //.FirstOrDefaultAsync();

    //await db.Database.ExecuteSqlInterpolatedAsync
    //    ($@"INSERT INTO march.Employees (
    //        FullName,
    //        Email,
    //        DepartmentId,
    //        HireDate,
    //        Salary
    //    ) 
    //    VALUES (
    //        {newEmployee.FullName},
    //        {newEmployee.Email},
    //        {newEmployee.DepartmentId},
    //        {newEmployee.HireDate},
    //        {newEmployee.Salary}
    //    )");
}
