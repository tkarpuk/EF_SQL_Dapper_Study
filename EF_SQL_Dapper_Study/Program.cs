﻿// See https://aka.ms/new-console-template for more information

using EF_SQL_Dapper_Study;
using EF_SQL_Dapper_Study.Repositories;

IEmployeeRepository empoyeeRepository = GetRepository();

IEmployeeRepository GetRepository()
{
    string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=EF_Dapper;Trusted_Connection=True;";

    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("\n========= Select type of DB access =========\n");
    Console.WriteLine("1. Use Entity Framework Core (default)");
    Console.WriteLine("2. Use Dapper");
    Console.WriteLine("---------------------------------------------\n");

    Console.Write("Choose an option: ");
    string input = Console.ReadLine();

    if (!int.TryParse(input, out var repoType))
    {
        repoType = 1;
    }

    if (repoType == 2)
       return new DapperEmployeeRepositrory(connectionString);

    return new EfEmployeeRepository(connectionString);
}

bool running = true;

while (running)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Clear();
    Console.WriteLine("\n========= M E N U =========\n");
    Console.WriteLine("1. Show all Employees");
    Console.WriteLine("2. Searh Employee");
    Console.WriteLine("3. Update Employee");
    Console.WriteLine("4. Add Employees");
    Console.WriteLine("---------------------------------");
    Console.WriteLine("5. Show Employees in Department");
    Console.WriteLine("6. Print salary report");
    Console.WriteLine("---------------------------------");
    Console.WriteLine("7. Exit\n");

    Console.Write("Choose an option: ");
    string input = Console.ReadLine();

    switch (input)
    {
        case "1":
            ShowAllEmployees();
            break;
        case "2":
            SearchEmployee();
            break;
        case "3":
            UpdateEmployee();
            break;
        case "4":
            AddEmployees();
            break;
        case "5":
            ShowDepartment();
            break;
        case "6":
            PrintSalaryReport();
            break;
        case "7":
            running = false;
            break;
        default:
            Console.WriteLine("Invalid option. Try again.");
            break;
    }

    Console.ForegroundColor = ConsoleColor.Green;
    if (running)
    {
        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
    }
}

void PrintSalaryReport()
{
    Console.ResetColor();
    Console.WriteLine("\n---------------------------------------------");
    Console.WriteLine("Enter Department ID (1, 2, 3)");
    string? input = Console.ReadLine();
    if (!int.TryParse(input, out var departmentId))
    {
        Console.WriteLine("Invalid Department Id input");
        return;
    }

    var report = empoyeeRepository.GetSalaryReport(departmentId);
    Console.WriteLine($"Name\tSalary\tRunk in Dept\tAVG Salary");
    foreach (var employee in report)
    {
        Console.WriteLine($"{employee.FullName}\t{employee.Salary:0.##}\t{employee.RunkSalaryInDept}\t{employee.AvgDeptSalary:0.##}");
    }
    Console.WriteLine("---------------------------------------------\n");
}

void ShowDepartment()
{
    Console.ResetColor();
    Console.WriteLine("\n---------------------------------------------");
    Console.WriteLine("Enter Department ID (1, 2, 3)");
    string input = Console.ReadLine();
    if (!int.TryParse(input, out var departmentId))
    {
        Console.WriteLine("Invalid department ID input.");
        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
        return;
    }

    var departmentEmpoyees = empoyeeRepository.GetByDepartment(departmentId);
    foreach (var department in departmentEmpoyees)
    {
        Console.WriteLine($"{department.Id}\t{department.Name}\t{department.EmployeeFullName}\t{department.Email}");
    }
}

void AddEmployees()
{
    Console.ResetColor();
    Console.WriteLine("\n---------------------------------------------");
    Console.WriteLine("Enter department ID (1, 2, 3)");
    string? input = Console.ReadLine();
    if (!int.TryParse(input, out var departmentId))
    {
        Console.WriteLine("Invalid Department Id input");
        return;
    }

    Console.WriteLine("Enter count of new Employees (1-5)");
    input = Console.ReadLine();
    if (!int.TryParse(input, out int countEmployees))
    {
        countEmployees = 5;
        Console.WriteLine($"Invalid count. Will be added {countEmployees} Employees.");
    }
    try
    {
        for (int i = 0; i < countEmployees; i++)
        {
            var newEmployee = EmployeeFactory.Create();
            var newPayroll = PayrollFactory.Create();

            empoyeeRepository.AddEmployee(departmentId, newEmployee, newPayroll);
        }

    }
    catch (Exception e)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"ERROR! Message: {e.Message}");
        return;
    }

    Console.WriteLine($"Added {countEmployees} Employees in Department ID = {departmentId}.");
    Console.WriteLine("---------------------------------------------\n");
}

void UpdateEmployee()
{
    Console.ResetColor();
    Console.WriteLine("\n---------------------------------------------");
    Console.WriteLine("Enter employee's Name (or part of name)");
    string input = Console.ReadLine();
    var employee = empoyeeRepository.GetByName(input);
    if (employee is null)
    {
        Console.WriteLine("Nobody found...");
        return;
    }

    Console.WriteLine($"{employee.Id}\t{employee.FullName}\t{employee.Email}\t{employee.Salary}");

    Console.WriteLine("Enter new Email...");
    string newEmail = Console.ReadLine();
    employee.Email = newEmail;

    Console.WriteLine("Enter new Salary...");
    string? newSalary = Console.ReadLine();
    if (decimal.TryParse(newSalary, out var parsedSalary))
    {
        employee.Salary = parsedSalary;
    }
    else
    {
        Console.WriteLine("Invalid salary input. Salary not updated.");
    }

    empoyeeRepository.Update(employee);
    Console.WriteLine("Data of the employee updated.");
    Console.WriteLine("---------------------------------------------\n");
    ShowAllEmployees();
}

void SearchEmployee()
{
    Console.ResetColor();
    Console.WriteLine("\n---------------------------------------------");
    Console.WriteLine("Enter employee's Name (or part of name)");
    string input = Console.ReadLine();
    var employee = empoyeeRepository.GetByName(input);
    if (employee is null)
    {
        Console.WriteLine("Nobody found...");
        return;
    }

    Console.WriteLine($"{employee.Id}\t{employee.FullName}\t{employee.Email}");
    Console.WriteLine("---------------------------------------------\n");
}

void ShowAllEmployees()
{
    Console.ResetColor();
    Console.WriteLine("\n---------------------------------------------");

    var employees = empoyeeRepository.GetAll();
    foreach (var employee in employees)
    {
        Console.WriteLine($"{employee.Id}\t{employee.FullName}\t{employee.Email}");
    }
    
    Console.WriteLine("---------------------------------------------\n");
}