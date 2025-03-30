using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_SQL_Dapper_Study.Migrations
{
    /// <inheritdoc />
    public partial class Create_View : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW march.View_DepartmentEmployees AS
	                               SELECT d.Id, d.Name, e.FullName AS EmployeeFullName, e.Email, e.HireDate
	                               FROM march.Departments d
	                               JOIN march.Employees e ON e.DepartmentId = d.Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW IF EXISTS march.View_DepartmentEmployees");
        }
    }
}
