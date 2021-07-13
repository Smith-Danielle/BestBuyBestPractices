using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using System.Threading;


namespace BestBuyBestPractices
{
    class Program
    {
        static void Main(string[] args)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandTimeout = 200;

            // Lines 15-22 is the config code
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

            IDbConnection conn = new MySqlConnection(connString);

            //Exercise 1
            /*var repo1 = new DapperDepartmentRepository(conn);

            Console.WriteLine("Enter a new Department name.");

            var newDepartment = Console.ReadLine();

            repo1.InsertDepartment(newDepartment);


            var departments = repo1.GetAllDepartments();

            foreach (var item in departments)
            {
                Console.WriteLine($"{item.DepartmentID}: {item.Name}");
            }*/

            //Exercise 2
            /*var repo2 = new DapperProductRepository(conn);
            
            Console.WriteLine("Enter a new Proudct. Let's start with the name.");

            var newProdName = Console.ReadLine();

            Console.WriteLine("Please enter the price");

            var newProdPrice = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Please enter the Catergory ID");

            var newProdCat = Convert.ToInt32(Console.ReadLine());

            repo2.CreateProduct(newProdName, newProdPrice, newProdCat);

            var products = repo2.GetAllProducts();
            Thread.Sleep(1500);

            foreach (var item in products)
            {
                Console.WriteLine($"Name: {item.Name}");
                Console.WriteLine($"Price: {item.Price}");
                Console.WriteLine($"Cat ID:{item.CategoryID}");
                Console.WriteLine("---------------------------------------");
            }*/

            //Bonus 1
            /*var repo3 = new DapperProductRepository(conn);
            repo3.UpdateProduct("The Sims 4", 40.25, 580);*/

            //Bonus 2
            /*var repo4 = new DapperProductRepository(conn);
            repo4.DeleteProduct(945);*/

            //My own Bonus Items on Sale or Not
            /*var repo5 = new DapperProductRepository(conn);
            var sales = repo5.SelectOnSale(1);
            Console.WriteLine("-----------------------------");
            Console.WriteLine("On Sale Items");
            Console.WriteLine("-----------------------------");
            foreach (var item in sales)
            {
                Console.WriteLine($"PrductID {item.ProductID}: OnSale {item.OnSale} - {item.Name} @ {item.Price}");
            }
            var sales1 = repo5.SelectOnSale(0);
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Non-Sale Items");
            Console.WriteLine("-----------------------------");
            foreach (var item in sales1)
            {
                Console.WriteLine($"PrductID {item.ProductID}: OnSale {item.OnSale} - {item.Name} @ {item.Price}");
            }*/


        }
    }
}
