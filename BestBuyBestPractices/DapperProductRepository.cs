using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace BestBuyBestPractices
{
    public class DapperProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;

        public DapperProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _connection.Query<Product>("SELECT * FROM Products;");
        }
        public void CreateProduct(string name, double price, int categoryID)
        {
            _connection.Execute("INSERT INTO Products (Name, Price, CategoryID) VALUES(@productName,@productPrice,@productCategoryID);",
                new { productName = name, productPrice = price, productCategory = categoryID });
            Console.WriteLine($"{name}, {price}, {categoryID} has been added to the Products table.");

        }

        public void UpdateProduct(string name, double price, int productID)
        {
            _connection.Execute("UPDATE Products SET Name = @updateName, Price = @updatePrice WHERE ProductID = @updateProductID;",
                new { updateName = name, updatePrice = price, updateProductID = productID });
            Console.WriteLine($"{name} @ {price} has been updated at ProductID {productID} to the Products table. ");
        }
        public void DeleteProduct(int productID)
        {
            _connection.Execute("DELETE FROM Products WHERE ProductID = @deleteProductID;",
                new { deleteProductID = productID });
            _connection.Execute("DELETE FROM Sales WHERE ProductID = @deleteProductID;",
                new { deleteProductID = productID });
            _connection.Execute("DELETE FROM Reviews WHERE ProductID = @deleteProductID;",
                new { deleteProductID = productID });
            Console.WriteLine($"ProductID {productID} has been deleted from the Products table.");
        }

        
    }
}
