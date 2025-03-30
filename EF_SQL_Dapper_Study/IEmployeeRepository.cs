using EF_SQL_Dapper_Study.Models;

namespace EF_SQL_Dapper_Study
{
    public interface IEmployeeRepository
    {
        /// <summary>
        /// using SELECT
        /// </summary>
        /// <returns></returns>
        IEnumerable<Employee> GetAll();
        /// <summary>
        /// using LIKE
        /// </summary>
        /// <param name="name">A part of Employee name</param>
        /// <returns></returns>
        Employee GetByName(string name);
        /// <summary>
        /// using Transaction
        /// </summary>
        /// <param name="departmentId"></param>
        /// <param name="employee">Generated Employee object</param>
        /// <param name="payroll">Generated Payroll object</param>
        void AddEmployee(int departmentId, Employee employee, Payroll payroll);
        /// <summary>
        /// using UPDATE
        /// </summary>
        /// <param name="employee">Generated Employee object</param>
        void Update(Employee employee);
        /// <summary>
        /// using VIEW
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        IEnumerable<DepartmentEmployees> GetByDepartment(int departmentId);
        /// <summary>
        /// using stored procedure, CTE, Window Function
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        IEnumerable<SalaryReport> GetSalaryReport(int departmentId);
    }
}
