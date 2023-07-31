// using Microsoft.Extensions.Configuration;
// using Dapper;
// using MySqlConnector;

// public class SplitOn
// {
//   static async Task Whatever(IConfiguration config)
//   {
//     using (MySqlConnection connection = new(config.GetConnectionString("CityScrapeDb")))
//     {
//       var sql = @"
//         SELECT ProductID, ProductName, p.CategoryID, CategoryName
//         FROM Products p 
//         INNER JOIN Categories c ON p.CategoryID = c.CategoryID
//       ";

//       var products = await connection.QueryAsync<Product, Category, Product>(sql, (product, category) =>
//       {
//         product.Category = category;
//         return product;
//       },
//       splitOn: "CategoryId");

//       products.ToList().ForEach(product => Console.WriteLine($"Product: {product.ProductName}, Category: {product.Category.CategoryName}"));

//       Console.ReadLine();
//     }
//   }
// }