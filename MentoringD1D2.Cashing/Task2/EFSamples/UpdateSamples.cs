using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EFSamples.Model;
using System.Linq;

namespace EFSamples
{
	[TestClass]
	public class UpdateSamples
	{
		[TestMethod]
		public void SaveChanges()
		{
			using (var db = new NorthwindDB())
			{
				var category = db.Categories.Create();
				category.Name = "New category";
				category.Description = "New category description";
				db.Categories.Add(category);

				var product1 = db.Products.Create();
				product1.Name = "New product1";
				product1.Category = category;
				
				var product2 = db.Products.Create();
				product2.Name = "New product2";
				product2.Category = category;

				db.Products.Add(product1);
				db.Products.Add(product2);

				var beveragesProducts = db.Products.Where(p => p.Category.Name == "Beverages");
				foreach (var bp in beveragesProducts)
					bp.Category = category;

				Console.WriteLine(db.SaveChanges());
			}
		}
	}
}
