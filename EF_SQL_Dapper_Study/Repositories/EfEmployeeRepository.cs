﻿using EF_SQL_Dapper_Study.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_SQL_Dapper_Study.Repositories
{
    public class EfEmployeeRepository(string connectionString) : IEmployeeRepository
    {
        private readonly string _connectionString = connectionString;
        public void AddEmployee(int departmentId, Employee employee, Payroll payroll)
        {
            using var db = new AppDbContext(_connectionString);
            using var transaction = db.Database.BeginTransaction();

            try
            {
                // Add Employee and get Id
                var result = db.Set<ResultId> ()
                    .FromSql($@"
                     INSERT INTO march.Employees
                     (FullName, Email, DepartmentId, HireDate, Salary)
                     OUTPUT INSERTED.Id
                     VALUES 
                     ({employee.FullName}, {employee.Email}, {departmentId}, {employee.HireDate}, {employee.Salary})")
                    .AsEnumerable()
                    .FirstOrDefault();

                // check Id
                int employeeId = result?.Id ?? 0;
                if (employeeId == 0)
                {
                    throw new Exception("ID of inserted Employee = 0!");
                }

                // add payroll
                db.Database
                    .ExecuteSql($@"
                     INSERT INTO march.Payroll
                     (EmployeeId, Month, Year, Bonus, Deductions)
                     VALUES
                     ({employeeId}, {payroll.Month}, {payroll.Year}, {payroll.Bonus}, {payroll.Deductions})");

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
            using var db = new AppDbContext(_connectionString);
            var employees = db.Employees
                .FromSql(@$"SELECT 
                              Id, FullName, Email, DepartmentId, HireDate, Salary 
                              FROM march.Employees")
                .AsNoTracking()
                .ToList();

            return employees;
        }

        public IEnumerable<DepartmentEmployees> GetByDepartment(int departmentId)
        {
            using var db = new AppDbContext(_connectionString);
            var departmentEmployees = db.DepartmentEmployees
                .FromSql(@$"SELECT 
                            Id, Name, EmployeeFullName, Email, HireDate 
                            FROM march.View_DepartmentEmployees
                            WHERE Id = {departmentId}")
                .AsNoTracking()
                .ToList();

            return departmentEmployees;
        }

        public Employee GetByName(string name)
        {
            using var db = new AppDbContext(_connectionString);
            var employee = db.Employees
                .FromSql($@"SELECT 
                            Id, FullName, Email, DepartmentId, HireDate, Salary 
                            FROM march.Employees 
                            WHERE FullName LIKE {"%" + name + "%"}")
                .AsNoTracking()
                .FirstOrDefault();

            return employee!;
        }

        public IEnumerable<SalaryReport> GetSalaryReport(int departmentId)
        {
            using var db = new AppDbContext(_connectionString);
            var report = db.SalaryReports.FromSql($@"EXEC march.sp_SalaryReportByDepartament @DeptId = {departmentId}")
                .AsNoTracking()
                .ToList();

            return report;
        }

        public void Update(Employee employee)
        {
            using var db = new AppDbContext(_connectionString);
            db.Database
                .ExecuteSql($@"UPDATE march.Employees 
                                SET Email = {employee.Email}, 
                                    Salary = {employee.Salary}
                                WHERE Id = {employee.Id}");
        }
    }
}
