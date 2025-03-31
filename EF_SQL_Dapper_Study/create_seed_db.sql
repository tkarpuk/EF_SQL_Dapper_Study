-- Create the schema
IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'march')
BEGIN
    EXEC('CREATE SCHEMA march');
END;

-- Create the Departments table
CREATE TABLE march.Departments (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100),
    Location NVARCHAR(100)
);

-- Create the Employees table
CREATE TABLE march.Employees (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100),
    Email NVARCHAR(100),
    DepartmentId INT,
    HireDate DATETIME,
    Salary DECIMAL(18, 2),
    FOREIGN KEY (DepartmentId) REFERENCES march.Departments(Id)
);

-- Create the Payroll table
CREATE TABLE march.Payroll (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeId INT,
    Month INT,
    Year INT,
    Bonus DECIMAL(18, 2),
    Deductions DECIMAL(18, 2),
    FOREIGN KEY (EmployeeId) REFERENCES march.Employees(Id)
);

-- Populate Departments
INSERT INTO march.Departments (Name, Location) VALUES
('Human Resources', 'New York'),
('IT', 'San Francisco'),
('Finance', 'Chicago');

-- Populate Employees
INSERT INTO march.Employees (FullName, Email, DepartmentId, HireDate, Salary) VALUES
('Alice Johnson', 'alice.johnson@example.com', 1, '2020-05-15', 60000.00),
('Bob Smith', 'bob.smith@example.com', 2, '2019-03-22', 80000.00),
('Clara Martinez', 'clara.martinez@example.com', 3, '2021-08-01', 75000.00);

-- Populate Payroll
INSERT INTO march.Payroll (EmployeeId, Month, Year, Bonus, Deductions) VALUES
(1, 1, 2024, 1000.00, 200.00),
(2, 1, 2024, 1500.00, 250.00),
(3, 1, 2024, 1200.00, 300.00);