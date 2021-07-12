using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;


namespace BestBuyBestPractices
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);

            var repo1 = new DapperDepartmentRepository(conn);

            Console.WriteLine("Enter a new Department name.");

            var newDepartment = Console.ReadLine();

            repo1.InsertDepartment(newDepartment);

            Console.WriteLine($"{newDepartment} has been been added to the Department table.");

            var departments = repo1.GetAllDepartments();

            foreach (var item in departments)
            {
                Console.WriteLine($"{item.DepartmentID}: {item.Name}");
            }
        }
    }
}
