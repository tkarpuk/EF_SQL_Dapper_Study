// See https://aka.ms/new-console-template for more information
using EF_SQL_Dapper_Study;
using EF_SQL_Dapper_Study.Models;
using Microsoft.EntityFrameworkCore;

bool running = true;
//Employee GetByName(string name);
//int Add(Employee employee, Payroll payroll);
//void Update(Employee employee);
//void Delete(int Id);
//------
//IEnumerable<FullInfo> GetByDepartment(int departmentId); // using View
//IEnumerable<Report> GetSalaryReport(); // using Window Function

while (running)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.Clear();
    Console.WriteLine("\n========= M E N U =========\n");
    Console.WriteLine("1. Show all Employees");
    Console.WriteLine("2. Add Employee");
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
            AddEmployee();
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
    Console.WriteLine("Sorry, but it isn't implemented yet.");
}

void DeleteEmployee()
{
    Console.ResetColor();
    Console.WriteLine("Sorry, but it isn't implemented yet.");
}

void UpdateEmployee()
{
    Console.ResetColor();
    Console.WriteLine("Sorry, but it isn't implemented yet.");
}

void AddEmployee()
{
    Console.ResetColor();
    Console.WriteLine("Sorry, but it isn't implemented yet.");
}

void ShowAllEmployees()
{
    Console.ResetColor();
    Console.WriteLine("Sorry, but it isn't implemented yet.");
}