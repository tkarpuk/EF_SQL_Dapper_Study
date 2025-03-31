using Dapper;
using Microsoft.Data.SqlClient;

using EF_SQL_Dapper_Study.Models;

namespace EF_SQL_Dapper_Study.Repositories
{
    public class DapperEmployeeRepositrory(string connectionString) : IEmployeeRepository
    {
        private readonly string _connectionString = connectionString;
        public void AddEmployee(int departmentId, Employee employee, Payroll payroll)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAll()
        {
            using var connection = new SqlConnection(_connectionString);
            var sql = @$"SELECT 
                         Id, FullName, Email, DepartmentId, HireDate, Salary 
                         FROM march.Employees";
            var employees = connection.Query<Employee>(sql);

            return employees;
        }

        public IEnumerable<DepartmentEmployees> GetByDepartment(int departmentId)
        {
            throw new NotImplementedException();
            //@$"SELECT 
            //                            Id, Name, EmployeeFullName, Email, HireDate 
            //                            FROM march.View_DepartmentEmployees
            //                            WHERE Id = {departmentId}")
        }

        public Employee GetByName(string name)
        {
            //$@"SELECT 
            //                            Id, FullName, Email, DepartmentId, HireDate, Salary 
            //                            FROM march.Employees 
            //                            WHERE FullName LIKE {"%" + name + "%"}")
            throw new NotImplementedException();
        }

        public IEnumerable<SalaryReport> GetSalaryReport(int departmentId)
        {
            throw new NotImplementedException();
        }

        public void Update(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
