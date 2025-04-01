# EF_SQL_Dapper_Study

This is a simple console application for work with DB (MS SQL Server) by SQL using
- EF Core
- or Dapper


## 🚀 Features

- Using EF Core: see EfEmployeeRepository.cs
- Using Dapper: see DapperEmployeeRepositrory.cs
- Used DataBase-First approach
- Using Migrations for creating View, Stored Procedure
- Demonstrated using SQL features like: View, Stored Procedures, CTE, Transactions, Select, Insert, Update
- Create fake data by Bogus

## 🛠️ Technologies Used

- .NET 8
- C#
- Entity Framework Core
- Dapper
- SQL

- command that used for created model from DB (DataBase-First):
Scaffold-DbContext "Server=(localdb)\MSSQLLocalDB;Database=EF_Dapper;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context AppDbContext -Schemas march -Force
- I didn't use Parameters for SQL, because "The FromSql and FromSqlInterpolated methods are safe against SQL injection, and always integrate parameter data as a separate SQL parameter. " see https://learn.microsoft.com/en-us/ef/core/querying/sql-queries?tabs=sqlserver

## 📦 Installation Notes

- create database using "create_seed_db.sql"
- edit ConnectionString
- apply migrations