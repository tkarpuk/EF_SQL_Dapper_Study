using Dapper;
using Microsoft.Data.SqlClient;
using EF_SQL_Dapper_Study.Models;
using System.Data;

namespace EF_SQL_Dapper_Study.Repositories
{
    public class DapperEmployeeRepositrory(string connectionString) : IEmployeeRepository
    {
        private readonly string _connectionString = connectionString;
        public void AddEmployee(int departmentId, Employee employee, Payroll payroll)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            using (var transaction = connection.BeginTransaction())
            try
            {
                var employeeSql = @"INSERT INTO march.Employees
                    (FullName, Email, DepartmentId, HireDate, Salary)
                    OUTPUT INSERTED.Id
                    VALUES 
                    (@FullName, @Email, @DepartmentId, @HireDate, @Salary)";

                // Add Employee and get Id
                var employeeId = connection.ExecuteScalar<int>(employeeSql, 
                    new { 
                        FullName = employee.FullName, 
                        Email = employee.Email, 
                        DepartmentId = employee.DepartmentId, 
                        HireDate = employee.HireDate, 
                        Salary = employee.Salary
                    }, transaction);

                // check Id
                if (employeeId == 0)
                {
                    throw new Exception("ID of inserted Employee = 0!");
                }

                // add payroll
                var payrollSql = @"
                     INSERT INTO march.Payroll
                     (EmployeeId, Month, Year, Bonus, Deductions)
                     VALUES
                     (@EmployeeId, @Month, @Year, @Bonus, @Deductions)";

                connection.Execute(payrollSql, 
                    new {
                        EmployeeId = payroll.EmployeeId,
                        Month = payroll.Month,
                        Year = payroll.Year,
                        Bonus = payroll.Bonus,
                        Deductions = payroll.Deductions
                    }, 
                    transaction);

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }

        public IEnumerable<Employee> GetAll()
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = @"SELECT 
                        Id, FullName, Email, DepartmentId, HireDate, Salary 
                        FROM march.Employees";
            var employees = connection.Query<Employee>(sql);

            return employees;
        }

        public IEnumerable<DepartmentEmployees> GetByDepartment(int departmentId)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = @$"SELECT 
                        Id, Name, EmployeeFullName, Email, HireDate 
                        FROM march.View_DepartmentEmployees
                        WHERE Id = @deptId";
            var employees = connection.Query<DepartmentEmployees>(sql, new { deptId = departmentId });

            return employees;
        }

        public Employee GetByName(string name)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = @"SELECT 
                        Id, FullName, Email, DepartmentId, HireDate, Salary 
                        FROM march.Employees 
                        WHERE FullName LIKE @pattern";

            var employee = connection.QueryFirstOrDefault<Employee>(sql, new { Pattern = $"%{name}%" });

            return employee;
        }

        public IEnumerable<SalaryReport> GetSalaryReport(int departmentId)
        {
            using var connection = new SqlConnection(_connectionString);
            var report = connection.Query<SalaryReport>("march.sp_SalaryReportByDepartament", new { DeptId = departmentId }, commandType: CommandType.StoredProcedure);

            return report;
        }

        public void Update(Employee employee)
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = @"UPDATE march.Employees 
                        SET Email = @Email, 
                            Salary = @Salary
                        WHERE Id = @Id";

            connection.Execute(sql, new { Email = employee.Email, Salary = employee.Salary, Id = employee.Id });
        }
    }
}
