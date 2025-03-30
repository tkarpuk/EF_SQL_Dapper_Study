using EF_SQL_Dapper_Study.Models;

namespace EF_SQL_Dapper_Study
{
    // TODO: add new employee + payroll (by Stored Procedure)
    // TODO: add department + 5 employee by transaction
    // TODO: create View for employee by department and GetEmployeesByDept - form this view
    // TODO: report max, min, avg salary by department (using SP and Window functions)

    public interface IEmpoyeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee GetByName(string name);
        //int Add(Employee employee, Payroll payroll);
        void Update(Employee employee);
        //void Delete(int Id);
        //------
        IEnumerable<DepartmentEmployees> GetByDepartment(int departmentId); // using View
        //IEnumerable<Report> GetSalaryReport(); // using Window Function
    }
}
