// See https://aka.ms/new-console-template for more information

using Bogus;
using EF_SQL_Dapper_Study.Models;

internal class PayrollFactory
{
    internal static Payroll Create()
    {
        var faker = new Faker<Payroll>()
            .RuleFor(p => p.Month, f => f.Date.Recent(100).Month)
            .RuleFor(p => p.Year, f => f.Date.Recent(400).Year)
            .RuleFor(p => p.Bonus, f => f.Finance.Amount(140, 300))
            .RuleFor(p => p.Deductions, f => f.Finance.Amount(10, 50));

        return faker.Generate();
    }
}