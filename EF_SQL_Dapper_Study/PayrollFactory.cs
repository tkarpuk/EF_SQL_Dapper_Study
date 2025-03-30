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
            .RuleFor(p => p.Bonus, f => f.Finance.Amount(1_000, 1_600, 0))
            .RuleFor(p => p.Deductions, f => f.Finance.Amount(200, 300, 0));

        return faker.Generate();
    }
}