using Dapper;
using EF_SQL_Dapper_Study.Models;

namespace EF_SQL_Dapper_Study.Repositories
{
    public class DapperEmployeeRepositrory : IEmployeeRepository
    {
        public void AddEmployee(int departmentId, Employee employee, Payroll payroll)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DepartmentEmployees> GetByDepartment(int departmentId)
        {
            throw new NotImplementedException();
        }

        public Employee GetByName(string name)
        {
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
