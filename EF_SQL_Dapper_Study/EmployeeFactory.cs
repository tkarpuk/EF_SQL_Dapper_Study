// See https://aka.ms/new-console-template for more information

using Bogus;
using EF_SQL_Dapper_Study.Models;

internal class EmployeeFactory
{
    internal static Employee Create()
    {
        var faker = new Faker<Employee>()
            .RuleFor(p => p.FullName, f => f.Person.FullName)
            .RuleFor(p => p.Email, f => f.Person.Email)
            .RuleFor(p => p.HireDate, f => f.Date.Recent(300))
            .RuleFor(p => p.Salary, f => f.Finance.Amount(50_000, 90_000, 0));

        return faker.Generate();
    }
}