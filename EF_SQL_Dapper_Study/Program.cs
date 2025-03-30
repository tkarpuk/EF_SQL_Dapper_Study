// See https://aka.ms/new-console-template for more information

using EF_SQL_Dapper_Study;
using EF_SQL_Dapper_Study.Repositories;

IEmployeeRepository empoyeeRepository = GetRepository();

IEmployeeRepository GetRepository()
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("\n========= Select type of DB access =========\n");
    Console.WriteLine("1. Use Entity Framework Core");
    //Console.WriteLine("2. Use Dapper");
    Console.WriteLine("---------------------------------------------\n");

    Console.Write("Choose an option: ");
    string input = Console.ReadLine();

    //if (input == 2)

    return new EfEmployeeRepository();
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
    Console.WriteLine("4. Delete Employee");
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
            DeleteEmployee();
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
    Console.WriteLine("Sorry, but it isn't implemented yet.");
}

void ShowDepartment()
{
    Console.ResetColor();
    Console.WriteLine("\n---------------------------------------------");
    Console.WriteLine("Enter Department ID (1, 2, 3 ...)");
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

void DeleteEmployee()
{
    Console.ResetColor();
    Console.WriteLine("Sorry, but it isn't implemented yet.");
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