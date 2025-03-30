using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_SQL_Dapper_Study.Migrations
{
    /// <inheritdoc />
    public partial class Add_StoredProcedureReport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE PROCEDURE march.sp_SalaryReportByDepartament
                                    @DeptId INT
                                    AS
                                    SET NOCOUNT ON;

                                    WITH FullPayroll AS
                                    (
                                    SELECT 
                                        d.Name AS DeptName, d.Id AS DeptId, e.Id, e.FullName, e.HireDate, e.Salary, (p.Bonus - p.Deductions) AS Extra
                                    FROM march.Employees e
                                    JOIN march.Departments d ON d.Id = e.DepartmentId
                                    JOIN march.Payroll p ON p.EmployeeId = e.Id
                                    WHERE d.Id = @DeptId
                                    )

                                    SELECT 
                                        DeptName, DeptId, Id, FullName, HireDate, Salary,  
                                        Extra, (Salary + Extra) AS FullEarn,
                                        AVG(Extra) OVER(PARTITION BY DeptId) AS AvgDeptExtra,
                                        RANK() OVER(PARTITION BY DeptId ORDER BY Extra DESC) AS RunkExtraInDept,
                                        AVG(Salary) OVER(PARTITION BY DeptId) AS AvgDeptSalary,
                                        RANK() OVER(PARTITION BY DeptId ORDER BY Salary DESC) AS RunkSalaryInDept
                                    FROM FullPayroll");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"IF OBJECT_ID('march.sp_SalaryReportByDepartament', 'P') IS NOT NULL
                                   DROP PROCEDURE march.sp_SalaryReportByDepartament");
        }
    }
}
