using EF_SQL_Dapper_Study.Models;

namespace EF_SQL_Dapper_Study
{
    // TODO: add new employee + payroll (by Stored Procedure)
    // TODO: add department + 5 employee by transaction
    // TODO: report max, min, avg salary by department (using SP and Window functions)

    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll(); // using SELECT
        Employee GetByName(string name); // using LIKE
        void AddEmployee(int departmentId, Employee employee, Payroll payroll); // using Transaction
        void Update(Employee employee); // using UPDATE
        //void Delete(int Id); // using Stored Procedure - for delete in PayRoll too
        //------
        IEnumerable<DepartmentEmployees> GetByDepartment(int departmentId); // using VIEW
        //IEnumerable<Report> GetSalaryReport(); // using Window Function
    }
}
