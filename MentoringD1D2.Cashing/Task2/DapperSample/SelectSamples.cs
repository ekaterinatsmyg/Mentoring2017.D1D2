using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dapper;
using LinqToDBSample.Model;
using System.Data.SqlClient;
using System.Configuration;

namespace DapperSample
{
	[TestClass]
	public class SelectSamples
	{
		[TestMethod]
		public void FilteredSelect()
		{
			var connectionString = ConfigurationManager.ConnectionStrings["Northwind"].ConnectionString;

			var categoryName = "Beverages";
			var query = "select p.* " +
						"from Northwind.Products p " +
						"join Northwind.Categories c on c.CategoryID = p.CategoryID " +
						"where c.CategoryName = @categoryName";

			using (var connection = new SqlConnection(connectionString))
			{
				connection.Open();
				var products = SqlMapper.Query<Products>(connection, query, new { categoryName } );

				foreach (var p in products)
					Console.WriteLine(p.ProductName);
			}
		}
	}
}
