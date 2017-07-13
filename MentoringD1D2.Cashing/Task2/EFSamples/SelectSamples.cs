using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EFSamples.Model;
using System.Data.Entity;
using System.Linq;

namespace EFSamples
{
	[TestClass]
	public class SelectSamples
	{
		[TestMethod]
		public void LazyLoading()
		{
			using (var db = new NorthwindDB())
			{
				foreach (var p in db.Products)
				{
					Console.WriteLine(p.Name + " | " + p.Category.Name);
				}
			}
		}

		[TestMethod]
		public void ExplicitlyLoading()
		{
			using (var db = new NorthwindDB())
			{
				db.Configuration.LazyLoadingEnabled = false;
				
				foreach (var p in db.Products)
				{
					db.Entry(p).Reference(t => t.Category).Load();
					Console.WriteLine(p.Name + " | " + p.Category.Name);
				}
			}
		}

		[TestMethod]
		public void EagerlyLoading()
		{
			using (var db = new NorthwindDB())
			{
				db.Configuration.LazyLoadingEnabled = false;

				foreach (var p in db.Products.Include(t => t.Category))
				{
					Console.WriteLine(p.Name + " | " + p.Category.Name);
				}
			}
		}

		[TestMethod]
		public void NavigationSample()
		{
			var categoryName = "Beverages";
			using (var db = new NorthwindDB())
			{
				var category = db.Categories.Single(c => c.Name == categoryName);
				Console.WriteLine(category.Description);

				foreach (var p in category.Products)
					Console.WriteLine(p.Name);
			}
		}

	}
}
