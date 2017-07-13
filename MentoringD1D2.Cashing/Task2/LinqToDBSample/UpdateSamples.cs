using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinqToDBSample.Model;
using System.Linq;
using LinqToDB;

namespace LinqToDBSample
{
	[TestClass]
	public class UpdateSamples
	{
		[TestMethod]
		public void UpdateByOneEntity()
		{
			int productId;

			using (var db = new Northwind())
			{
				var p = new Product()
				{
					Name = "New product",
					CategoryID = 1
				};

				productId = Convert.ToInt32(db.InsertWithIdentity(p));
			}

			using (var db = new Northwind())
			{
				var p = db.Products.Single(t => t.Id == productId);
				p.UnitPrice++;
				db.Update(p);
			}

			using (var db = new Northwind())
			{
				var p = db.Products.Single(t => t.Id == productId);
				db.Delete(p);
			}
		}


		[TestMethod]
		public void UpdateConstructQuery()
		{
			using (var db = new Northwind())
			{
				db.Products
				  .Where(p => p.UnitsInStock == 0)
				  .Set(p => p.Discontinued, true)
				  .Update();
			}

			using (var db = new Northwind())
			{
				db.Products
				  .Where(p => p.Discontinued)
				  .Delete();
			}
		}
	}
}
