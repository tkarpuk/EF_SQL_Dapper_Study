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
                .FromSqlRaw(@"SELECT 
                              Id, FullName, Email, DepartmentId, HireDate, Salary 
                              FROM march.Employees")
                .AsNoTracking()
                .ToList();

            return employees;
        }

        public IEnumerable<DepartmentEmployees> GetByDepartment(int departmentId)
        {
            using var db = new AppDbContext();
            var departmentEmployees = db.DepartmentEmployees
                .FromSqlInterpolated(@$"SELECT 
                                        Id, Name, FullName, Email, HireDate 
                                        FROM march.Employees
                                        WHERE Id = {departmentId}")
                .AsNoTracking()
                .ToList();

            return departmentEmployees;
        }

        public Employee GetByName(string name)
        {
            using var db = new AppDbContext();
            var employee = db.Employees
                .FromSqlInterpolated($@"SELECT 
                                        Id, FullName, Email, DepartmentId, HireDate, Salary 
                                        FROM march.Employees 
                                        WHERE FullName LIKE {"%" + name + "%"}")
                .AsNoTracking()
                .FirstOrDefault();

            return employee!;
        }

        public void Update(Employee employee)
        {
            using var db = new AppDbContext();
            db.Database
                .ExecuteSqlInterpolated($@"UPDATE march.Employees 
                                           SET Email = {employee.Email}, 
                                               Salary = {employee.Salary}
                                           WHERE Id = {employee.Id}");
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
