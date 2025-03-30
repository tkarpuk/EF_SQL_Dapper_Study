namespace EF_SQL_Dapper_Study.Models
{
    public class SalaryReport
    {
        public string? DeptName { get; set; }
        public int DeptId { get; set; }
        public int Id { get; set; }
        public string? FullName { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public decimal FullEarn { get; set; }
        public decimal AvgDeptExtra { get; set; }
        public int RunkExtraInDept { get; set; }
        public decimal AvgDeptSalary { get; set; }
        public int RunkSalaryInDept { get; set; }
        public decimal MyProperty { get; set; }
    }
}