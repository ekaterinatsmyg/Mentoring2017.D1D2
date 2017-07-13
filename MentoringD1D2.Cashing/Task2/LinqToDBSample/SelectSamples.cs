using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinqToDBSample.Model;
using System.Linq;
using LinqToDB;

namespace LinqToDBSample
{
	[TestClass]
	public class SelectSamples
	{
		[TestMethod]
		public void JoinQuery()
		{
			var categoryName = "Beverages";
			using (var db = new Northwind())
			{
				var products = from p in db.Products
							   join c in db.Categories on p.CategoryID equals c.Id
							   where c.Name == categoryName
							   select p;

				foreach (var p in products)
					Console.WriteLine(p.Name);
			}
		}


		[TestMethod]
		public void AssociationQuery()
		{
			var categoryName = "Beverages";
			using (var db = new Northwind())
			{
				var products = from p in db.Products
							   where p.Category.Name == categoryName
							   select p;

				foreach (var p in products)
					Console.WriteLine(p.Name);
			}
		}

		[TestMethod]
		public void NavigationSample()
		{
			var categoryName = "Beverages";
			using (var db = new Northwind())
			{
				var category = db.Categories.Single(c => c.Name == categoryName);
				Console.WriteLine(category.Description);

				var products = db.Products.Where(p => p.CategoryID == category.Id);

				foreach (var p in products)
					Console.WriteLine(p.Name);
			}
		}
		
	}
}
